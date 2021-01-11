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

namespace MoneyWatcher
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        string user;
        public Add(string user)
        {
            this.user = user;
            InitializeComponent();

            successful.Visibility = Visibility.Hidden;
            date.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string categoryText;
            categoryText = String.IsNullOrEmpty(category.Text) ? "etc." : category.Text;

            bool correctInput;
            
            decimal number = 0;
            if (String.IsNullOrEmpty(amount.Text))
            {
                noAmount.Visibility = Visibility.Visible;
                correctInput = false;
            }
            else 
            {
                noAmount.Visibility = Visibility.Hidden;
                
                if (Decimal.TryParse(amount.Text, out number))
                {
                    notDecimal.Visibility = Visibility.Hidden;
                    correctInput = true;
                }
                else
                {
                    notDecimal.Visibility = Visibility.Visible;
                    correctInput = false;
                }
            }

            
            if (correctInput)
            {
                string cn_String = Properties.Settings.Default.cn;
                using (SqlConnection cn_connection = new SqlConnection(cn_String))
                {
                    cn_connection.Open();

                    string inserCommand = "insert into [dbo].[spent] ([user], [category], [amount], [date]) values (@user,@category,@amount, @date);";
                    using (SqlCommand insertSql = new SqlCommand(inserCommand, cn_connection))
                    {
                        insertSql.Parameters.AddWithValue("@user", user);
                        insertSql.Parameters.AddWithValue("@category", categoryText);
                        insertSql.Parameters.AddWithValue("@amount", number);
                        insertSql.Parameters.AddWithValue("@date", date.SelectedDate);

                        insertSql.ExecuteNonQuery();

                        successful.Visibility = Visibility.Visible;
                    }

                }
            }
        }
    }
}
