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
using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace LoginApp
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {

        public Auth()
        {
            InitializeComponent();
        }
        static List<User> users = new List<User>();
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            string login = userNameTxtBox.Text.Trim();
            string pass = passwordTxtBox.Password.Trim();
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass)) MessageBox.Show("Введите логин и пароль!");
            try
            {
                var findUser = users.Find(user => user.Login == login && user.Password == pass);
                if (findUser == null)
                {
                    MessageBox.Show("Пользователь не найден.");
                    return;
                }
                        MessageBox.Show("Авторизация выполнена");
                // смена фотографии на главной панели
                        string dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                        LogoLogin.Source = BitmapFrame.Create(new Uri($"{dir}/Resources/logo.png"));
            }
            catch (ArgumentException error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = userNameTxtBox.Text.Trim();
            string pass = passwordTxtBox.Password.Trim();

            if (login.Length < 5)
            {
                userNameTxtBox.ToolTip = "Поле введено не верно";
                userNameTxtBox.Background = Brushes.Red;
            }
            else

            if (pass.Length < 6)
            {
                passwordTxtBox.ToolTip = "Пароль должен содержать не менее 6 символов";
                passwordTxtBox.Background = Brushes.Red;
            }
            else
            {
                // сохраняем пользователя
                User user = new User()
                {
                    Password = pass,
                    Login = login,
                };

                // добавляем пользователя
                users.Add(user);

                userNameTxtBox.ToolTip = "";
                userNameTxtBox.Background = Brushes.Transparent;

                passwordTxtBox.ToolTip = "";
                passwordTxtBox.Background = Brushes.Transparent;
                // блокируем кнопку регистрации
                RegisterButton.IsEnabled = false;
                MessageBox.Show("Регистрация прошла успешно, теперь вы можете войти указав логин и пароль.");
            }
        }
    }
}
