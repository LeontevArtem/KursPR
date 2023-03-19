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

namespace CarRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarDetailedInfo.xaml
    /// </summary>
    public partial class CarDetailedInfo : Page
    {
        public MainWindow mainWindow;
        public Page parrentPage;
        public CarDetailedInfo(MainWindow mainWindow,Page parrentPage)
        {
            
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.parrentPage = parrentPage;

            WpfControlLibrary1.BackButton Back = new WpfControlLibrary1.BackButton();
            Back.VerticalAlignment = VerticalAlignment.Center;
            Back.HorizontalAlignment = HorizontalAlignment.Left;
            Back.Margin = new Thickness(5);
            Back.MouseDown += BaclClick;
            top.Children.Add( Back );
        }
        public void BaclClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow,parrentPage);
        }
    }
}
