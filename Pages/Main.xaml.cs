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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public Main(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;

            WpfControlLibrary1.CustomButton1 Exit = new WpfControlLibrary1.CustomButton1("Выйти");
            Exit.MouseDown += LogOut;
            Exit.Width = 100;
            Exit.Height = 36;
            Exit.VerticalAlignment = VerticalAlignment.Center;
            Exit.HorizontalAlignment = HorizontalAlignment.Right;
            Exit.Margin = new Thickness(0,0,2,0);
            top.Children.Add(Exit);

            WpfControlLibrary1.SidePanel SidePanel1 = new WpfControlLibrary1.SidePanel(WpfControlLibrary1.SidePanel.PanelOrientation.left);
            parrent.Children.Add(SidePanel1);

            WpfControlLibrary1.CustomButton1 ErrorsList = new WpfControlLibrary1.CustomButton1("Журнал ошибок");
            ErrorsList.MouseDown += ShowErrorsJournal;
            ErrorsList.Width= 170;
            ErrorsList.VerticalAlignment = VerticalAlignment.Top;
            ErrorsList.Margin= new Thickness(10);
            SidePanel1.AddChildren(ErrorsList);

            WpfControlLibrary1.CustomButton1 CarsList = new WpfControlLibrary1.CustomButton1("Список машин");
            CarsList.MouseDown += ShowCarsList;
            CarsList.Width = 170;
            CarsList.VerticalAlignment = VerticalAlignment.Top;
            CarsList.Margin = new Thickness(10,50,10,0);
            CarsList.MouseDown += ShowCarsList;
            SidePanel1.AddChildren(CarsList);

            WpfControlLibrary1.CustomButton1 RentsList = new WpfControlLibrary1.CustomButton1("Список аренд");
            RentsList.MouseDown += ShowRentsList;
            RentsList.Width = 170;
            RentsList.VerticalAlignment = VerticalAlignment.Top;
            RentsList.Margin = new Thickness(10, 90, 10, 0);
            SidePanel1.AddChildren(RentsList);

            WpfControlLibrary1.CustomButton1 UsersList = new WpfControlLibrary1.CustomButton1("Список пользователей");
            UsersList.SetFontSize(12);
            UsersList.MouseDown += ShowUsersList;
            UsersList.Width = 170;
            UsersList.VerticalAlignment = VerticalAlignment.Top;
            UsersList.Margin = new Thickness(10, 130, 10, 0);
            SidePanel1.AddChildren(UsersList);

            ShowCarsList(null,null);

        }
        public void LogOut(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow,new Pages.LogIn(mainWindow));
        }
        public void ShowErrorsJournal(object sender, RoutedEventArgs args)
        {
            Windows.ErrorsWindow ErrorsJournal = new Windows.ErrorsWindow(mainWindow);
            ErrorsJournal.ShowDialog();
        }

        public void ShowCarsList(object sender, RoutedEventArgs args)
        {
            parrent2.Children.Clear();
            foreach (Classes.Car curCar in mainWindow.CarsList)
            {
                if (curCar.CarStatus == "free")
                {
                    parrent2.Children.Add(new InfoItems.CarItem(mainWindow, curCar, this));
                }
                else if(curCar.CarStatus == "rented" && MainWindow.CurrentUser.UserStatus == "user")
                {
                    var item = new InfoItems.CarItem(mainWindow, curCar, this);
                    item.IsEnabled = false;
                    parrent2.Children.Add(item);
                }
                else
                {
                    parrent2.Children.Add(new InfoItems.CarItem(mainWindow, curCar, this));
                }
                
            }
            if (MainWindow.CurrentUser.UserStatus == "admin")
            {
                var button = new CustomItems.AddButton(mainWindow, "Cars");
                button.MouseDown += AddButtonClick;
                parrent2.Children.Add(button);
            }
            
        }
        public void ShowRentsList(object sender, RoutedEventArgs args)
        {
            parrent2.Children.Clear();
            foreach (Classes.Rent curRent in mainWindow.RentsList)
            {
                parrent2.Children.Add(new InfoItems.RentItem(mainWindow,curRent,this));
            }
            if (MainWindow.CurrentUser.UserStatus == "admin")
            {
                var button = new CustomItems.AddButton(mainWindow, "Rents");
                button.MouseDown += AddButtonClick;
                parrent2.Children.Add(button);
            }
        }
        public void ShowUsersList(object sender, RoutedEventArgs args)
        {
            parrent2.Children.Clear();
            foreach (Classes.User curUser in mainWindow.UsersList)
            {
                parrent2.Children.Add(new InfoItems.UserItem(mainWindow, curUser, this));
            }
            if (MainWindow.CurrentUser.UserStatus == "admin")
            {
                var button = new CustomItems.AddButton(mainWindow, "Users");
                button.MouseDown += AddButtonClick;
                parrent2.Children.Add(button);
            }
        }
        public void AddButtonClick(object sender, RoutedEventArgs args)
        {
            CustomItems.AddButton button = sender as CustomItems.AddButton;
            if (button.GetClass()=="Cars")
            {
                mainWindow.OpenPage(mainWindow,new Pages.CarDetailedInfo(mainWindow,this,null,CarDetailedInfo.PageMode.Add));
            }
            else if (button.GetClass() == "Rents")
            {
                mainWindow.OpenPage(mainWindow,new Pages.RentPage(mainWindow,null,this));
            }
        }
    }
}
