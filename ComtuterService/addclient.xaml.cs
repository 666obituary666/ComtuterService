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

namespace ComtuterService
{
    /// <summary>
    /// Логика взаимодействия для addclient.xaml
    /// </summary>
    public partial class addclient : Window
    {
        private entity.Clients currentClients = new entity.Clients();
        public addclient(entity.Clients selectClients)
        {
            InitializeComponent();
            DataContext = currentClients;
            if (selectClients != null)
            {
                currentClients = selectClients;
            }
            DataContext = currentClients;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            if (currentClients.id == 0)
            {
                entity.computerservicedbEntities.GetContext().Clients.Add(currentClients);
                MessageBox.Show("Новый клиент успешно добавлен!");
                PageClient pg = new PageClient();
                pg.dgclient.ItemsSource = entity.computerservicedbEntities.GetContext().Clients.ToList();
            }
            try
            {
                entity.computerservicedbEntities.GetContext().SaveChanges();
                PageClient pg = new PageClient();
                pg.dgclient.ItemsSource = entity.computerservicedbEntities.GetContext().Clients.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
