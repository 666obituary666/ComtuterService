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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btncomputer_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new PageComputer());
        }

        private void btnclient_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new PageClient());
        }

        private void btnmasters_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new PageMaster());
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.GoBack();
        }

        private void MainMenuFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainMenuFrame.CanGoBack)
            {
                btnback.Visibility = Visibility.Visible;
            }
            else
            {
                btnback.Visibility = Visibility.Hidden;
            }
        }
    }
}
