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

namespace CarRent.Pages.ContentPages
{
    /// <summary>
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        public MainWindow mainWindow;
        public Main main;
        public CarsPage(MainWindow mainWindow,Pages.Main main)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.main = main;
            ShowCars();
        }
        public void ShowCars()
        {
            parrent.Children.Clear();
            foreach (Classes.Car curCar in mainWindow.CarsList)
            {
                parrent.Children.Add(new InfoItems.CarItem(mainWindow,curCar,main));
            }
        }
    }
}
