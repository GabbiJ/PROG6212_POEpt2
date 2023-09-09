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
        public HomeWindow()
        {
            InitializeComponent();
            //assigning values to labels for start date and duration of the current semester
            lblDateValue.Content = $"{CurrentSemester.StartDate.Day.ToString()} {CurrentSemester.StartDate.ToString("MMMM")} {CurrentSemester.StartDate.Year.ToString()}";
            lblDurationValue.Content = CurrentSemester.NumOfWeeks;
            displayDataToListView();
        }

        public void displayDataToListView()
        {
            //using a LINQ query to get modules from list in CurrentSemester class and assign to list view 
            lvModules.ItemsSource = (from m in CurrentSemester.modules
                                     select m).ToList();


        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SemesterInfoForm sif = new SemesterInfoForm();
            sif.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddModuleForm amf = new AddModuleForm();
            amf.Show();
        }

        private void btnAddStudyTime_Click(object sender, RoutedEventArgs e)
        {
            AddStudyTimeForm asf = new AddStudyTimeForm();
            asf.Show();
        }
    }
}
