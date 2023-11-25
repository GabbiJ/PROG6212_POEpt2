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
        /// <summary>
        /// constructor for HomeWindow
        /// </summary>
        public HomeWindow()
        {
            InitializeComponent();
            //fetching relevant data from the database and stores it in memory
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
            //reloading data from database to memory
            loadCurrentSemester();
            //displaying updated data in memory
            displayDataToListView();
        }
        /// <summary>
        /// Method that fetches data from the database and stores it in memory
        /// </summary>
        private async void loadCurrentSemester()
        {
            //fetching CurrentSemester data from database
            CurrentSemester.assignFromDB();
            //assign username value to title
            lblTitle.Content = $"{CurrentSemester.user.Username}'s Current Semester";
            //only load semester info if values are not null
            if (CurrentSemester.StartDate != null && CurrentSemester.NumOfWeeks != null)
            {
                //assign values for duration and start date of semester to relevant labels
                lblStartDate.Content = $"Start Date: {((DateTime)(CurrentSemester.StartDate)).Day.ToString()} {((DateTime)(CurrentSemester.StartDate)).ToString("MMMM")} {((DateTime)(CurrentSemester.StartDate)).Year.ToString()}";
                lblDuration.Content = $"Duration: {CurrentSemester.NumOfWeeks} weeks";
            }
        }
    }
}
