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

namespace CarRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public Main(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;

            WpfControlLibrary1.SidePanel SidePanel1 = new WpfControlLibrary1.SidePanel(WpfControlLibrary1.SidePanel.PanelOrientation.left);
            parrent.Children.Add(SidePanel1);

            WpfControlLibrary1.CustomButton1 ErrorsList = new WpfControlLibrary1.CustomButton1("Журнал ошибок");
            ErrorsList.MouseDown += ShowErrorsJournal;
            ErrorsList.Width= 170;
            ErrorsList.VerticalAlignment = VerticalAlignment.Top;
            ErrorsList.Margin= new Thickness(10);
            SidePanel1.AddChildren(ErrorsList);

            WpfControlLibrary1.CustomButton1 CarsList = new WpfControlLibrary1.CustomButton1("Список машин");
            CarsList.MouseDown += ShowCarsList;
            CarsList.Width = 170;
            CarsList.VerticalAlignment = VerticalAlignment.Top;
            CarsList.Margin = new Thickness(10,50,10,0);
            SidePanel1.AddChildren(CarsList);

            WpfControlLibrary1.CustomButton1 RentsList = new WpfControlLibrary1.CustomButton1("Список аренд");
            //RentsList.MouseDown += ShowCarsList;
            RentsList.Width = 170;
            RentsList.VerticalAlignment = VerticalAlignment.Top;
            RentsList.Margin = new Thickness(10, 90, 10, 0);
            SidePanel1.AddChildren(RentsList);




            OpenPage(this,new Pages.ContentPages.CarsPage(mainWindow,this));
        }
        public void ShowErrorsJournal(object sender, RoutedEventArgs args)
        {
            Windows.ErrorsWindow ErrorsJournal = new Windows.ErrorsWindow(mainWindow);
            ErrorsJournal.ShowDialog();
        }
        public void ShowCarsList(object sender, RoutedEventArgs args)
        {
            OpenPage(this,new Pages.ContentPages.CarsPage(mainWindow,this));
        }
        public void OpenPage(Main main, Page ToPage)
        {

            DoubleAnimation opgrid = new DoubleAnimation();
            opgrid.From = 1;
            opgrid.To = 0;
            opgrid.Duration = TimeSpan.FromSeconds(0.1);
            opgrid.Completed += delegate
            {
                Classes.Car.LoadCars(mainWindow);
                Classes.Rent.LoadRents(mainWindow);
                Classes.User.LoadUsers(mainWindow);
                MainPageFrame.Navigate(ToPage);
                DoubleAnimation opgrid2 = new DoubleAnimation();
                opgrid2.From = 0;
                opgrid2.To = 1;
                opgrid2.Duration = TimeSpan.FromSeconds(0.1);
                MainPageFrame.BeginAnimation(Frame.OpacityProperty, opgrid2);

            };
            MainPageFrame.BeginAnimation(Frame.OpacityProperty, opgrid);
        }
    }
}
