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
    /// Interaction logic for GreetingPage.xaml
    /// </summary>
    public partial class GreetingPage : Window
    {
        public GreetingPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// method that opens a new SemesterInfoForm window and closes the current window when the "Let's Begin" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            SemesterInfoForm sif = new SemesterInfoForm();
            sif.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
