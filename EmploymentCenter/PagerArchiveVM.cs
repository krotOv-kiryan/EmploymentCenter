using Employment_Center;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter
{
    internal class PagerArchiveVM : INotifyPropertyChanged
    {
        Db Db;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }
        public ObservableCollection<Unemployed> Unemployeds { get; set; }
        public List<string> ResultVacancy { get; set; }
        public List<string> ResultUnemployed { get; set; }

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
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public Command ChangeStatus { get; set; }
        public Command ChangeStatusVacancy { get; set; }
       
        public PagerArchiveVM()
        {
            Db = Db.GetDb();

            Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies);
            Unemployeds = new ObservableCollection<Unemployed>(Db.Unemployeds);
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);
            Courses = new ObservableCollection<Course>(Db.Courses);

            ResultUnemployed = new List<string>(new string[] { "Закрыта", "В ожидании", "На учёте" });
            ResultVacancy = new List<string>(new string[] { "Закрыта", "В ожидании" });

            ChangeStatus = new Command(()=> {
                Db.SaveChanges();
            });

            ChangeStatusVacancy = new Command(() => {
                    Db.SaveChanges();
            });
        }

           
    }
}