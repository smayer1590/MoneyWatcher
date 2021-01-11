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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        string user;
        public Calendar(string user)
        {
            InitializeComponent();
            this.user = user;
            calendar.SelectedDate = DateTime.Today;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            dateText.Text = calendar.SelectedDate.Value.ToString("yyyy-MM-dd");

            string cn_String = Properties.Settings.Default.cn;
            SqlConnection cn_connection = new SqlConnection(cn_String);

            string command = "SELECT [category] as Category, sum([amount]) as Total_Spent FROM [dbo].[spent] where YEAR([date]) = @year and MONTH([date]) = @month and DAY(date) = @day and [user] = @username group by [category]";
            SqlDataAdapter dataadapter = new SqlDataAdapter(command, cn_connection);
            dataadapter.SelectCommand.Parameters.AddWithValue("@year", calendar.SelectedDate.Value.ToString("yyyy"));
            dataadapter.SelectCommand.Parameters.AddWithValue("@month", calendar.SelectedDate.Value.ToString("MM"));
            dataadapter.SelectCommand.Parameters.AddWithValue("@day", calendar.SelectedDate.Value.ToString("dd"));
            dataadapter.SelectCommand.Parameters.AddWithValue("@username", user);

            DataSet ds = new DataSet();
            cn_connection.Open();
            dataadapter.Fill(ds, "sum");
            cn_connection.Close();
          
            spentResult.ItemsSource = ds.Tables["sum"].DefaultView;

            string sumAmount = ds.Tables["sum"].Compute("Sum(Total_Spent)", "").ToString();
            TotalText.Text = String.IsNullOrEmpty(sumAmount) ? "$ 0.00" : "$ " + sumAmount.Substring(0, sumAmount.Length);
        }

        private void calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            /*
            if (calendar.DisplayMode.ToString() == "Year")
            {
                dateText.Text = calendar.DisplayDate.ToString("yyyy");

                string cn_String = Properties.Settings.Default.cn;
                SqlConnection cn_connection = new SqlConnection(cn_String);

                string command = "SELECT MONTH(date) as Month, sum(amount) as Total_Spent FROM spent where YEAR(date) = " + calendar.DisplayDate.ToString("yyyy") + " group by MONTH(date) order by MONTH(date) ASC";

                SqlDataAdapter dataadapter = new SqlDataAdapter(command, cn_connection);
                DataSet ds = new DataSet();
                cn_connection.Open();
                dataadapter.Fill(ds, "sum");
                cn_connection.Close();
                spentResult.ItemsSource = ds.Tables["sum"].DefaultView;

                string sumAmount = ds.Tables["sum"].Compute("Sum(Total_Spent)", "").ToString();
                TotalText.Text = String.IsNullOrEmpty(sumAmount) ? "$ 0.00" : "$ " + sumAmount.Substring(0, sumAmount.Length);
            }
            else 
            {
                
                if (!calendar.SelectedDate.HasValue || calendar.SelectedDate.Value.ToString("yyyy-MM") == e.RemovedDate.Value.ToString("yyyy-MM"))
                {
                    dateText.Text = calendar.DisplayDate.ToString("yyyy-MM");

                    string cn_String = Properties.Settings.Default.cn;
                    SqlConnection cn_connection = new SqlConnection(cn_String);

                    string command = "SELECT convert(varchar(10),date,101) as Date, sum(amount) as Total_Spent FROM spent where YEAR(date) = " + calendar.DisplayDate.ToString("yyyy") + " and MONTH(date) = " + calendar.DisplayDate.ToString("MM") + " group by date order by date ASC";

                    SqlDataAdapter dataadapter = new SqlDataAdapter(command, cn_connection);
                    DataSet ds = new DataSet();
                    cn_connection.Open();
                    dataadapter.Fill(ds, "sum");
                    cn_connection.Close();
                    spentResult.ItemsSource = ds.Tables["sum"].DefaultView;

                    string sumAmount = ds.Tables["sum"].Compute("Sum(Total_Spent)", "").ToString();
                    TotalText.Text = String.IsNullOrEmpty(sumAmount) ? "$ 0.00" : "$ " + sumAmount.Substring(0, sumAmount.Length);
                }
            }
            */
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            /*
            if (calendar.DisplayMode.ToString() == "Year")
            {
                dateText.Text = calendar.DisplayDate.ToString("yyyy");

                string cn_String = Properties.Settings.Default.cn;
                SqlConnection cn_connection = new SqlConnection(cn_String);

                string command = "SELECT MONTH(date) as Month, sum(amount) as Total_Spent FROM spent where YEAR(date) = " + calendar.DisplayDate.ToString("yyyy") + " group by MONTH(date) order by MONTH(date) ASC";

                SqlDataAdapter dataadapter = new SqlDataAdapter(command, cn_connection);
                DataSet ds = new DataSet();
                cn_connection.Open();
                dataadapter.Fill(ds, "sum");
                cn_connection.Close();
                spentResult.ItemsSource = ds.Tables["sum"].DefaultView;

                string sumAmount = ds.Tables["sum"].Compute("Sum(Total_Spent)", "").ToString();
                TotalText.Text = String.IsNullOrEmpty(sumAmount) ? "$ 0.00" : "$ " + sumAmount.Substring(0, sumAmount.Length);
            }
            else 
            {
                
                if (!calendar.SelectedDate.HasValue || calendar.SelectedDate.Value.ToString("yyyy-MM") == e.RemovedDate.Value.ToString("yyyy-MM"))
                {
                    dateText.Text = calendar.DisplayDate.ToString("yyyy-MM");

                    string cn_String = Properties.Settings.Default.cn;
                    SqlConnection cn_connection = new SqlConnection(cn_String);

                    string command = "SELECT convert(varchar(10),date,101) as Date, sum(amount) as Total_Spent FROM spent where YEAR(date) = " + calendar.DisplayDate.ToString("yyyy") + " and MONTH(date) = " + calendar.DisplayDate.ToString("MM") + " group by date order by date ASC";

                    SqlDataAdapter dataadapter = new SqlDataAdapter(command, cn_connection);
                    DataSet ds = new DataSet();
                    cn_connection.Open();
                    dataadapter.Fill(ds, "sum");
                    cn_connection.Close();
                    spentResult.ItemsSource = ds.Tables["sum"].DefaultView;

                    string sumAmount = ds.Tables["sum"].Compute("Sum(Total_Spent)", "").ToString();
                    TotalText.Text = String.IsNullOrEmpty(sumAmount) ? "$ 0.00" : "$ " + sumAmount.Substring(0, sumAmount.Length);
                }
            }
            */
        }
    }
    }
