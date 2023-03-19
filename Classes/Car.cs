using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace CarRent.Classes
{
    public class Car
    {
        public int idCar { get; set; }
        public string CarManufacturer { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public int CarPresentationYear { get; set; }
        public string CarDetailedInfo { get; set; }
        public string CarImage { get; set; }
        public double CarRentPrice { get; set; }
        public string CarNumber { get; set; }
        public string CarCategory { get; set; }

        public Car(int idCar, string CarManufacturer, string CarModel, string CarColor, int CarPresentationYear, string CarDetailedInfo, string CarImage, double CarRentPrice, string CarNumber, string CarCategory)
        {
            this.idCar = idCar;
            this.CarManufacturer = CarManufacturer;
            this.CarModel = CarModel;
            this.CarColor = CarColor;
            this.CarPresentationYear = CarPresentationYear;
            this.CarDetailedInfo = CarDetailedInfo;
            this.CarImage = CarImage;
            this.CarRentPrice = CarRentPrice;
            this.CarNumber = CarNumber;
            this.CarCategory = CarCategory;
            //var exc = Convert.ToDateTime(CarModel);
        }
        public static void Add(MainWindow mainWindow,string CarManufacturer,string CarModel,string CarColor,string CarYear,string CarDetailedInfo,string CarImage,string CarPrice,string CarRegNumber,string CarCategory)
        {

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `KursBD`.`cars` (`CarManufacturer`, `CarModel`, `CarColor`, `CarPresentationYear`, `CarDetailedInfo`, `CarImage`, `CarRentPrice`, `CarNumber`, `CarCategory`) VALUES ('{CarManufacturer}', '{CarModel}', '{CarColor}', '{CarYear}', '{CarDetailedInfo}', '{CarImage}', '{CarPrice}', '{CarRegNumber}', '{CarCategory}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка (Добавление автомобиля)", MessageBoxButton.OK, MessageBoxImage.Error);
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now,ex, "Добавление автомобилей"));
            }
        }
        public static void Edit(MainWindow mainWindow,int id,string CarManufacturer, string CarModel, string CarColor, string CarYear, string CarDetailedInfo, string CarImage, string CarPrice, string CarRegNumber, string CarCategory)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader addCarQuery = Connection.Query($"UPDATE `KursBD`.`cars` SET `CarManufacturer` = '{CarManufacturer}',`CarImage` = '{CarImage}', `CarModel` = '{CarModel}', `CarColor` = '{CarColor}', `CarPresentationYear` = '{CarYear}', `CarDetailedInfo` = '{CarDetailedInfo}', `CarRentPrice` = '{CarPrice}', `CarNumber` = '{CarRegNumber}', `CarCategory` = '{CarCategory}' WHERE (`idCars` = '{id}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка (Добавление автомобиля)", MessageBoxButton.OK, MessageBoxImage.Error);
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение автомобилей"));
            }
        }
        public static void Delete(MainWindow mainWindow,int id)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `KursBD`.`cars` WHERE (`idCars` = '{id}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка (Добавление автомобиля)", MessageBoxButton.OK, MessageBoxImage.Error);
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление автомобилей"));
            }
        }
        public static void LoadCars(MainWindow mainWindow)
        {
            try
            {
                mainWindow.CarsList.Clear();
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader carQuery = Connection.Query("SELECT * FROM KursBD.Cars;", mySqlConnection);
                while (carQuery.Read())
                {
                    try
                    {
                        mainWindow.CarsList.Add(new Classes.Car(carQuery.GetInt32(0), carQuery.GetString(1), carQuery.GetString(2), carQuery.GetString(3), carQuery.GetInt32(4), carQuery.GetString(5), carQuery.GetString(6), carQuery.GetDouble(7), carQuery.GetString(8), carQuery.GetString(9)));
                    }
                    catch(Exception ex) { mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Загрузка автомобилей")); }
                    
                }
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex,"Загрузка автомобилей"));
            }
        }

    }
}
