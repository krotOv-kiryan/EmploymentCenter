using Employment_Center;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter
{
    public class WindowEmployerDirectionVM : INotifyPropertyChanged
    {
        Db Db;

        public int pay { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Unemployed> Unemployeds { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }

        public Command Apply { get; set; }
        public Command CountingCommand { get; set; }

        private Vacancy selectedVacancy;
        public Vacancy SelectedVacancy
        {
            get => selectedVacancy;
            set
            {
                selectedVacancy = value;
                SignalChanged();
            }
        }

        private Unemployed selectedUnemployed;
        public Unemployed SelectedUnemployed
        {
            get => selectedUnemployed;
            set
            {
                selectedUnemployed = value;
                SignalChanged();
            }
        }

        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        
        public WindowEmployerDirectionVM()
        {
            Db = Db.GetDb();

            Unemployeds = new ObservableCollection<Unemployed>(Db.Unemployeds.Where(u => u.ResultUnemployed != "Закрыта")); ;
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);
            Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies.Where(u => u.ResultVacancy != "Закрыта")); ;
            Courses = new ObservableCollection<Course>(Db.Courses);

            Apply = new Command(() =>
            {
                if (selectedUnemployed != null && selectedVacancy != null)
                {
                    selectedUnemployed.ResultUnemployed = "Закрыта";
                    selectedVacancy.ResultVacancy = "Закрыта";
                    selectedUnemployed.Vacancy = selectedVacancy;
                    Db.SaveChanges();
                }
            });

             CountingCommand = new Command(()=>
             {
                  
                 int m = 0;
                 foreach(var f in Db.Unemployeds)
                 {
                     if (f.ResultUnemployed == "Закрыта")
                     {
                         m++;
                     }
                 }
                 pay = m; 
                 Db.SaveChanges();
                 SignalChanged(nameof(pay));
             });
            
        }

    }
}