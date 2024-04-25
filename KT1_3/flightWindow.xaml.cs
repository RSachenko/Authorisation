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
using System.Windows.Shapes;

namespace KT1_3
{
    
    public partial class flightWindow : Window
    {
        private List<Order> ordersList;
        public flightWindow()
        {
            InitializeComponent();

            ordersList = DatabaseHelper.GetOrders();

            ordersDataGrid.ItemsSource = ordersList;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ordersDataGrid_SelectionChanged()
        {

        }

        private void ordersDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
