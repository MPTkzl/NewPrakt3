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
using System.Windows.Shapes;
using NewPrakt3.qqqDataSetTableAdapters;

namespace NewPrakt3
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        zakaziTableAdapter zakazi = new zakaziTableAdapter();
        usersTableAdapter users = new usersTableAdapter();
        int id = 0;
        public FirstWindow()
        {
            InitializeComponent();
            Zakazi.ItemsSource = zakazi.GetData();
            userCb.ItemsSource = users.GetData();
            userCb.DisplayMemberPath = "name";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zakazi.InsertQuery(Convert.ToInt32(NameTbx.Text), id, Convert.ToDecimal(NameTbx2.Text));
            Zakazi.ItemsSource = zakazi.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (Zakazi.SelectedItem as DataRowView).Row[0];
            zakazi.DeleteQuery(Convert.ToInt32(id));
            Zakazi.ItemsSource = zakazi.GetData();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void userCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (userCb.SelectedItem as DataRowView).Row[0];
            id = Convert.ToInt32(cell);
        }

        
    }
}
