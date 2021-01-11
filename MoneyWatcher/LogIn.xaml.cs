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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace MoneyWatcher
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();

        }

        private void signUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignUp signUp = new SignUp();
            ((Panel)this.Parent).Children.Add(signUp);
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            bool correctInput;
            //User Name Check
            if (String.IsNullOrEmpty(user.Text))
            {
                noUser.Visibility = Visibility.Visible;
                correctInput = false;
            }
            else
            {
                noUser.Visibility = Visibility.Hidden;
                correctInput = true;
            }

            //Password Check
            if (String.IsNullOrEmpty(password.Password.ToString()))
            {
                noPwd.Visibility = Visibility.Visible;
                correctInput = false;
            }
            else
            {
                noPwd.Visibility = Visibility.Hidden;
                correctInput = true;
            }

            //If all input are correct
            if (correctInput)
            {
                string cn_String = Properties.Settings.Default.cn;
                SqlConnection cn_connection = new SqlConnection(cn_String);
                cn_connection.Open();

                string command = "select * from [dbo].[userInfo] where [user] = @username and [password] = @pwd;";
                SqlCommand ocmd = new SqlCommand(command, cn_connection);
                ocmd.Parameters.AddWithValue("@username", user.Text);
                ocmd.Parameters.AddWithValue("@pwd", password.Password.ToString());

                
                SqlDataReader sqlReader = ocmd.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    noUserFound.Visibility = Visibility.Hidden;

                    sqlReader.Read();
                    string name = sqlReader["name"].ToString();
                    string user = sqlReader["user"].ToString();
                    MainWindow.showNav();
                    MainWindow.name = name;
                    MainWindow.user = user;

                    Home home = new Home(user);
                    ((Panel)this.Parent).Children.Add(home);
                    ((Panel)this.Parent).Children.Remove(this);
                    sqlReader.Close();
                }
                else
                {
                    noUserFound.Visibility = Visibility.Visible;
                    sqlReader.Close();
                }
            }
        }
    }
}
