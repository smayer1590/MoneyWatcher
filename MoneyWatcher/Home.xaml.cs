using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
namespace MoneyWatcher
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            string currentMonth = DateTime.Now.Month.ToString();
            string currentYear = DateTime.Now.Year.ToString();

            string cn_String = Properties.Settings.Default.cn;

            SqlConnection cn_connection = new SqlConnection(cn_String);

            string[] amount = new string[12];
            double max = 0;
            for (int i = 0; i < 12; ++i)
            {
                string command = "Select sum(amount) as sum from spent where YEAR(date) = @currentYear and MONTH(date) = @month;";
                string month = (i + 1).ToString();
                SqlCommand ocmd = new SqlCommand(command, cn_connection);
                ocmd.Parameters.AddWithValue("@currentYear", currentYear);
                ocmd.Parameters.AddWithValue("@month", month);
                if (cn_connection.State != ConnectionState.Open) cn_connection.Open();
                using (SqlDataReader oReader = ocmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        string sum = oReader["sum"].ToString();
                        if (string.IsNullOrEmpty(sum))
                        { 
                            amount[i] = "0";
                        }
                        else
                        {
                            amount[i] = sum;
                        }

                        if (month == currentMonth)
                            monthSpent.Text = "$ " + amount[i].Substring(0, amount[i].Length);

                    }

                }
                max = Math.Max(max, Convert.ToDouble(amount[i]));
            }

            if (max == 0)
                max = 1;
            else
                max *= 1.25;


            amount1.Text = amount[0] != "0" ? "$ " + amount[0].Substring(0, amount[0].Length) : "";
            amount2.Text = amount[1] != "0" ? "$ " + amount[1].Substring(0, amount[1].Length) : "";
            amount3.Text = amount[2] != "0" ? "$ " + amount[2].Substring(0, amount[2].Length) : "";
            amount4.Text = amount[3] != "0" ? "$ " + amount[3].Substring(0, amount[3].Length) : "";
            amount5.Text = amount[4] != "0" ? "$ " + amount[4].Substring(0, amount[4].Length) : "";
            amount6.Text = amount[5] != "0" ? "$ " + amount[5].Substring(0, amount[5].Length) : "";
            amount7.Text = amount[6] != "0" ? "$ " + amount[6].Substring(0, amount[6].Length) : "";
            amount8.Text = amount[7] != "0" ? "$ " + amount[7].Substring(0, amount[7].Length) : "";
            amount9.Text = amount[8] != "0" ? "$ " + amount[8].Substring(0, amount[8].Length) : "";
            amount10.Text = amount[9] != "0" ? "$ " + amount[9].Substring(0, amount[9].Length) : "";
            amount11.Text = amount[10] != "0" ? "$ " + amount[10].Substring(0, amount[10].Length) : "";
            amount12.Text = amount[11] != "0" ? "$ " + amount[11].Substring(0, amount[11].Length) : "";

            Bar1.Height = (Convert.ToDouble(amount[0]) / max) * ColumnBar.Height;
            Bar2.Height = (Convert.ToDouble(amount[1]) / max) * ColumnBar.Height;
            Bar3.Height = (Convert.ToDouble(amount[2]) / max) * ColumnBar.Height;
            Bar4.Height = (Convert.ToDouble(amount[3]) / max) * ColumnBar.Height;
            Bar5.Height = (Convert.ToDouble(amount[4]) / max) * ColumnBar.Height;
            Bar6.Height = (Convert.ToDouble(amount[5]) / max) * ColumnBar.Height;
            Bar7.Height = (Convert.ToDouble(amount[6]) / max) * ColumnBar.Height;
            Bar8.Height = (Convert.ToDouble(amount[7]) / max) * ColumnBar.Height;
            Bar9.Height = (Convert.ToDouble(amount[8]) / max) * ColumnBar.Height;
            Bar10.Height = (Convert.ToDouble(amount[9]) / max) * ColumnBar.Height;
            Bar11.Height = (Convert.ToDouble(amount[10]) / max) * ColumnBar.Height;
            Bar12.Height = (Convert.ToDouble(amount[11]) / max) * ColumnBar.Height;
        }
    }
}
