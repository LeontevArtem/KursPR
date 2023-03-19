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

namespace CarRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public MainWindow mainWindow;
        public bool IsLoginedIn;

        WpfControlLibrary1.BeautifulTextBox Login = new WpfControlLibrary1.BeautifulTextBox("Логин");
        WpfControlLibrary1.BeautifulPasswordBox Password = new WpfControlLibrary1.BeautifulPasswordBox();
        public LogIn(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow= mainWindow;

            Login.SetBackground(Color.FromRgb(255,255,255));
            Login.VerticalAlignment = VerticalAlignment.Top;
            Login.HorizontalAlignment = HorizontalAlignment.Center;
            Login.Margin = new Thickness(0,300,0,0);
            Login.Width= 300;
            parrent.Children.Add(Login);

            Password.SetBackground(Color.FromRgb(255, 255, 255));
            Password.VerticalAlignment = VerticalAlignment.Top;
            Password.HorizontalAlignment = HorizontalAlignment.Center;
            Password.Margin = new Thickness(0, 370, 0, 0);
            Password.Width = 300;
            parrent.Children.Add(Password);
            
            WpfControlLibrary1.CustomButton1 LogInButton = new WpfControlLibrary1.CustomButton1("Вход",Color.FromRgb(0,0,0),Color.FromRgb(144,147,148),Color.FromRgb(200,200,200));
            LogInButton.Width = 300;
            LogInButton.VerticalAlignment= VerticalAlignment.Top;
            LogInButton.HorizontalAlignment = HorizontalAlignment.Left;
            LogInButton.Margin = new Thickness(50, 410, 0, 0);
            LogInButton.MouseDown += LogInClick;
            parrent.Children.Add(LogInButton);

            WpfControlLibrary1.CustomButton1 SignInButton = new WpfControlLibrary1.CustomButton1("Регистрация");
            SignInButton.Width = 140;
            SignInButton.VerticalAlignment = VerticalAlignment.Top;
            SignInButton.HorizontalAlignment = HorizontalAlignment.Right;
            SignInButton.Margin = new Thickness(0, 450, 50, 0);
            parrent.Children.Add(SignInButton);

            WpfControlLibrary1.CustomButton1 ConnectionButton = new WpfControlLibrary1.CustomButton1("Настройка подключения");
            ConnectionButton.SetFontSize(10);
            ConnectionButton.Width = 140;
            ConnectionButton.VerticalAlignment = VerticalAlignment.Top;
            ConnectionButton.HorizontalAlignment = HorizontalAlignment.Left;
            ConnectionButton.Margin = new Thickness(50, 450, 0, 0);
            parrent.Children.Add(ConnectionButton);

        }
        public void LogInClick(object sender,RoutedEventArgs args)
        {
            IsLoginedIn= false;
            Login.HideErrorMessage();
            Password.HideErrorMessage();
            string login = Login.GetText();
            string password = Password.GetText();
            foreach (Classes.User curUser in mainWindow.UsersList)
            {
                if (curUser.UserLogin == login && curUser.UserPassword == password)
                {
                    MainWindow.CurrentUser.idUser = curUser.idUser;
                    MainWindow.CurrentUser.UserLogin = curUser.UserLogin;
                    MainWindow.CurrentUser.UserPassword = curUser.UserPassword;
                    MainWindow.CurrentUser.UserStatus = curUser.UserStatus;
                    MainWindow.CurrentUser.UserName = curUser.UserName;
                    MainWindow.CurrentUser.UserPhone = curUser.UserPhone;
                    MainWindow.CurrentUser.UserPassport = curUser.UserPassport;
                    MainWindow.CurrentUser.UserMail = curUser.UserMail;
                    MainWindow.CurrentUser.UserDateOfBitrh = curUser.UserDateOfBitrh;
                    MainWindow.CurrentUser.UserDriverLicense = curUser.UserDriverLicense;
                    IsLoginedIn = true;
                }
            }
            if (IsLoginedIn) mainWindow.OpenPage(mainWindow,new Pages.Main(mainWindow));
            else
            {
                Login.ShowErrorMessage("Неверный логин");
                Password.ShowErrorMessage("Неверный пароль");
            }
        }
    }
}
