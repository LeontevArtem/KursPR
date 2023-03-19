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
            Back.MouseDown += BackClick;
            top.Children.Add( Back );

            WpfControlLibrary1.CustomButton1 GoToMain = new WpfControlLibrary1.CustomButton1("На главную");
            GoToMain.VerticalAlignment = VerticalAlignment.Center;
            GoToMain.HorizontalAlignment = HorizontalAlignment.Left;
            GoToMain.Margin = new Thickness(40,5,0,5);
            GoToMain.Width= 100;
            GoToMain.Height= 40;
            GoToMain.SetFontSize(12);
            GoToMain.MouseDown += GoToMainClick;
            top.Children.Add(GoToMain);
        }
        public void BackClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow,parrentPage);
        }
        public void GoToMainClick(object sender, RoutedEventArgs args)
        {
            mainWindow.OpenPage(mainWindow, new Pages.Main(mainWindow));
        }
    }
}
