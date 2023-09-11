using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    /// <summary>
    /// Class that stores an individual study time sessions information
    /// </summary>
    public class StudyTime
    {
        public DateTime DateCompleted { get; set; }
        public double NumOfHours { get; set; }
        public string Module { get; set; }

        /// <summary>
        /// Constructor that assignes data to all StudyTime properties 
        /// </summary>
        /// <param name="dateCompleted">The date the study time was completed</param>
        /// <param name="numOfHours">The number of hours studied</param>
        /// <param name="module">The name of the module studied</param>
        public StudyTime(DateTime dateCompleted, double numOfHours, string module)
        {
            DateCompleted = dateCompleted;
            NumOfHours = numOfHours;
            Module = module;
        }
    }
}
