using POEClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10034968_PROG6212_POE.Front_End
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        SqlConnection con = Connections.GetConnection();
        SqlConnection con2 = Connections.GetConnection();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //checking if login credentials are correct then if correct the user is stored in memeory
                if (Login(txbUsername.Text, pbPassword.Password))
                {
                    //storing user data in memory
                    using (con2)
                    {
                        //fetching user from the database that matches the inputted username
                        string strSelect = $"SELECT * FROM Student WHERE Username = '{txbUsername.Text}';";
                        con2.Open();
                        SqlCommand cmdSelect = new SqlCommand(strSelect, con2);
                        using (SqlDataReader r = cmdSelect.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                CurrentSemester.user = new Student(r.GetString(0), r.GetString(1));
                            }
                        }
                    }
                    //closing this window and going to homepage
                    HomeWindow hw = new HomeWindow();
                    hw.Show();
                    this.Close();
                }
                else
                {
                    lblError.Content = "Username or password is incorrect.";
                }
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }

        private void HyperlinkHere_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.Show();
            this.Close();
            e.Handled = true;
        }

        public bool Login(string username, string pass)
        {
            //hashing inputted password 
            string hashedPass = hashString(pass);
            //seeing if any users match the credentials
            Student? fetchedStudent = null;
            using (con)
            {
                //fetching user from the database that matches the inputted username
                string strSelect = $"SELECT * FROM Student WHERE Username = '{username}';";
                con.Open();
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                //creating student object out of fetched data
                using (SqlDataReader r = cmdSelect.ExecuteReader())
                {
                    while (r.Read())
                    {
                        fetchedStudent = new Student(r.GetString(0), r.GetString(1));
                    }
                }
            }
            //checking if username and password match
            if (fetchedStudent == null) 
            {
                return false;
            }
            if (fetchedStudent.Username.Equals(username) && fetchedStudent.Password.Equals(hashedPass))
            {
                return true;
            }
            else
            {
                return false;
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
    }
}
