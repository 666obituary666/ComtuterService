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
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public PageClient()
        {
            InitializeComponent();
            dgclient.ItemsSource = entity.computerservicedbEntities.GetContext().Clients.ToList();
        }

        private void btndeleteclient_Click(object sender, RoutedEventArgs e)
        {
            var clientsfromremove = dgclient.SelectedItem as Clients;
            try
            {
                entity.computerservicedbEntities.GetContext().Clients.Remove(clientsfromremove);
                entity.computerservicedbEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnaddclient_Click(object sender, RoutedEventArgs e)
        {
            addclient addclient = new addclient(null);
            addclient.Show();
        }

        private void btneditclient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
