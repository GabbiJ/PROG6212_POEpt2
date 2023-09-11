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
            //assigning values to labels for start date and duration of the current semester
            lblDateValue.Content = $"{CurrentSemester.StartDate.Day.ToString()} {CurrentSemester.StartDate.ToString("MMMM")} {CurrentSemester.StartDate.Year.ToString()}";
            lblDurationValue.Content = CurrentSemester.NumOfWeeks;
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
                                             m.ClassHoursPerWeek,
                                             selfStudyPerWeek = m.remainingHrsThisWeek()
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            displayDataToListView();
        }
    }
}
