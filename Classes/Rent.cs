using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.Classes
{
    public class Rent
    {
        public string idRents { get; set; }
        public string idClients { get; set; }
        public string idCar { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Bill { get; set; }

        public Rent(string idRents, string idClients, string idCar, string StartDate, string EndDate, int Bill)
        {
            this.idRents = idRents;
            this.idClients = idClients;
            this.idCar = idCar;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Bill = Bill;
        }
        public static void Add(MainWindow mainWindow,int idClient,int idCar,string StartDate,string EndDate,string Bill)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `kursbd`.`rents` (`idClient`, `idCar`, `StartDate`, `EndDate`, `Bill`) VALUES ('{idClient}', '{idCar}', '{StartDate}', '{EndDate}', '{Bill}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление аренд"));
            }
        }
        public static void Edit(MainWindow mainWindow,int idRent, int idClient, int idCar, string StartDate, string EndDate, string Bill)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader addCarQuery = Connection.Query($"UPDATE `kursbd`.`rents` SET `idClient` = '{idClient}', `idCar` = '{idCar}', `StartDate` = '{StartDate}', `EndDate` = '{EndDate}', `Bill` = '{Bill}' WHERE (`idRents` = '{idRent}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение аренд"));
            }
        }
        public static void Delete(MainWindow mainWindow,int id)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `kursbd`.`rents` WHERE (`idRents` = '{id}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление аренд"));
            }
        }
        public static void LoadRents(MainWindow mainWindow)
        {
            try
            {
                mainWindow.RentsList.Clear();
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader rentQuery = Connection.Query("SELECT * FROM KursBD.Rents;", mySqlConnection);
                while (rentQuery.Read())
                {
                    try
                    {
                        mainWindow.RentsList.Add(new Classes.Rent(rentQuery.GetString(0), rentQuery.GetString(1), rentQuery.GetString(2), rentQuery.GetString(3), rentQuery.GetString(4), Convert.ToInt32(rentQuery.GetString(5))));
                    }
                    catch(Exception ex) { mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Загрузка аренд")); }
                    
                }
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Загрузка аренд"));
            }
        }
    }
}
