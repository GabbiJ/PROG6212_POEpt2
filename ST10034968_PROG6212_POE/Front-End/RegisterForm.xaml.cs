﻿using POEClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public async void registerStudent(string username, string pass)
        { 
            try
            {
                //hashing password
                string hashedPass = hashString(pass);
                //inserting student data into database
                using (SqlConnection con2 = Connections.GetConnection())
                {
                    string strInsert = $"INSERT INTO Student VALUES('{username}', '{hashedPass}');";
                    await con2.OpenAsync();
                    SqlCommand cmdInsert = new SqlCommand(strInsert, con2);
                    await cmdInsert.ExecuteNonQueryAsync();
                    //creating a row in current semester entity for student
                    strInsert = $"INSERT INTO CurrentSemester VALUES(NULL, NULL, '{username}');";
                    cmdInsert = new SqlCommand(strInsert, con2);
                    cmdInsert.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }

        public string hashString(string rawText)
        {
            string salt = "HU958lew8439i";
            //the methods used to hash the password were done using methods found on https://www.sean-lloyd.com/post/hash-a-string/
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                //converting string to byte array
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(rawText + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                //converting from byte to string
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hash;
            }
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //checking all fields have valid
                if (txbUsername.Text == "" || pbPassword.Password == "")
                {
                    throw new Exception("Please enter a username and password.");
                }
                //checking if username is taken
                Student s = null;
                using (SqlConnection con = Connections.GetConnection())
                {
                    //fetching user from the database that matches the inputted username
                    string strSelect = $"SELECT * FROM Student WHERE Username = '{txbUsername.Text}';";
                    await con.OpenAsync();
                    SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                    using (SqlDataReader r = cmdSelect.ExecuteReader())
                    {
                        while (await r.ReadAsync())
                        {
                            s = new Student(r.GetString(0), r.GetString(1));
                        }
                    }
                }
                if (s == null)
                {
                    registerStudent(txbUsername.Text, pbPassword.Password);
                }
                else
                {
                    throw new Exception("This username is taken.");
                }
                LoginForm lf = new LoginForm();
                lf.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }
    }
}
