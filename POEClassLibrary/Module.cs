using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    public class Module
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int NumOfCredits { get; set; }
        public int ClassHoursPerWeek { get; set; }

        public Module(string code, string name, int numOfCredits, int classHoursPerWeek)
        {
            Code = code;
            Name = name;
            NumOfCredits = numOfCredits;
            ClassHoursPerWeek = classHoursPerWeek;
        }

        public double remainingHrsThisWeek()
        {
            //calculating how many self study hours there are for the module per week
            double result = this.selfStudyPerWeek();
            //calculating amount of self study hours since the last monday (taking monday as the beginning of the week) of the machines current day 
            //calculating last monday
            int daysSinceLastMonday = ((((int)DateTime.Now.DayOfWeek - (int)DayOfWeek.Monday) + 7) % 7);
            DateTime lastMondayDate = (DateTime.Now.AddDays(-daysSinceLastMonday));
            //adding all self study hours since last monday to a list using a LINQ query
            double totalSelfStudyHrsThisWeek = (from st in CurrentSemester.selfStudyCompleted
                                                where st.DateCompleted >= lastMondayDate.Date && st.DateCompleted <= DateTime.Now && st.Module.Equals( this.Name) 
                                                select st.NumOfHours).ToList().Sum();
            return result -= totalSelfStudyHrsThisWeek;
        }

        public double selfStudyPerWeek() => ((this.NumOfCredits * 10) / CurrentSemester.NumOfWeeks) - this.ClassHoursPerWeek;

    }
}
