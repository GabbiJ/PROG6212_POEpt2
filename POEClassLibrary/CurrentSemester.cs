using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    public static class CurrentSemester
    {
        //Declarations
        public static List<Module> modules = new List<Module>{new Module("PROG612", "Programming", 16, 10),
                new Module("CLDV6221", "Cloud Computing", 16, 15) };
        public static List<StudyTime> selfStudyCompleted = new List<StudyTime>();
        public static int NumOfWeeks { get; set; }
        public static DateTime StartDate { get; set; }

        public static double NumOfHoursPerWeek(Module m)
        {
            return ((m.NumOfCredits * 10)/ NumOfWeeks) - m.ClassHoursPerWeek;
        }
    }
}
