using CarRent.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Threading;

namespace CarRent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.Car.LoadCars(this);
            Classes.Rent.LoadRents(this);
            Classes.User.LoadUsers(this);

            Timer.Interval = TimeSpan.FromSeconds(5);
            Timer.Tick += UpdateData;
            Timer.Start();

            OpenPage(this,new Pages.LogIn(this));
        }
        DispatcherTimer Timer = new DispatcherTimer();
        public static Classes.User CurrentUser = new Classes.User(0,"","","","","","","","","","");

        public List<Classes.ErrorMessage> Errors = new List<Classes.ErrorMessage>();
        public List<Classes.User> UsersList = new List<Classes.User>();
        public List<Classes.Car> CarsList = new List<Classes.Car>();
        public List<Classes.Rent> RentsList = new List<Classes.Rent>();

        public static string GetConnectionString()
        {
            return "server=localhost;port=3308;database=KursBD;uid=root";
            //return Pages.ConnectionPage.connectionString;
        }
        public void UpdateData(object sender, EventArgs args)
        {
            Classes.Car.LoadCars(this);
            Classes.Rent.LoadRents(this);
            Classes.User.LoadUsers(this);
        }
        public void OpenPage(MainWindow mainWindow,Page ToPage)
        {
            Classes.Car.LoadCars(this);
            Classes.Rent.LoadRents(this);
            Classes.User.LoadUsers(this);
            DoubleAnimation opgrid = new DoubleAnimation();
            opgrid.From = 1;
            opgrid.To = 0;
            opgrid.Duration = TimeSpan.FromSeconds(0.1);
            opgrid.Completed += delegate
            {
                Classes.Car.LoadCars(this);
                Classes.Rent.LoadRents(this);
                Classes.User.LoadUsers(this);
                mainWindow.frame.Navigate(ToPage);
                DoubleAnimation opgrid2 = new DoubleAnimation();
                opgrid2.From = 0;
                opgrid2.To = 1;
                opgrid2.Duration = TimeSpan.FromSeconds(0.1);
                mainWindow.frame.BeginAnimation(Frame.OpacityProperty, opgrid2);

            };
            mainWindow.frame.BeginAnimation(Frame.OpacityProperty, opgrid);
        }
        public static BitmapImage Base64StringToBitMap(MainWindow mainWindow,string base64String)
        {
            //Работа с Изображениями, сохраненными в виде массива битов prod. by Sanya Galanov
            try
            {
                byte[] buffer = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(buffer))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            catch (Exception ex)
            {
                mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Загрузка изображений из БД"));
                return null;
            }
#pragma warning disable CS0162 // Обнаружен недостижимый код
            return null;
#pragma warning restore CS0162 // Обнаружен недостижимый код
        }
    }
}
