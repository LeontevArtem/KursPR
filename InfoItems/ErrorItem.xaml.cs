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

namespace CarRent.InfoItems
{
    /// <summary>
    /// Логика взаимодействия для ErrorItem.xaml
    /// </summary>
    public partial class ErrorItem : UserControl
    {
        public ErrorItem(MainWindow mainWindow,Classes.ErrorMessage curError)
        {
            InitializeComponent();
            ErrorTime.Content= curError.DateError.ToString();
            ErrorMessage.Text= curError.Message.Message.ToString();
            ErrorSource.Content= curError.Source;
        }
        private void parrent_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
