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
        public Classes.Car curCar;
        public string mode = "";
        WpfControlLibrary1.BeautifulTextBox CarManufacturer = new WpfControlLibrary1.BeautifulTextBox("Производитель");
        WpfControlLibrary1.BeautifulTextBox CarModel = new WpfControlLibrary1.BeautifulTextBox("Марка");
        WpfControlLibrary1.BeautifulTextBox CarColor = new WpfControlLibrary1.BeautifulTextBox("Цвет");
        WpfControlLibrary1.BeautifulTextBox CarPresentationYear = new WpfControlLibrary1.BeautifulTextBox("Год презентации");
        WpfControlLibrary1.BeautifulTextBox CarCategory = new WpfControlLibrary1.BeautifulTextBox("Категория транспорта");
        WpfControlLibrary1.BeautifulTextBox CarPrice = new WpfControlLibrary1.BeautifulTextBox("Цена");
        WpfControlLibrary1.BeautifulTextBox CarRegNumber = new WpfControlLibrary1.BeautifulTextBox("Регистрационный номер");
        WpfControlLibrary1.ImageBrowser Image = new WpfControlLibrary1.ImageBrowser();
        public enum PageMode
        {
            Edit,
            Add
        };
        public CarDetailedInfo(MainWindow mainWindow,Page parrentPage,Classes.Car curCar = null,PageMode pageMode = PageMode.Edit)
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

            
            Image.VerticalAlignment= VerticalAlignment.Top;
            Image.HorizontalAlignment = HorizontalAlignment.Left;
            Image.Margin = new Thickness(15,15,0,0);
            Image.Width = 200;
            Image.Height = 250;
            parrent.Children.Add(Image);
            //Image.HideButton();

            
            if (pageMode == PageMode.Edit) mode = "Изменить";
            if (pageMode == PageMode.Add) mode = "Добавить";
            WpfControlLibrary1.CustomButton1 AddEditButton = new WpfControlLibrary1.CustomButton1(mode);
            AddEditButton.VerticalAlignment = VerticalAlignment.Top;
            AddEditButton.HorizontalAlignment = HorizontalAlignment.Left;
            AddEditButton.Margin = new Thickness(15,280,0,0);
            AddEditButton.Width = 200;
            AddEditButton.Height = 30;
            AddEditButton.MouseDown += delegate { AddEditButtonClick(); };
            parrent.Children.Add(AddEditButton);

            CarManufacturer.VerticalAlignment= VerticalAlignment.Top;
            CarManufacturer.Margin = new Thickness(170,10,10,0);
            parrent2.Children.Add(CarManufacturer);

            CarModel.VerticalAlignment = VerticalAlignment.Top;
            CarModel.Margin = new Thickness(170, 50, 10, 0);
            parrent2.Children.Add(CarModel);

            CarColor.VerticalAlignment = VerticalAlignment.Top;
            CarColor.Margin = new Thickness(170, 90, 10, 0);
            parrent2.Children.Add(CarColor);

            CarPresentationYear.VerticalAlignment = VerticalAlignment.Top;
            CarPresentationYear.Margin = new Thickness(170, 130, 10, 0);
            parrent2.Children.Add(CarPresentationYear);

            CarCategory.VerticalAlignment = VerticalAlignment.Top;
            CarCategory.Margin = new Thickness(170, 170, 10, 0);
            parrent2.Children.Add(CarCategory);

            CarPrice.VerticalAlignment = VerticalAlignment.Top;
            CarPrice.Margin = new Thickness(170, 210, 10, 0);
            parrent2.Children.Add(CarPrice);

            CarRegNumber.VerticalAlignment = VerticalAlignment.Top;
            CarRegNumber.Margin = new Thickness(170, 250, 10, 0);
            parrent2.Children.Add(CarRegNumber);




            if (curCar != null)
            {
                CarManufacturer.SetText(curCar.CarManufacturer);
                CarModel.SetText(curCar.CarModel);
                CarColor.SetText(curCar.CarColor);
                CarPresentationYear.SetText(curCar.CarPresentationYear.ToString());
                CarCategory.SetText(curCar.CarCategory.ToString());
                CarPrice.SetText(curCar.CarRentPrice.ToString());
                CarDescription.AppendText( curCar.CarDetailedInfo);
                CarRegNumber.SetText(curCar.CarNumber);
                Image.SetImage(curCar.CarImage);
                this.curCar = curCar;
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
        public void AddEditButtonClick()
        {
            if (mode =="Добавить")
            {
                string img = this.Image.GetStringImage();
                Classes.Car.Add(mainWindow,CarManufacturer.GetText(),CarModel.GetText(),CarColor.GetText(),CarPresentationYear.GetText(),StringFromRichTextBox(CarDescription),this.Image.GetStringImage(),CarPrice.GetText(),CarRegNumber.GetText(),CarCategory.GetText());
                MessageBox.Show("Успешное добавление");
                Classes.Car.LoadCars(mainWindow);
                mainWindow.OpenPage(mainWindow,new Pages.Main(mainWindow));
            }
            else if (mode == "Изменить")
            {
                string img = this.Image.GetStringImage();
                Classes.Car.Edit(mainWindow,curCar.idCar ,CarManufacturer.GetText(), CarModel.GetText(), CarColor.GetText(), CarPresentationYear.GetText(), StringFromRichTextBox(CarDescription), this.Image.GetStringImage(), CarPrice.GetText(), CarRegNumber.GetText(), CarCategory.GetText());
                MessageBox.Show("Успешное изменение");
                Classes.Car.LoadCars(mainWindow);
                mainWindow.OpenPage(mainWindow, new Pages.Main(mainWindow));
            }
        }
        public string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );
            return textRange.Text;
        }
    }
}
