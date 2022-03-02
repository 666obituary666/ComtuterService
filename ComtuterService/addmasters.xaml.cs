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
    /// Логика взаимодействия для addmasters.xaml
    /// </summary>
    public partial class addmasters : Window
    {
        private entity.Masters currentMaster = new entity.Masters();
        public addmasters(entity.Masters selectMaster)
        {
            InitializeComponent();
            DataContext = currentMaster;
            if (selectMaster != null)
            {
                currentMaster = selectMaster;
            }
            DataContext = currentMaster;
        }

        private void btnaddmasters_Click(object sender, RoutedEventArgs e)
        {
            if (currentMaster.id == 0)
            {
                entity.computerservicedbEntities.GetContext().Masters.Add(currentMaster);
                MessageBox.Show("Новый сотрудник сервиса успешно добавлен!");
                PageMaster pg = new PageMaster();
                pg.dgmasters.ItemsSource = entity.computerservicedbEntities.GetContext().Masters.ToList();
            }
            try
            {
                entity.computerservicedbEntities.GetContext().SaveChanges();
                PageMaster pg = new PageMaster();
                pg.dgmasters.ItemsSource = entity.computerservicedbEntities.GetContext().Masters.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
