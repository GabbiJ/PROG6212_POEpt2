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

        public StudyTime(DateTime dateCompleted, double numOfHours)
        {
            DateCompleted = dateCompleted;
            NumOfHours = numOfHours;
        }
    }
}
