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

    }
}
