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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        MainWindow mainWindow;
        Page parrentPage;
        Classes.User curUser;
        WpfControlLibrary1.ImageBrowser Image = new WpfControlLibrary1.ImageBrowser();
        WpfControlLibrary1.BeautifulTextBox Login = new WpfControlLibrary1.BeautifulTextBox("LogIn");
        WpfControlLibrary1.BeautifulTextBox Password = new WpfControlLibrary1.BeautifulTextBox("Password");
        WpfControlLibrary1.Switch Status = new WpfControlLibrary1.Switch();
        WpfControlLibrary1.BeautifulTextBox UserName = new WpfControlLibrary1.BeautifulTextBox("UserName");
        WpfControlLibrary1.BeautifulTextBox Phone = new WpfControlLibrary1.BeautifulTextBox("Phone");
        WpfControlLibrary1.BeautifulTextBox Passport = new WpfControlLibrary1.BeautifulTextBox("Passport");
        WpfControlLibrary1.BeautifulTextBox DateOfBirth = new WpfControlLibrary1.BeautifulTextBox("DateOfBirth");
        WpfControlLibrary1.BeautifulTextBox Mail = new WpfControlLibrary1.BeautifulTextBox("Mail");
        WpfControlLibrary1.BeautifulTextBox DriverLicense = new WpfControlLibrary1.BeautifulTextBox("DriverLicense");
        string userStatus = "user";
        public UserPage(MainWindow mainWindow,Page parrentPage,Classes.User curUser = null,string Mode = null)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.parrentPage = parrentPage;
            this.curUser = curUser;

            Image.VerticalAlignment = VerticalAlignment.Top;
            Image.HorizontalAlignment = HorizontalAlignment.Left;
            Image.Margin = new Thickness(10);
            Image.Width = 400;
            Image.Height = 450;
            parrent.Children.Add(Image);

            Login.VerticalAlignment = VerticalAlignment.Top;
            Login.Margin = new Thickness(420,10,10,0);
            parrent.Children.Add(Login);

            Password.VerticalAlignment = VerticalAlignment.Top;
            Password.Margin = new Thickness(420, 50, 10, 0);
            parrent.Children.Add(Password);

            Status.VerticalAlignment = VerticalAlignment.Top;
            Status.Margin = new Thickness(490,95,10,0);
            Status.HorizontalAlignment = HorizontalAlignment.Left;
            Status.MouseDown += Switch;
            parrent.Children.Add(Status);

            UserName.VerticalAlignment = VerticalAlignment.Top;
            UserName.Margin = new Thickness(420, 130, 10, 0);
            parrent.Children.Add(UserName);

            Phone.VerticalAlignment = VerticalAlignment.Top;
            Phone.Margin = new Thickness(420, 170, 10, 0);
            parrent.Children.Add(Phone);

            Passport.VerticalAlignment = VerticalAlignment.Top;
            Passport.Margin = new Thickness(420, 210, 10, 0);
            parrent.Children.Add(Passport);

            DateOfBirth.VerticalAlignment = VerticalAlignment.Top;
            DateOfBirth.Margin = new Thickness(420, 250, 10, 0);
            parrent.Children.Add(DateOfBirth);

            Mail.VerticalAlignment = VerticalAlignment.Top;
            Mail.Margin = new Thickness(420, 290, 10, 0);
            parrent.Children.Add(Mail);

            DriverLicense.VerticalAlignment = VerticalAlignment.Top;
            DriverLicense.Margin = new Thickness(420, 330, 10, 0);
            parrent.Children.Add(DriverLicense);

            WpfControlLibrary1.CustomButton1 SignUp =   new WpfControlLibrary1.CustomButton1("Зарегестрироваться");
            SignUp.VerticalAlignment = VerticalAlignment.Bottom;
            SignUp.HorizontalAlignment = HorizontalAlignment.Left;
            SignUp.Margin = new Thickness(10,0,0,10);
            SignUp.Width = 200;
            SignUp.Height = 40;
            SignUp.MouseDown += SignUpCLick;
            parrent2.Children.Add(SignUp);

            WpfControlLibrary1.CustomButton1 Back = new WpfControlLibrary1.CustomButton1("Назад");
            Back.VerticalAlignment = VerticalAlignment.Bottom;
            Back.HorizontalAlignment = HorizontalAlignment.Left;
            Back.Margin = new Thickness(220, 0, 0, 10);
            Back.Width = 200;
            Back.Height = 40;
            Back.MouseDown += BackCLick;
            parrent2.Children.Add(Back);

            if (curUser != null)
            {
                Login.SetText(curUser.UserLogin);
                Password.SetText(curUser.UserPassword);
                UserName.SetText(curUser.UserName);
                Phone.SetText(curUser.UserPhone);
                Passport.SetText(curUser.UserPassport);
                DateOfBirth.SetText(curUser.UserDateOfBitrh);
                Mail.SetText(curUser.UserMail);
                DriverLicense.SetText(curUser.UserDriverLicense);
                Image.SetImage(curUser.UserImage);
                if (curUser.UserStatus == "admin")
                {
                    Status.Switch_MouseDown(null,null);
                    Status.Switch_MouseDown(null, null);
                    user.IsEnabled = false;
                    admin.IsEnabled = true;
                    userStatus = "admin";
                }
                SignUp.SetText("Изменить");
            }
        }
        public void Switch(object sender,RoutedEventArgs e)
        {

            var switchbox = sender as WpfControlLibrary1.Switch;
            if (switchbox.state)
            {
                user.IsEnabled = false;
                admin.IsEnabled = true;
                userStatus = "admin";
            }
            else
            {
                user.IsEnabled = true;
                admin.IsEnabled = false;
                userStatus = "user";
            }
        }
        public void BackCLick(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(mainWindow, parrentPage);
        }
        public void SignUpCLick(object sender, RoutedEventArgs e)
        {
            if (curUser != null)
            {
                Classes.User.Edit(mainWindow,curUser.idUser, Login.GetText(), Password.GetText(), userStatus, UserName.GetText(), Phone.GetText(), Passport.GetText(), DateOfBirth.GetText(), Mail.GetText(), DriverLicense.GetText(), Image.GetStringImage());
            }
            else
            {
                Classes.User.Add(mainWindow, Login.GetText(), Password.GetText(), userStatus, UserName.GetText(), Phone.GetText(), Passport.GetText(), DateOfBirth.GetText(), Mail.GetText(), DriverLicense.GetText(), Image.GetStringImage());
            }
            Classes.User.LoadUsers(mainWindow);
            if (parrentPage is Pages.Main)
            {
                var main = parrentPage as Pages.Main;
                main.ShowUsersList(null,null);
            }
            mainWindow.OpenPage(mainWindow,parrentPage);
        }
    }
}
