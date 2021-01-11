using System;
using System.IO;
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


using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v2;
using Google.Apis.Util.Store;
using System.Data.SqlClient;

namespace MoneyWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public static Panel nav;
        public static string name;
        public static string user;
        public MainWindow()
        {
            InitializeComponent();
            nav = nav_pnl;
            nav_pnl.Visibility = Visibility.Hidden;
            LogIn login = new LogIn();
            main.Children.Add(login);
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_calendar.Visibility = Visibility.Collapsed;
                tt_message.Visibility = Visibility.Collapsed;         
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_calendar.Visibility = Visibility.Visible;
                tt_message.Visibility = Visibility.Visible;

                
            }
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_btn.IsChecked = false;
        }

        private void HomeNav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home homepage = new Home(user);
            if (!main.Children.Contains(homepage))
            {
                main.Children.Clear();
                main.Children.Add(homepage);
            }
        }

        private void CalendarNav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Calendar calendar = new Calendar(user);
            if (!main.Children.Contains(calendar))
            {
                main.Children.Clear();
                main.Children.Add(calendar);
            }
        }

        private void AddNav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Add add = new Add(user);
            if (!main.Children.Contains(add))
            {
                main.Children.Clear();
                main.Children.Add(add);
            }
        }

        internal static void showNav()
        {
            nav.Visibility = Visibility.Visible;
        }
    }
}
