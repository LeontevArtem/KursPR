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

namespace CarRent.CustomItems
{
    /// <summary>
    /// Логика взаимодействия для AddButton.xaml
    /// </summary>
    public partial class AddButton : UserControl
    {
        public string Class;
        public AddButton(MainWindow mainWindow,string Class)
        {
            InitializeComponent();
            this.Class = Class;
            //Add.MouseDown += delegate { AddClick(); };
        }
        public void AddClick()
        {

        }
        public string GetClass()
        {
            return Class;
        }
    }
}
