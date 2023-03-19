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
        MainWindow mainWindow;
        Page parrentPage;
        Classes.Car curCar;
        Classes.Rent curRent;
        public RentItem(MainWindow mainWindow,Classes.Rent curRent,Page parrentPage)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.parrentPage = parrentPage;
            this.curRent = curRent;

            foreach (Classes.Car curCar in mainWindow.CarsList)
            {
                if (curCar.idCar.ToString() == curRent.idCar)
                {
                    Car.Content = curCar.CarManufacturer + " " + curCar.CarModel;
                    try
                    {
                        CarImage.Source = MainWindow.Base64StringToBitMap(mainWindow,curCar.CarImage);
                        this.curCar= curCar;
                    }
                    catch { }
                        
                }
            }
            try
            {
                for (int i = 0; i < mainWindow.UsersList.Count; i++) /*(Classes.User curUser in mainWindow.UsersList)*/
                {

                    if (mainWindow.UsersList[i].idUser.ToString() == curRent.idClients)
                    {
                        User.Content = mainWindow.UsersList[i].UserName;
                        try
                        {
                            UserImage.Source = MainWindow.Base64StringToBitMap(mainWindow,mainWindow.UsersList[i].UserImage);
                        }
                        catch { }

                    }
                }
            }
            catch { }
            
            Date.Content = curRent.StartDate.ToString() + " - " + curRent.EndDate.ToString();
        }
        private void parrent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(mainWindow,new Pages.RentPage(mainWindow,curRent,parrentPage));
        }
    }
}
