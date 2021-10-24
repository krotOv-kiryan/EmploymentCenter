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
    public class EmployerVM : INotifyPropertyChanged
    {
        Db Db;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }

        public Command AddVacancy{ get; set; }
        public Command SaveVacancy { get; set; }
        public Command DeleteVacancy { get; set; }

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
        public List<string> Educations { get; set; }
        public List<string> Employments { get; set; }
        public List<string> Schedules { get; set; }

        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void LoadVacancies()
        {
            Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies.Where(u => u.ResultVacancy != "Закрыта"));
            SignalChanged("Vacancies");
        }

        public EmployerVM()
        {
            Db = Db.GetDb();

            Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies.Where(u => u.ResultVacancy != "Закрыта")); ;
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);

            Educations = new List<string>(new string[] { "Среднее", "Среднее профессиональное", "Незаконченное высшее", "Высшее",
                "Магистр", "Доктор наук", "Не имеется" });

            Employments = new List<string>(new string[] { "Полная", "Продуктивная", "Свободно избранная", "Рациональная" });

            Schedules = new List<string>(new string[] { "Обычный (односменный)", "Ненормированный день", "Гибкий график", 
                "Сменная работа", "Вахтовый метод", "Раздробленный рабочий день"});

            AddVacancy = new Command(() =>
            {
                var vacancy = new Vacancy { Name = "Вакансия", ResultVacancy = "В ожидании", Schedule = "Обычный (односменный)",
                    Employment = "Полная", Education = "Не имеется", Specialty = "Специальность" };

                Db.Vacancies.Add(vacancy);
                SelectedVacancy = vacancy;
            });

            SaveVacancy = new Command(() =>
            {
                try
                {
                    Db.SaveChanges();
                    LoadVacancies();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            DeleteVacancy = new Command(() =>
            {
                 Db.Vacancies.Remove(selectedVacancy);
                 Db.SaveChanges();
                LoadVacancies();
             });

        }

    }
}
