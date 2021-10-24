using Employment_Center;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для WindowUnemployed.xaml
    /// </summary>
    public partial class PageUnemployed : Page
    {
        Db Db;
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }
        public ObservableCollection<Course> Courses { get; set; }

        public PageUnemployed()
        {
            Db = Db.GetDb();
            InitializeComponent();
            DataContext = new UnemployedVM();
        }
    }
}
