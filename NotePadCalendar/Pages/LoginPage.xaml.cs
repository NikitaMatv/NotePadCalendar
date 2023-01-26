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

namespace NotePadCalendar.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login != null)
                TbLogin.Text = Properties.Settings.Default.Login;
            if (Properties.Settings.Default.Password != null)
                PbPassword.Password = Properties.Settings.Default.Password;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(x => x.Login == TbLogin.Text);
            
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                errorMessage += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                errorMessage += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
                errorMessage = "";
            }
            if (user == null)
            {
                errorMessage += "Пользователя не существует\n";
            }          
          else  if (user.Password != PbPassword.Password)
            {
                errorMessage += "Пароль неверный\n";
            }
            
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (SaveCb.IsChecked == true)
            {
                Properties.Settings.Default.Login = TbLogin.Text;
                Properties.Settings.Default.Password = PbPassword.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Login = null;
                Properties.Settings.Default.Password = null;
                Properties.Settings.Default.Save();
            }
            App.LoggedUser = user;
            NavigationService.Navigate(new MainPage());
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
