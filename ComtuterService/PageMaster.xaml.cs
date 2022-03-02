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
    /// Логика взаимодействия для PageMaster.xaml
    /// </summary>
    public partial class PageMaster : Page
    {
        public PageMaster()
        {
            InitializeComponent();
            dgmasters.ItemsSource = entity.computerservicedbEntities.GetContext().Masters.ToList();
        }

     
        private void btneditmasters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnaddmasters_Click(object sender, RoutedEventArgs e)
        {
            addmasters addmasters = new addmasters(null);
            addmasters.Show();
        }

        private void btndeletemasters_Click(object sender, RoutedEventArgs e)
        {
            var Mastersfromremove = dgmasters.SelectedItem as Masters;
            try
            {
                entity.computerservicedbEntities.GetContext().Masters.Remove(Mastersfromremove);
                entity.computerservicedbEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
