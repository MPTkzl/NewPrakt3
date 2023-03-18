using System;
using System.Collections.Generic;
using System.Data;
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
using NewPrakt3.qqqDataSetTableAdapters;

namespace NewPrakt3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        usersTableAdapter users = new usersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            Users.ItemsSource = users.GetData();
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(Convert.ToInt32(NameTbx.Text), Convert.ToString(NameTbx1.Text), Convert.ToString(NameTbx2.Text));

            Users.ItemsSource = users.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object id = (Users.SelectedItem as DataRowView).Row[0];
            users.DeleteQuery(Convert.ToInt32(id));
            Users.ItemsSource = users.GetData();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow window1 = new FirstWindow();
            window1.ShowDialog();
        }
    }
}
