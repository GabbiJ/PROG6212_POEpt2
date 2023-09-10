using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    public class StudyTime
    {
        public DateTime DateCompleted { get; set; }
        public double NumOfHours { get; set; }
        public string Module { get; set; }

        public StudyTime(DateTime dateCompleted, double numOfHours, string module)
        {
            DateCompleted = dateCompleted;
            NumOfHours = numOfHours;
            Module = module;
        }
    }
}
