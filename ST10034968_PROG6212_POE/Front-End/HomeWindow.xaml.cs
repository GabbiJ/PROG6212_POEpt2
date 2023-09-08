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
            lblDateValue.Content = $"{CurrentSemester.StartDate.Day.ToString()} {CurrentSemester.StartDate.ToString("MMMM")} {CurrentSemester.StartDate.Year.ToString()}";
            lblDurationValue.Content = CurrentSemester.NumOfWeeks;
        }
    }
}
