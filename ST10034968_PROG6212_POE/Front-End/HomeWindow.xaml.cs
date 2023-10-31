using POEClassLibrary;
using System;
using System.Collections.Generic;
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
using System.Threading;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ST10034968_PROG6212_POE.Front_End
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        SqlConnection con = Connections.GetConnection();
        /// <summary>
        /// constructor for HomeWindow
        /// </summary>
        public HomeWindow()
        {
            InitializeComponent();
            loadCurrentSemester();
            //displaying all modules in list view object
            displayDataToListView();
        }

        /// <summary>
        /// Displays all the modules in the list in the CurrentSemester class to the list view object 
        /// </summary>
        public void displayDataToListView()
        {
            //using a LINQ query to get modules from list in CurrentSemester class with an additional list
            //with calculated remaining study hours for the current week
            lvModules.ItemsSource = (from m in CurrentSemester.modules
                                     select new
                                     {
                                         m.Name,
                                         m.Code,
                                         m.NumOfCredits,
                                         ClassHoursPerWeek = m.ClassHoursPerWeek.ToString("F2"),
                                         TotalStudyHrsPerWeek = m.selfStudyPerWeek().ToString("F2"),
                                         selfStudyPerWeek = m.remainingHrsThisWeek().ToString("F2")
                                     }).ToList();

        }

        /// <summary>
        /// Method that allows the application to terminate when the 'Exit' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Method that opens the form to edit the current semester information when the 'Edit' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SemesterInfoForm sif = new SemesterInfoForm();
            sif.Show();
            this.Close();
        }
        /// <summary>
        /// Method that opens the form to add a module when the 'Add' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            AddModuleForm amf = new AddModuleForm();
            amf.Show();

        }
        /// <summary>
        /// Method that opens the form to add study time when the 'Add Study Time' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStudyTime_Click(object sender, RoutedEventArgs e)
        {
            AddStudyTimeForm asf = new AddStudyTimeForm();
            asf.Show();
        }
        /// <summary>
        /// Method that updates the listview with the latest stored modules when the refresh button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            loadCurrentSemester();
            displayDataToListView();
        }

        private void loadCurrentSemester()
        {
            using (SqlConnection con2 = Connections.GetConnection())
            {
                //loading current semester information from database
                string strSelect = $"SELECT * FROM CurrentSemester WHERE Username = '{CurrentSemester.user.Username}';";
                con2.Open();
                SqlCommand cmdSelect = new SqlCommand(strSelect, con2);
                using (SqlDataReader r = cmdSelect.ExecuteReader())
                {
                    if(r.Read())
                    {
                        CurrentSemester.ID = r.GetInt32(0);
                        //only assigning following values if they are present in the database
                        if (r.IsDBNull(1) == false && r.IsDBNull(2) == false)
                        {
                            CurrentSemester.StartDate = r.GetDateTime(1);
                            CurrentSemester.NumOfWeeks = r.GetInt32(2);
                            //assign values for duration and start date of semester
                            lblStartDate.Content = $"Start Date: {(CurrentSemester.StartDate).Day.ToString()} {(CurrentSemester.StartDate).ToString("MMMM")} {(CurrentSemester.StartDate).Year.ToString()}";
                            lblDuration.Content = $"Duration: {CurrentSemester.NumOfWeeks} weeks";
                        }
                    }
                    else
                    {
                        SemesterInfoForm semesterInfoForm = new SemesterInfoForm();
                        semesterInfoForm.Show();
                        this.Close();
                    }
                }
                //loading all modules from the database
                strSelect = $"SELECT * FROM Module " +
                    $"JOIN RegisterModule ON Module.ModCode = RegisterModule.ModCode " +
                    $"WHERE CurrentSemesterID = '{CurrentSemester.ID}';";
                cmdSelect = new SqlCommand(strSelect, con2);
                //list to temporarily store modules
                List<Module> tempModList = new List<Module>();
                using (SqlDataReader r = cmdSelect.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Module tempMod = new Module(r.GetString(0), r.GetString(1), r.GetInt32(2), r.GetDouble(3));
                        tempModList.Add(tempMod);
                    }
                }
                //assigning temp list to list stored in current semester
                CurrentSemester.modules = tempModList;
                //loading all study time from the database
                strSelect = $"SELECT * FROM StudyTime " +
                    $"WHERE CurrentSemesterID = '{CurrentSemester.ID}'";
                cmdSelect = new SqlCommand(strSelect, con2);
                //making temporary list to store study time  
                List<StudyTime> tempStList = new List<StudyTime>();
                using (SqlDataReader r = cmdSelect.ExecuteReader())
                {
                    while (r.Read())
                    {
                        StudyTime tempSt = new StudyTime(r.GetDateTime(1), r.GetDouble(2), r.GetString(3));
                        tempStList.Add(tempSt);
                    }
                }
                //assigning temp study time list to list stored in current semester
                CurrentSemester.selfStudyCompleted = tempStList;
            }
            //assign username value to title
            lblTitle.Content = $"{CurrentSemester.user.Username}'s Current Semester" ;
        }
    }
}
