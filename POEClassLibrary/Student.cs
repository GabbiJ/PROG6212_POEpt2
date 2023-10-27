using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace POEClassLibrary
{
    internal class Student
    {
        public string Username { get; set; }
        public string Password { get; set; }
        SqlConnection con = Connections.GetConnection();


        public Student(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void registerStudent(string username, string pass)
        {
            //hashing password
            //the methods used to hash the password were done using mehotds found on https://stackoverflow.com/questions/4181198/how-to-hash-a-password
           
            //inserting data into database
            using (con)
                {
                    string strInsert = $"INSERT INTO Student VALUES('{username}', '{pass}');)";
                    con.Open();
                    SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                    cmdInsert.ExecuteNonQuery();
                }

        }

        public void login(string username, string pass)
        {

        }
    }
}
