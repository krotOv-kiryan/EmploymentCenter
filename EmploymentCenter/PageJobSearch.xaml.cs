using Employment_Center;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для WindowJobSearch.xaml
    /// </summary>
    public partial class PageJobSearch : Page
    {
        Db Db; 
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }
        // public ObservableCollection<Education> Educations { get; set; }
        public ObservableCollection<Unemployed> Unemployedss { get; set; }
        public ObservableCollection<Course> Courses { get; set; }

        public PageJobSearch()
        {
           InitializeComponent();
           DataContext = new PageJobSearchVM();

        }
        
        private void Button_Tab1(object sender, RoutedEventArgs e)
        {
            
            WindowDialog windowDialog = new WindowDialog();
            windowDialog.Show();
        }
      
    }
}

