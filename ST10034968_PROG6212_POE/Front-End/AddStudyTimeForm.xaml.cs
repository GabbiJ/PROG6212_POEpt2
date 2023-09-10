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
                string mod = cmbModules.Text;
                if (dateCom == null)
                {
                    new NullReferenceException("Please select the date the studying was completed.");
                }
                else if (hrsStudied == null)
                {
                    new NullReferenceException("Please enter the amount of hours studied.");
                }
                else
                {
                    //adding values to StudyTime list in CurrentSemester class
                    CurrentSemester.selfStudyCompleted.Add(new StudyTime((DateTime)dateCom, (double)hrsStudied, mod));
                    this.Close();
                }
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
    }
}
