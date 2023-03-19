﻿using CarRent.Classes;
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
    /// Логика взаимодействия для UserItem.xaml
    /// </summary>
    public partial class UserItem : UserControl
    {
        MainWindow mainWindow;
        public UserItem(MainWindow mainWindow,Classes.User curUser,Page parrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            UserName.Content = curUser.UserName;
            UserMail.Content = curUser.UserMail;
            UserPhone.Content = curUser.UserPhone;
            try
            {
                for (int i = 0; i < mainWindow.UsersList.Count; i++) /*(Classes.User curUser in mainWindow.UsersList)*/
                {
                        try
                        {
                            UserImage.Source = MainWindow.Base64StringToBitMap(mainWindow, mainWindow.UsersList[i].UserImage);
                        }
                        catch { }
                }
            }
            catch { }
        }
        private void parrent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}