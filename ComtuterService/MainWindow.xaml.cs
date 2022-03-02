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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        entity.Masters loginuser = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        public void ValidateUsers(string login, string password)
        {
            var userdb = entity.computerservicedbEntities.GetContext();
            loginuser = userdb.Masters.Where(p => p.login == login && p.password == password).FirstOrDefault();
            if (loginuser != null)
            {
                MessageBox.Show($"Добро пожаловать, {loginuser.firstname} {loginuser.patronymic}");
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль!");
            }
            
        }

        private void btnAuthUsers_Click(object sender, RoutedEventArgs e)
        {
            string login;
            string password;
            StringBuilder Error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(TxBoxLogin.Text))
                Error.Append("Введите логин");
            if (string.IsNullOrWhiteSpace(PsBoxPassword.Password))
                Error.Append("Введите пароль");
            if (Error.Length == 0)
            {
                login = TxBoxLogin.Text;
                password = PsBoxPassword.Password;
                ValidateUsers(login, password);
            }
            else
            {
                MessageBox.Show(Error.ToString());
            }
        }
    }
}
