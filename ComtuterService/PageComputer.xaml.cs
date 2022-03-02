using ComtuterService.entity;
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

namespace ComtuterService
{
    /// <summary>
    /// Логика взаимодействия для PageComputer.xaml
    /// </summary>
    public partial class PageComputer : Page
    {
        public PageComputer()
        {
            InitializeComponent();
            dgcomputer.ItemsSource = entity.computerservicedbEntities.GetContext().Orders.ToList();
        }

        private void btneditorders_Click(object sender, RoutedEventArgs e)
        {
            addorder addorder = new addorder((sender as Button).DataContext as entity.Orders);
            addorder.Show();
            
        }

        private void btnaddorder_Click(object sender, RoutedEventArgs e)
        {
            addorder addorder = new addorder(null);
            addorder.Show();
        }

        private void btndeleteorder_Click(object sender, RoutedEventArgs e)
        {
            var orderfromremove = dgcomputer.SelectedItem as Orders;
            try
            {
                entity.computerservicedbEntities.GetContext().Orders.Remove(orderfromremove);
                entity.computerservicedbEntities.GetContext().SaveChanges();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
