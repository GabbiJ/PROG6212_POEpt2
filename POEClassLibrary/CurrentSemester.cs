using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    /// <summary>
    /// Static class that stores all data for the current semester
    /// </summary>
    public static class CurrentSemester
    {
        //Declarations
        public static int ID { get; set; }
        public static List<Module> modules = new List<Module>();
        public static List<StudyTime> selfStudyCompleted = new List<StudyTime>();
        public static int NumOfWeeks { get; set; }
        public static DateTime StartDate { get; set; }
        public static Student user = new Student();
    }
}
