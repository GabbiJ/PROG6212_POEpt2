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
        SqlConnection con = Connections.GetConnection();
        public AddModuleForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method that captures data and uses it to add a module to the modules list in the CurrentSemester class when the "Add" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //adding modules to database
            try
            {
                //storing the values in temporary variables
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
                    addModule(modCode, modName, (int)numOfCredits, (double)classHrsPerWeek);
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

        public void addModule(string modCode, string modName, int modCredits, double modClassHours)
        {

            Module m = null;
            using (con)
            {
                string strSelect = $"SELECT * FROM Module WHERE ModCode = '{modCode}'";
                con.Open();
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                using (SqlDataReader r = cmdSelect.ExecuteReader())
                {
                    //checking if module exists (using module code) to register student for
                    if (r.Read())
                    {
                        m = new Module(r.GetString(0), r.GetString(1), r.GetInt32(2), r.GetDouble(3));
                        MessageBoxResult confirmModuleInsertion = MessageBox.Show("Another module with this code already exists (information below). By clicking yes, you agree to the information already stored under this module code to be used rather than the information you have entered." +
                            $"\nModule Code: {m.Code}" +
                            $"\nModule Name: {m.Name}" +
                            $"\nNumber of Credits: {m.NumOfCredits}" +
                            $"\nClass hours per week: {m.ClassHoursPerWeek}", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (confirmModuleInsertion == MessageBoxResult.No)
                        {
                            txbModName.Clear();
                            txbModCode.Clear();
                            txbNumOfCredits.Clear();
                            txbClassHoursPerWeek.Clear();
                            return;
                        }
                        //inserting data into RegisterModule when module already exists
                        if (confirmModuleInsertion == MessageBoxResult.Yes)
                        {
                            string strInsert = $"INSERT INTO RegisterModule VALUES('{CurrentSemester.ID}', '{m.Code}')";
                            SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                            cmdInsert.ExecuteNonQuery();
                            this.Close();
                            return;
                        }
                    }
                }
                //inserting data into both Module table and RegisterModule table
                //inserting new module into Module table
                string strInsert2 = $"INSERT INTO Module VALUES('{modCode}', '{modName}', {modCredits}, {modClassHours})";
                SqlCommand cmdInsert2 = new SqlCommand(strInsert2, con);
                cmdInsert2.ExecuteNonQuery();
                //inserting into RegisterModule table
                strInsert2 = $"INSERT INTO RegisterModule VALUES('{CurrentSemester.ID}', '{modCode}')";
                cmdInsert2 = new SqlCommand(strInsert2, con);
                cmdInsert2.ExecuteNonQuery();

            }
            this.Close();
        }
    }

}
