using POEClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10034968_PROG6212_POE.Front_End
{
    /// <summary>
    /// Interaction logic for AddModuleForm.xaml
    /// </summary>
    public partial class AddModuleForm : Window
    {
        public AddModuleForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method that captures data and uses it to add a module to database when the "Add" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //adding modules to database
            try
            {
                //declaring temporary variables to store the values inputted
                string? modName = txbModName.Text;
                string? modCode = txbModCode.Text;
                int? numOfCredits = Convert.ToInt32(txbNumOfCredits.Text);
                double? classHrsPerWeek = Convert.ToInt32(txbClassHoursPerWeek.Text);
                //checking if all values are inputted correctly
                if (modName == null)
                {
                    throw new Exception("Please enter the module name\n");
                }
                else if (modCode == null)
                {
                    throw new Exception("Please enter the module code\n");
                }
                else if (numOfCredits == null)
                {
                    throw new Exception("Please enter the number of credits\n");
                }
                else if (classHrsPerWeek == null)
                {
                    throw new Exception("Please enter class hours per week\n");
                }
                else
                {
                    //adding module to database
                    addModuleToDB(modCode, modName, (int)numOfCredits, (double)classHrsPerWeek);
                }
            }
            catch (FormatException fe)
            {
                lblError.Content = "Please ensure values are entered correctly.";
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }
        /// <summary>
        /// Method that handles adding the modules to the database
        /// </summary>
        /// <param name="modCode"></param>
        /// <param name="modName"></param>
        /// <param name="modCredits"></param>
        /// <param name="modClassHours"></param>
        public async void addModuleToDB(string modCode, string modName, int modCredits, double modClassHours)
        {
            //checking if student currently has same module then warning them if they proceed there will be a duplicate
            foreach (Module m in CurrentSemester.modules)
            {
                if (modCode.Equals(m.Code))
                {
                    MessageBoxResult confirmDuplication = MessageBox.Show("You are already registered with this module. Proceeding with adding this module will result in you seeing a duplicate module" +
                        "\nDo you want to proceed?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(confirmDuplication == MessageBoxResult.No)
                    {
                        return;
                    }
                } 
            }
            //checking if the module already exists in the database 
            Module mod = null;
            MessageBoxResult? confirmModuleInsertion = null;
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM Module WHERE ModCode = '{modCode}'";
                await con.OpenAsync();
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                using (SqlDataReader r = cmdSelect.ExecuteReader())
                {
                    //checking if module exists (using module code) to register student for
                    if (await r.ReadAsync())
                    {
                        //asking student if they are ok with letting the module theyve inputted be overwritten by already stored module 
                        mod = new Module(r.GetString(0), r.GetString(1), r.GetInt32(2), r.GetDouble(3));
                        confirmModuleInsertion = MessageBox.Show("Another module with this code already exists (information below). By clicking yes, you agree to the information already stored under this module code to be used rather than the information you have entered." +
                            $"\nModule Code: {mod.Code}" +
                            $"\nModule Name: {mod.Name}" +
                            $"\nNumber of Credits: {mod.NumOfCredits}" +
                            $"\nClass hours per week: {mod.ClassHoursPerWeek}", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (confirmModuleInsertion == MessageBoxResult.No)
                        {
                            txbModName.Clear();
                            txbModCode.Clear();
                            txbNumOfCredits.Clear();
                            txbClassHoursPerWeek.Clear();
                            return;
                        }
                    }
                }
                //inserting data into RegisterModule when module already exists
                if (confirmModuleInsertion == MessageBoxResult.Yes)
                {
                    string strInsert = $"INSERT INTO RegisterModule VALUES('{CurrentSemester.ID}', '{mod.Code}')";
                    SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                    await cmdInsert.ExecuteNonQueryAsync();
                    this.Close();
                    return;
                }
                //inserting data into both Module table and RegisterModule table
                //inserting new module into Module table
                string strInsert2 = $"INSERT INTO Module VALUES('{modCode}', '{modName}', {modCredits}, {modClassHours})";
                SqlCommand cmdInsert2 = new SqlCommand(strInsert2, con);
                await cmdInsert2.ExecuteNonQueryAsync();
                //inserting into RegisterModule table
                strInsert2 = $"INSERT INTO RegisterModule VALUES('{CurrentSemester.ID}', '{modCode}')";
                cmdInsert2 = new SqlCommand(strInsert2, con);
                await cmdInsert2.ExecuteNonQueryAsync();
            }
            this.Close();
        }
    }

}
