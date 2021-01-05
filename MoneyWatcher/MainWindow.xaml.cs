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

namespace MoneyWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Home homepage = new Home();
            main.Children.Add(homepage);
        }

        private void Tg_btn_Checked(object sender, RoutedEventArgs e)
        {

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CalendarNav_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void HomeNav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home homepage = new Home();
            if (!main.Children.Contains(homepage))
            {
                main.Children.Clear();
                main.Children.Add(homepage);
            }
        }

        private void CalendarNav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Calendar calendar = new Calendar();
            if (!main.Children.Contains(calendar))
            {
                main.Children.Clear();
                main.Children.Add(calendar);
            }
        }

        private void AddNav_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Add add = new Add();
            if (!main.Children.Contains(add))
            {
                main.Children.Clear();
                main.Children.Add(add);
            }
        }
    }
}
