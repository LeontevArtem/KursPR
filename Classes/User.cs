using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRent.Classes
{
    public class User
    {
        public int idUser { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserStatus { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserPassport { get; set; }
        public string UserDateOfBitrh { get; set; }
        public string UserMail { get; set; }
        public string UserDriverLicense { get; set; }
        public string UserImage { get; set; }

        public User(int idUser, string UserLogin, string UserPassword, string UserStatus, string UserName, string UserPhone, string UserPassport, string UserDateOfBitrh, string UserMail, string UserDriverLicense, string UserImage)
        {
            this.idUser = idUser;
            this.UserLogin = UserLogin;
            this.UserPassword = UserPassword;
            this.UserStatus = UserStatus;
            this.UserName = UserName;
            this.UserPhone = UserPhone;
            this.UserPassport = UserPassport;
            this.UserDateOfBitrh = UserDateOfBitrh;
            this.UserMail = UserMail;
            this.UserDriverLicense = UserDriverLicense;
            this.UserImage = UserImage;
        }
        public static void Add(MainWindow mainWindow,string UserLogin,string UserPassword,string UserStatus,string UserName,string UserPhone,string UserPassport,string UserDateOfBirth,string UserMail,string UserDriverLicense,string UserImage)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader userQuery = Connection.Query($"INSERT INTO `KursBD`.`users` (`UserLogin`, `UserPassword`, `UserStatus`, `UserName`, `UserPhone`, `UserPassport`, `UserDateOfBirth`, `UserMail`, `UserDriverLicense`,`UserImage`) VALUES ('{UserLogin}', '{UserPassword}', '{UserStatus}', '{UserName}', '{UserPhone}', '{UserPassport}', '{UserDateOfBirth}', '{UserMail}', '{UserDriverLicense}','{UserImage}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch(Exception ex) 
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление пользователей"));
            }
        }
        public static void Edit(MainWindow mainWindow,int id, string UserLogin, string UserPassword, string UserStatus, string UserName, string UserPhone, string UserPassport, string UserDateOfBirth, string UserMail, string UserDriverLicense, string UserImage)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader userQuery = Connection.Query($"UPDATE `kursbd`.`users` SET `UserLogin` = '{UserLogin}', `UserPassword` = '{UserPassword}', `UserStatus` = '{UserStatus}', `UserName` = '{UserName}', `UserPhone` = '{UserPhone}', `UserPassport` = '{UserPassport}', `UserDateOfBirth` = '{UserDateOfBirth}', `UserMail` = '{UserMail}', `UserDriverLicense` = '{UserDriverLicense}',`UserImage` = '{UserImage}' WHERE (`idUsers` = '{id}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение пользователей"));
            }
        }
        public static void Delete(MainWindow mainWindow, int id)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader userQuery = Connection.Query($"DELETE FROM `kursbd`.`users` WHERE (`idUsers` = '{id}');", mySqlConnection);
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление пользователей"));
            }
        }
        public static void LoadUsers(MainWindow mainWindow)
        {
            try
            {
                mainWindow.UsersList.Clear();
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader userQuery = Classes.Connection.Query("SELECT * FROM KursBD.Users;", mySqlConnection);
                while (userQuery.Read())
                {
                    try
                    {
                        mainWindow.UsersList.Add(new Classes.User(userQuery.GetInt32(0), userQuery.GetString(1), userQuery.GetString(2), userQuery.GetString(3), userQuery.GetString(4), userQuery.GetString(5), userQuery.GetString(6), userQuery.GetString(7), userQuery.GetString(8), userQuery.GetString(9),userQuery.GetString(10)));
                    }
                    catch (Exception ex) { mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Загрузка пользователей")); }
                    
                }
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Загрузка пользователей"));
            }
        }
    }
}
