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

namespace CarRent.InfoItems
{
    /// <summary>
    /// Логика взаимодействия для RentItem.xaml
    /// </summary>
    public partial class RentItem : UserControl
    {
        public RentItem(MainWindow mainWindow,Classes.Rent curRent,Page parrentPage)
        {
            InitializeComponent();
            foreach (Classes.Car curCar in mainWindow.CarsList)
            {
                if (curCar.idCar.ToString() == curRent.idCar)
                {
                        Car.Content = curCar.CarManufacturer + " " + curCar.CarModel;
                        CarImage.Source = MainWindow.Base64StringToBitMap(curCar.CarImage);
                }
            }
            foreach (Classes.User curUser in mainWindow.UsersList)
            {
                if (curUser.idUser.ToString() == curRent.idClients)
                {
                    User.Content = curUser.UserName;
                    UserImage.Source = MainWindow.Base64StringToBitMap(curUser.UserImage);
                }
            }
            Date.Content = curRent.StartDate.ToString() + " - " + curRent.EndDate.ToString();
        }
        private void parrent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
