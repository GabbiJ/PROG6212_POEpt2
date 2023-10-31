using POEClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AddStudyTimeForm.xaml
    /// </summary>
    public partial class AddStudyTimeForm : Window
    {
        public AddStudyTimeForm()
        {
            InitializeComponent();
            addItemsToCmb();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //taking values inputted and adding them to studyTime array
            try
            {
                //making temporary variables to assign inputted values to
                DateTime? dateCom = dpDateCompleted.SelectedDate;
                double? hrsStudied = Convert.ToDouble(txbHours.Text);
                string modName = cmbModules.Text;
                if (dateCom == null)
                {
                    throw new Exception("Please select the date the studying was completed.");
                }
                else if (hrsStudied == null)
                {
                    throw new Exception("Please enter the amount of hours studied.");
                }
                else
                {
                    //check if date studied is in this semester
                    if (dateCom < CurrentSemester.StartDate)
                    {
                        throw new Exception("The date must be in this current semester.");
                    }
                    else
                    {
                        //retrieving module code based on module name from modules stored in memory
                        string modCode = "";
                        foreach (Module m in CurrentSemester.modules)
                        {
                            if(modName.Equals(m.Name))
                            {
                                modCode = m.Code;
                            }
                        }
                        //adding values to database
                        addStudyTimeToDB((DateTime)dateCom, (double)hrsStudied, modCode);
                    }                 
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

        public void addItemsToCmb()
        {
            foreach (Module m in CurrentSemester.modules)
            {
                cmbModules.Items.Add(m.Name);
            }
        }

        public async void addStudyTimeToDB(DateTime DateCompleted, double numOfHours, string modName)
        {
            using (SqlConnection con = Connections.GetConnection())
            {
                string strInsert = $"INSERT INTO StudyTime VALUES('{DateCompleted.ToString("yyyy-MM-dd")}', {numOfHours.ToString("F2", CultureInfo.GetCultureInfo("en-US"))}, '{modName}', {CurrentSemester.ID})";
                await con.OpenAsync();
                SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                await cmdInsert.ExecuteNonQueryAsync();
            }
            this.Close();
        }
    }
}
