﻿using POEClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for SemesterInfoForm.xaml
    /// </summary>
    public partial class SemesterInfoForm : Window
    {
        /// <summary>
        /// Constructor for SemesterInfoForm
        /// </summary>
        public SemesterInfoForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method that captures the data entered in the window and stores it in the database when the "Add" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //checking if correct values have been entered
                DateTime? startDate = dpStartDate.SelectedDate;
                int? numOfWeeks = Convert.ToInt32(txbWeeks.Text);
                if (startDate == null)
                {
                    throw new Exception("Please select a start date.");
                }
                else if (numOfWeeks == null) 
                {
                    throw new Exception("Please enter the number of weeks.");
                }
                else
                {
                    //entering info into the database
                    CurrentSemester.updateDB(((DateTime)startDate).ToString("yyyy-MM-dd"), (int)numOfWeeks);
                    //going back to home window
                    HomeWindow hw = new HomeWindow();
                    hw.Show();
                    this.Close();
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
    }
}
