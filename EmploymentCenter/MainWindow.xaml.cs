using Employment_Center;
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

namespace EmploymentCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Db Db;
        public MainWindow()
        {
            InitializeComponent();
            Db = Db.GetDb();
            DataContext = new MainVM();
        }
        
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
