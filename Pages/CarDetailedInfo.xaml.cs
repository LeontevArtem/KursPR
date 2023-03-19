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
    /// Логика взаимодействия для CarDetailedInfo.xaml
    /// </summary>
    public partial class CarDetailedInfo : Page
    {
        public MainWindow mainWindow;
        public Page parrentPage;
        WpfControlLibrary1.BeautifulTextBox CarManufacturer = new WpfControlLibrary1.BeautifulTextBox("Производитель");
        WpfControlLibrary1.BeautifulTextBox CarModel = new WpfControlLibrary1.BeautifulTextBox("Марка");
        WpfControlLibrary1.BeautifulTextBox CarColor = new WpfControlLibrary1.BeautifulTextBox("Цвет");
        WpfControlLibrary1.BeautifulTextBox CarPresentationYear = new WpfControlLibrary1.BeautifulTextBox("Год презентации");
        public CarDetailedInfo(MainWindow mainWindow,Page parrentPage,Classes.Car curCar = null)
        {
            
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.parrentPage = parrentPage;

            WpfControlLibrary1.BackButton Back = new WpfControlLibrary1.BackButton();
            Back.VerticalAlignment = VerticalAlignment.Center;
            Back.HorizontalAlignment = HorizontalAlignment.Left;
            Back.Margin = new Thickness(5);
            Back.MouseDown += BackClick;
            top.Children.Add( Back );

            WpfControlLibrary1.CustomButton1 GoToMain = new WpfControlLibrary1.CustomButton1("На главную");
            GoToMain.VerticalAlignment = VerticalAlignment.Center;
            GoToMain.HorizontalAlignment = HorizontalAlignment.Left;
            GoToMain.Margin = new Thickness(40,5,0,5);
            GoToMain.Width= 100;
            GoToMain.Height= 40;
            GoToMain.SetFontSize(12);
            GoToMain.MouseDown += GoToMainClick;
            top.Children.Add(GoToMain);

            WpfControlLibrary1.ImageBrowser Image = new WpfControlLibrary1.ImageBrowser();
            Image.VerticalAlignment= VerticalAlignment.Top;
            Image.HorizontalAlignment = HorizontalAlignment.Left;
            Image.Margin = new Thickness(15,15,0,0);
            Image.Width = 200;
            Image.Height = 250;
            parrent.Children.Add(Image);
            //Image.HideButton();

            CarManufacturer.VerticalAlignment= VerticalAlignment.Top;
            CarManufacturer.Margin = new Thickness(160,10,10,0);
            parrent2.Children.Add(CarManufacturer);

            CarModel.VerticalAlignment = VerticalAlignment.Top;
            CarModel.Margin = new Thickness(160, 50, 10, 0);
            parrent2.Children.Add(CarModel);

            CarColor.VerticalAlignment = VerticalAlignment.Top;
            CarColor.Margin = new Thickness(160, 90, 10, 0);
            parrent2.Children.Add(CarColor);

            CarPresentationYear.VerticalAlignment = VerticalAlignment.Top;
            CarPresentationYear.Margin = new Thickness(160, 130, 10, 0);
            parrent2.Children.Add(CarPresentationYear);




            if (curCar != null)
            {
                CarManufacturer.SetText(curCar.CarManufacturer);
                CarModel.SetText(curCar.CarModel);
                CarColor.SetText(curCar.CarColor);
                CarPresentationYear.SetText(curCar.CarPresentationYear.ToString());
                CarDescription.Text = curCar.CarDetailedInfo;
                Image.SetImage(curCar.CarImage);
            }
        }
        public void BackClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow,parrentPage);
        }
        public void GoToMainClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow, new Pages.Main(mainWindow));
        }
    }
}
