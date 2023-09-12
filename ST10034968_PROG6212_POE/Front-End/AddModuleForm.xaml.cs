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
    /// Interaction logic for AddModuleForm.xaml
    /// </summary>
    public partial class AddModuleForm : Window
    {
        public AddModuleForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method that captures data and uses it to add a module to the modules list in the CurrentSemester class when the "Add" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //adding inputted info into modules list in CurrentSemester class
            try
            {
                //storing the values in temporary variables
                string? modName = txbModName.Text;
                string? modCode = txbModCode.Text;
                int? numOfCredits = Convert.ToInt32(txbNumOfCredits.Text);
                double? classHrsPerWeek = Convert.ToInt32(txbClassHoursPerWeek.Text);
                //inputting module name
                if (modName == null)
                {
                    throw new NullReferenceException("Please enter the module name\n");
                }
                else if (modCode == null)
                {
                    throw new NullReferenceException("Please enter the module code\n");
                }
                else if (numOfCredits == null)
                {
                    throw new NullReferenceException("Please enter the number of credits\n");
                }
                else if (classHrsPerWeek == null)
                {
                    throw new NullReferenceException("Please enter class hours per week\n");
                }
                else
                {
                    CurrentSemester.modules.Add(new Module(modCode, modName, (int)numOfCredits, (double)classHrsPerWeek));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
            

        }
    }
}
