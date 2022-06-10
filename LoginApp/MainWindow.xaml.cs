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
using System.IO;
using System.Text.Json;

namespace LoginApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //File.Create("person.json");
            //var users = JsonSerializer.Deserialize<User>(File.ReadAllText("/person.json"));
            //var user = new User
            //{
            //    Login = "test",
            //    Password = "test",
            //};

            //string jsonString = JsonSerializer.Serialize<User>(user);

            //Console.WriteLine(jsonString);
            // если файла нет. то создаем
            //Console.WriteLine(File.)
            //if (!File.Exists("users.txt")) File.Create("users.txt");

            //var users = File.ReadAllText("users.txt");
            //Console.WriteLine(users);
            
            InitializeComponent();

        }
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
            DragMove();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            string login = userNameTxtBox.Text.Trim();
            string pass = passwordTxtBox.Password.Trim();
            Console.Write(login);
            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass)) MessageBox.Show("Введите логин и пароль!");
            try
            {
                User? user = User.FindUserOrLogin(login, pass);
                ListUser test = new ListUser();
                
            
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

                ListUser test = new ListUser();
                test.Add(user); 

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
