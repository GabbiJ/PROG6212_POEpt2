﻿using POEClassLibrary;
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
        /// Method that captures the data entered in the window and stores it in CurrentSemester class when the "Add" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //assigning start date value
                DateTime? startDate = dpStartDate.SelectedDate;
                if (startDate == null)
                {
                    throw new Exception("Please select a start date.");
                }
                else
                {
                    CurrentSemester.StartDate = (DateTime)startDate;
                }
                //assigning number weeks value and closing window and going to home window
                int? numOfWeeks = Convert.ToInt32(txbWeeks.Text);
                if (numOfWeeks == null) 
                {
                    throw new Exception("Please enter the number of weeks.");
                }
                else
                {
                    CurrentSemester.NumOfWeeks = (int)numOfWeeks;
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
