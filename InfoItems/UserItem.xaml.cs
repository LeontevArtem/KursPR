using CarRent.Classes;
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
        Classes.User curUser;
        Page parrentPage;
        public UserItem(MainWindow mainWindow,Classes.User curUser,Page parrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curUser = curUser;
            this.parrentPage = parrentPage;
            try
            {
                UserName.Content = curUser.UserName;
                UserMail.Content = curUser.UserMail;
                UserPhone.Content = curUser.UserPhone;
            }
            catch { }
            try
            {
                UserImage.Source = MainWindow.Base64StringToBitMap(mainWindow, curUser.UserImage);
            }
            catch { }
        }
        private void parrent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(mainWindow,new Pages.UserPage(mainWindow,parrentPage,curUser));
        }
        public Classes.User ReturnUser()
        {
            return curUser;
        }
        public void LockClick()
        {
            parrent.MouseDown -= parrent_MouseDown;
        }
    }
}
