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

namespace CarRent.InfoItems
{
    /// <summary>
    /// Логика взаимодействия для CarItem.xaml
    /// </summary>
    public partial class CarItem : UserControl
    {
        public MainWindow mainWindow;
        public Page parrentPage;
        public Classes.Car curCar;
        public CarItem(MainWindow mainWindow, Classes.Car curCar,Page parrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.parrentPage = parrentPage;

            try
            {
                carName.Content = curCar.CarManufacturer + " " + curCar.CarModel;
                carColor.Content = curCar.CarColor;
                carYear.Content = curCar.CarRentPrice + " руб./день";
                carImage.Source = MainWindow.Base64StringToBitMap(mainWindow,curCar.CarImage);
                carStatus.Content = curCar.CarStatus;   
                this.curCar = curCar;
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки объекта (Автомобиль(" + curCar.idCar + "))", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void parrent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(mainWindow,new Pages.CarDetailedInfo(mainWindow,parrentPage,curCar));
        }
        public Classes.Car ReturnCar()
        {
            return curCar;
        }
        public void LockClick()
        {
            parrent.MouseDown -= parrent_MouseDown;
        }
    }
}
