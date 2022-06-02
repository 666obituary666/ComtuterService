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
    /// Логика взаимодействия для addorder.xaml
    /// </summary>
    public partial class addorder : Window
    {
        entity.Orders currentOrder = new entity.Orders();
        public addorder(entity.Orders selectedorder)
        {
            InitializeComponent();
            DataContext = currentOrder; 
            if (selectedorder != null)
            {
                currentOrder = selectedorder;
            }
            DataContext = currentOrder;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder.id == 0) 
            {
                entity.computerservicedbEntities.GetContext().Orders.Add(currentOrder);
                MessageBox.Show("Информация о новом заказе добавлена!");
            }
            try
            {
                entity.computerservicedbEntities.GetContext().SaveChanges();                
                Manager.dgorders.ItemsSource = entity.computerservicedbEntities.GetContext().Orders.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textboxid_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

       
    }
}
