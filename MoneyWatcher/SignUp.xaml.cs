using System;
using System.Collections.Generic;
using System.Data;
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

namespace MoneyWatcher
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }


        private void back_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            ((Panel)this.Parent).Children.Add(logIn);
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            bool correctInput;

            //User Name Check
            if (String.IsNullOrEmpty(name.Text))
            {
                noName.Visibility = Visibility.Visible;
                correctInput = false;
            }
            else
            {
                noName.Visibility = Visibility.Hidden;
                correctInput = true;
            }

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
                using (SqlConnection cn_connection = new SqlConnection(cn_String))
                {
                    cn_connection.Open();

                    string findCommand = "select * from [dbo].[userInfo] where [user] = @userId";
                    using (SqlCommand findSql = new SqlCommand(findCommand, cn_connection))
                    {
                        findSql.Parameters.AddWithValue("@userId", user.Text);

                        SqlDataReader oReader = findSql.ExecuteReader();

                        if (oReader.HasRows)
                        {
                            userExists.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            userExists.Visibility = Visibility.Hidden;
                            oReader.Close();

                            string inserCommand = "insert into [dbo].[userInfo] values (@user,@password,@name);";
                            using (SqlCommand insertSql = new SqlCommand(inserCommand, cn_connection))
                            {
                                insertSql.Parameters.AddWithValue("@user", user.Text);
                                insertSql.Parameters.AddWithValue("@password", password.Password.ToString());
                                insertSql.Parameters.AddWithValue("@name", name.Text);

                                insertSql.ExecuteNonQuery();

                                LogIn logIn = new LogIn();
                                ((Panel)this.Parent).Children.Add(logIn);
                                ((Panel)this.Parent).Children.Remove(this);
                            }
                                


                        }
                    }
                    
                }
                

                
                
            }
        }
    }
}
