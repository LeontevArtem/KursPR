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
    /// Логика взаимодействия для RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        MainWindow mainWindow;
        Classes.Car curCar;
        Classes.User curUser;
        Classes.Rent curRent;
        Page parrentPage;
        public DateTime TimeStart;
        public DateTime TimeEnd;
        public RentPage(MainWindow mainWindow,Classes.Rent curRent,Page parrentPage)
        {
            //Измененине
            
            InitializeComponent();
            
            this.mainWindow = mainWindow;
            this.curRent = curRent;
            this.parrentPage = parrentPage;

            WpfControlLibrary1.BackButton Back = new WpfControlLibrary1.BackButton();
            Back.VerticalAlignment = VerticalAlignment.Center;
            Back.HorizontalAlignment = HorizontalAlignment.Left;
            Back.Margin = new Thickness(5);
            Back.MouseDown += BackClick;
            top.Children.Add(Back);

            WpfControlLibrary1.CustomButton1 GoToMain = new WpfControlLibrary1.CustomButton1("На главную");
            GoToMain.VerticalAlignment = VerticalAlignment.Center;
            GoToMain.HorizontalAlignment = HorizontalAlignment.Left;
            GoToMain.Margin = new Thickness(40, 5, 0, 5);
            GoToMain.Width = 100;
            GoToMain.Height = 40;
            GoToMain.SetFontSize(12);
            GoToMain.MouseDown += GoToMainClick;
            top.Children.Add(GoToMain);

            WpfControlLibrary1.CustomButton1 Delete = new WpfControlLibrary1.CustomButton1("Удалить");
            Delete.Width = 280;
            Delete.Height = 40;
            Delete.MouseDown += DeleteButtonClick;
            Delete.VerticalAlignment = VerticalAlignment.Top;
            Delete.HorizontalAlignment = HorizontalAlignment.Center;
            Delete.Margin = new Thickness(5, 200, 5, 5);
            parrent2.Children.Add(Delete);


            WpfControlLibrary1.CustomButton1 AddRent = new WpfControlLibrary1.CustomButton1("Изменить");
            AddRent.Width = 280;
            AddRent.Height = 40;
            AddRent.MouseDown += AddRentButtonClick;
            AddRent.VerticalAlignment = VerticalAlignment.Top;
            AddRent.HorizontalAlignment = HorizontalAlignment.Center;
            AddRent.Margin = new Thickness(5, 155, 5, 5);
            if (parrentPage is Pages.Main)
            {
                AddRent.SetText("Добавить");
                parrent2.Children.Add(AddRent);
                Delete.Visibility = Visibility.Collapsed;
            }
            if (curRent != null)
            {
                try
                {
                    parrent2.Children.Add(AddRent);
                }
                catch { }
                

                foreach (Classes.Car curCar in mainWindow.CarsList)
                {
                    if (curCar.idCar.ToString() == curRent.idCar)
                    {
                        var item = new InfoItems.CarItem(mainWindow, curCar, this);
                        item.VerticalAlignment = VerticalAlignment.Top;
                        item.Margin = new Thickness(0, 30, 0, 0);
                        parrent11.Children.Add(item);
                        this.curCar = curCar;
                    }
                }

                foreach (Classes.User curUser in mainWindow.UsersList)
                {
                    if (curUser.idUser.ToString() == curRent.idClients)
                    {
                        var item = new InfoItems.UserItem(mainWindow, curUser, this);
                        item.VerticalAlignment = VerticalAlignment.Top;
                        item.Margin = new Thickness(0, 30, 0, 0);
                        parrent12.Children.Add(item);
                        this.curUser = curUser;
                    }
                }
                
                ResultPrice.Content += " "+curRent.Bill;
                TimeStart = Convert.ToDateTime(curRent.StartDate);
                DateStart.SelectedDate = TimeStart;
                TimeEnd = Convert.ToDateTime(curRent.EndDate);
                DateEnd.SelectedDate = TimeEnd;
                DateStart.SelectedDateChanged += SelectDate;
                DateEnd.SelectedDateChanged += SelectDate;
            }

            if (MainWindow.CurrentUser.UserStatus != "admin")
            {
                Delete.Visibility = Visibility.Collapsed;
                AddRent.Visibility = Visibility.Collapsed;
                CarSelector.Visibility = Visibility.Collapsed;
                UserSelector.Visibility = Visibility.Collapsed;
            }
            foreach (Classes.Car curCar in mainWindow.CarsList)
            {
                var car = new InfoItems.CarItem(mainWindow, curCar, this);
                car.Width = 500;
                car.Height = 250;
                car.LockClick();
                CarSelector.Items.Add(car);
            }
            CarSelector.SelectionChanged += CarSelectorChange;

            foreach (Classes.User curUser in mainWindow.UsersList)
            {
                var user = new InfoItems.UserItem(mainWindow, curUser, this);
                user.Width = 500;
                user.Height = 250;
                user.LockClick();
                UserSelector.Items.Add(user);
            }
            UserSelector.SelectionChanged += UserSelectorChange;
        }
        public RentPage(MainWindow mainWindow, Classes.Car curCar,Classes.User curUser, Page parrentPage)
        {
            //Добавление

            InitializeComponent();

            this.mainWindow = mainWindow;
            this.curCar = curCar;
            this.curUser = curUser;
            this.parrentPage = parrentPage;

            WpfControlLibrary1.BackButton Back = new WpfControlLibrary1.BackButton();
            Back.VerticalAlignment = VerticalAlignment.Center;
            Back.HorizontalAlignment = HorizontalAlignment.Left;
            Back.Margin = new Thickness(5);
            Back.MouseDown += BackClick;
            top.Children.Add(Back);

            WpfControlLibrary1.CustomButton1 GoToMain = new WpfControlLibrary1.CustomButton1("На главную");
            GoToMain.VerticalAlignment = VerticalAlignment.Center;
            GoToMain.HorizontalAlignment = HorizontalAlignment.Left;
            GoToMain.Margin = new Thickness(40, 5, 0, 5);
            GoToMain.Width = 100;
            GoToMain.Height = 40;
            GoToMain.SetFontSize(12);
            GoToMain.MouseDown += GoToMainClick;
            top.Children.Add(GoToMain);

            WpfControlLibrary1.CustomButton1 AddRent = new WpfControlLibrary1.CustomButton1("Добавить");
            AddRent.Width = 280;
            AddRent.Height = 40;
            AddRent.MouseDown += AddRentButtonClick;
            AddRent.VerticalAlignment = VerticalAlignment.Top;
            AddRent.HorizontalAlignment = HorizontalAlignment.Center;
            AddRent.Margin = new Thickness(5, 155, 5, 5);
            parrent2.Children.Add(AddRent);



            var car = new InfoItems.CarItem(mainWindow,curCar,this);
            car.Margin = new Thickness(0,30,0,0);
            parrent11.Children.Add(car);

            var user = new InfoItems.UserItem(mainWindow, curUser, this);
            user.Margin = new Thickness(0, 30, 0, 0);
            parrent12.Children.Add(user);

            CarSelector.Visibility = Visibility.Collapsed;
            UserSelector.Visibility = Visibility.Collapsed;

            //ResultPrice.Content += " " + curRent.Bill;
            //TimeStart = Convert.ToDateTime(curRent.StartDate);
            DateStart.SelectedDate = DateTime.Now;
            //TimeEnd = Convert.ToDateTime(curRent.EndDate);
            //DateEnd.SelectedDate = TimeEnd;
            DateStart.SelectedDateChanged += SelectDate;
            DateEnd.SelectedDateChanged += SelectDate;
        }
        public void DeleteButtonClick(object sender, RoutedEventArgs args)
        {
            MessageBoxResult res = MessageBox.Show($"Вы уверены?", "Предупреждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                Classes.Rent.Delete(mainWindow,Convert.ToInt32(curRent.idRents));
                mainWindow.OpenPage(mainWindow, parrentPage);
                var page = parrentPage as Pages.Main;
                page.ShowRentsList(null, null);
            }
        }
        public void AddRentButtonClick(object sender, RoutedEventArgs args)
        {
            MessageBoxResult res = MessageBox.Show($"Вы уверены?", "Предупреждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                if (curRent != null)
                {
                    Classes.Rent.Edit(mainWindow, Convert.ToInt32(curRent.idRents), curUser.idUser, curCar.idCar, DateStart.SelectedDate.ToString().Split(' ')[0], DateEnd.SelectedDate.ToString().Split(' ')[0], ResultPrice.Content.ToString().Split(' ')[1]);
                    var page = parrentPage as Pages.Main;
                    page.ShowRentsList(null, null);
                    mainWindow.OpenPage(mainWindow, parrentPage);
                }
                else
                {
                    Classes.Rent.Add(mainWindow, curUser.idUser, curCar.idCar, DateStart.SelectedDate.ToString().Split(' ')[0], DateEnd.SelectedDate.ToString().Split(' ')[0], ResultPrice.Content.ToString().Split(' ')[1]);
                    mainWindow.OpenPage(mainWindow, new Pages.Main(mainWindow));
                }
               
                
                
            }
            
        }
        public void CarSelectorChange(object sender, RoutedEventArgs args)
        {
            ComboBox CarSelector = sender as ComboBox;
            InfoItems.CarItem curCar = CarSelector.SelectedItem as InfoItems.CarItem;
            InfoItems.CarItem SelectedCar = new InfoItems.CarItem(mainWindow,curCar.ReturnCar(),this);
            SelectedCar.Margin = new Thickness(0,30,0,0);
            this.curCar = SelectedCar.ReturnCar();
            parrent11.Children.Clear();
            parrent11.Children.Add(SelectedCar);
        }
        public void UserSelectorChange(object sender, RoutedEventArgs args)
        {
            ComboBox UserSelector = sender as ComboBox;
            InfoItems.UserItem curUser = UserSelector.SelectedItem as InfoItems.UserItem;
            InfoItems.UserItem SelectedUser = new InfoItems.UserItem(mainWindow, curUser.ReturnUser(), this);
            SelectedUser.Margin = new Thickness(0, 30, 0, 0);
            this.curUser = SelectedUser.ReturnUser();
            parrent12.Children.Clear();
            parrent12.Children.Add(SelectedUser);
        }
        public void BackClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow, parrentPage);
        }
        public void GoToMainClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow, new Pages.Main(mainWindow));
        }
        public void SelectDate(object sender, RoutedEventArgs args)
        {
            try
            {
                TimeStart = (DateTime)DateStart.SelectedDate;
                TimeEnd = (DateTime)DateEnd.SelectedDate;
                double Days = (TimeEnd - TimeStart).TotalDays;
                double price = Days * curCar.CarRentPrice;
                ResultPrice.Content = "Итого: " + price;
            }
            catch { }  
        }
    }
}
