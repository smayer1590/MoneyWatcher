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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string category;
            category = String.IsNullOrEmpty(categoryText.Text) ? "etc." : categoryText.Text;

            if (String.IsNullOrEmpty(Amount.Text))
            {
                Console.WriteLine("Empty");
                MessageBox.Show("Amount cannot be empty!");
            }
        }
    }
}
