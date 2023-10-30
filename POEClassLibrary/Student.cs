using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel.Design;

namespace POEClassLibrary
{
    /// <summary>
    /// This class contains information pertaining to a user (student) and relevant methods for logging in and registering a user using the database
    /// </summary>
    public class Student
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Student(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Student() { }
    }
}
