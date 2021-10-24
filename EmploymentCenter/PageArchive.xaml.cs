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
using System.Windows.Shapes;

namespace EmploymentCenter
{
    /// <summary>
    /// Логика взаимодействия для WindowArchive.xaml
    /// </summary>
    public partial class PageArchive : Page
    {
        Db Db;
        
        public PageArchive()
        {
            Db = Db.GetDb();
            InitializeComponent();
            DataContext = new PagerArchiveVM();

        }
    }
}
