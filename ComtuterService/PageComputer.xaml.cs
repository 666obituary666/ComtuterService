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
            Manager.dgorders = dgcomputer;
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
                Manager.dgorders.ItemsSource = entity.computerservicedbEntities.GetContext().Orders.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdComputerTable()
        {
            var currentComputer = computerservicedbEntities.GetContext().Orders.ToList();
            currentComputer = currentComputer.Where(p => p.Cause.ToLower().Contains(tbSearchWork.Text.ToLower())).ToList();
            switch (cbStatus.SelectedIndex)
            {
                case 0:
                    currentComputer = currentComputer.Where(p => p.Status == "Создано").ToList();
                    break;
                case 1:
                    currentComputer = currentComputer.Where(p => p.Status == "В работе").ToList();
                    break;
                case 2:
                    currentComputer = currentComputer.Where(p => p.Status == "Готово к выдаче").ToList();
                    break;
            }
            dgcomputer.ItemsSource = currentComputer;
        }

        private void tbSearchWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdComputerTable();
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdComputerTable();
        }
    }
}
