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
        Classes.Rent curRent;
        Page parrentPage;
        public DateTime TimeStart;
        public DateTime TimeEnd;
        public RentPage(MainWindow mainWindow,Classes.Rent curRent,Page parrentPage)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
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

            WpfControlLibrary1.CustomButton1 AddRent = new WpfControlLibrary1.CustomButton1("Арендовать");
            AddRent.Width= 280;
            AddRent.Height= 40;
            AddRent.VerticalAlignment = VerticalAlignment.Top;
            AddRent.HorizontalAlignment = HorizontalAlignment.Center;
            AddRent.Margin = new Thickness(5,155,5,5);
            parrent2.Children.Add(AddRent);

            
            if(curRent != null)
            {
                foreach (Classes.Car curCar in mainWindow.CarsList)
                {
                    if (curCar.idCar.ToString() == curRent.idCar)
                    {
                        var item = new InfoItems.CarItem(mainWindow, curCar, this);
                        item.VerticalAlignment = VerticalAlignment.Top;
                        item.Margin = new Thickness(0, 30, 0, 0);
                        parrent1.Children.Add(item);
                        this.curCar = curCar;
                    }
                }

                foreach (Classes.User curUser in mainWindow.UsersList)
                {
                    if (curUser.idUser.ToString() == curRent.idClients)
                    {
                        var item = new InfoItems.UserItem(mainWindow, curUser, this);
                        item.VerticalAlignment = VerticalAlignment.Top;
                        item.Margin = new Thickness(0, 280, 0, 0);
                        parrent1.Children.Add(item);
                        this.curRent = curRent;
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
            //
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
            TimeStart = (DateTime)DateStart.SelectedDate;
            TimeEnd = (DateTime)DateEnd.SelectedDate;
            double Days = (TimeEnd - TimeStart).TotalDays;
            double price = Days * curCar.CarRentPrice;
            ResultPrice.Content = "Итого: " + price;
        }
    }
}
