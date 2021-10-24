using Employment_Center;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace EmploymentCenter
{
    internal class PageJobSearchVM : INotifyPropertyChanged
    {
        Db Db;
        Vacancy Vacancy;
        public event PropertyChangedEventHandler PropertyChanged; 
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public ObservableCollection<Unemployed> Unemployeds { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }

        public ICollectionView VacanciesCollectionView { get; set; }
        public ICollectionView UnemployedsCollectionView { get; set; }
      
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
       
        public PageJobSearchVM()
        {
            Db = Db.GetDb();
            Unemployeds = new ObservableCollection<Unemployed>(Db.Unemployeds.Where(u => u.ResultUnemployed != "Закрыта"));
            Vacancies = new ObservableCollection<Vacancy>(Db.Vacancies.Where(u => u.ResultVacancy != "Закрыта"));
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);
            Courses = new ObservableCollection<Course>(Db.Courses);

            VacanciesCollectionView = CollectionViewSource.GetDefaultView(Vacancies);
            VacanciesCollectionView.Filter = FilterVacancies;
            VacanciesCollectionView.SortDescriptions.Add(new SortDescription(nameof(Vacancy.Name), ListSortDirection.Ascending));

            UnemployedsCollectionView = CollectionViewSource.GetDefaultView(Unemployeds);
            UnemployedsCollectionView.Filter = FilterUnemployeds;
            UnemployedsCollectionView.SortDescriptions.Add(new SortDescription(nameof(Unemployed.FIO), ListSortDirection.Ascending));
        }
        //
        
            private string _idsFilter = string.Empty;
        public string IdsFilter
        {
            get
            {
                return _idsFilter;
            }
            set
            {
                _idsFilter = value;
                OnPropertyChanged(nameof(IdsFilter));
                UnemployedsCollectionView.Refresh();
            }
        }
        //
        private string _unemployedsFilter = string.Empty;
        public string UnemployedsFilter
        {
            get
            {
                return _unemployedsFilter;
            }
            set
            {
                _unemployedsFilter = value;
                OnPropertyChanged(nameof(UnemployedsFilter));
                UnemployedsCollectionView.Refresh();
            }
        }
        //
        private string _expFilter = string.Empty;
        public string ExpsFilter
        {
            get
            {
                return _expFilter;
            }
            set
            {
                _expFilter = value;
                OnPropertyChanged(nameof(ExpsFilter));
                UnemployedsCollectionView.Refresh();
            }
        }
        //
        private bool FilterUnemployeds(object obj)
        {
            if (obj is Unemployed unemployed)
            {
                string p = unemployed.Vacancy?.ToString() ?? "";

                return unemployed.FIO.Contains(UnemployedsFilter, StringComparison.InvariantCultureIgnoreCase) &&
                unemployed.ProfeccionalArea?.Name.Contains(SpheresFilter, StringComparison.InvariantCultureIgnoreCase) == true && //| false
                unemployed.Specialty.Contains(SpecialtiesFilter, StringComparison.InvariantCultureIgnoreCase) &&
                unemployed.Education.Contains(EducationsFilter, StringComparison.InvariantCultureIgnoreCase)&&
                p.Contains(IdsFilter, StringComparison.InvariantCultureIgnoreCase) &&
                unemployed.Experience?.Contains(ExpsFilter, StringComparison.InvariantCultureIgnoreCase) == true;
              //  p.Contains(DateFilter, StringComparison.Ordinal);
                //unemployed.Birthday.Contains(DateFilter, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
        //
       /* private string _idusFilter = string.Empty;
        public string IdusFilter
        {
            get
            {
                return _idusFilter;
            }
            set
            {
                _idusFilter = value;
                OnPropertyChanged(nameof(IdusFilter));
                UnemployedsCollectionView.Refresh();
            }
        }*/
        //
        private string _dateFilter = string.Empty;
        public string DateFilter
        {
            get
            {
                return _dateFilter;
            }
            set
            {
                _dateFilter = value;
                OnPropertyChanged(nameof(DateFilter));
                UnemployedsCollectionView.Refresh();
            }
        }

        //
        private string _specialtiesFilter = string.Empty;
        public string SpecialtiesFilter
        {
            get
            {
                return _specialtiesFilter;
            }
            set
            {
                _specialtiesFilter = value;
                OnPropertyChanged(nameof(SpecialtiesFilter));
                
                VacanciesCollectionView.Refresh();
                UnemployedsCollectionView.Refresh();
            }
        }
        //
        private string _educationsFilter = string.Empty;
        public string EducationsFilter
        {
            get
            {
                return _educationsFilter;
            }
            set
            {
                _educationsFilter = value;
                OnPropertyChanged(nameof(EducationsFilter));
                VacanciesCollectionView.Refresh();
                UnemployedsCollectionView.Refresh();
            }
        }
        //
        private string _schedulesFilter = string.Empty;
        public string SchedulesFilter
        {
            get
            {
                return _schedulesFilter;
            }
            set
            {
                _schedulesFilter = value;
                OnPropertyChanged(nameof(SchedulesFilter));
                VacanciesCollectionView.Refresh();
            }
        }
        //
        private string _empsFilter = string.Empty;
        public string EmpFilter
        {
            get
            {
                return _empsFilter;
            }
            set
            {
                _empsFilter = value;
                OnPropertyChanged(nameof(EmpFilter));
                VacanciesCollectionView.Refresh();
            }
        }
        //
        private string _spheresFilter = string.Empty;
        public string SpheresFilter
        {
            get
            {
                return _spheresFilter;
            }
            set
            {
                _spheresFilter = value;
                OnPropertyChanged(nameof(SpheresFilter));
                VacanciesCollectionView.Refresh();
                UnemployedsCollectionView.Refresh();
            }
        }
        //
        private string _vacanciesFilter = string.Empty;
        public string VacanciesFilter
        {
            get
            {
                return _vacanciesFilter;
            }
            set
            {
                _vacanciesFilter = value;
                OnPropertyChanged(nameof(VacanciesFilter));
                VacanciesCollectionView.Refresh();
            }
        }
        //
        private bool FilterVacancies(object obj)
        {
            
          //  string b = Vacancy.Id.ToString();
            if (obj is Vacancy vacancy)
            {
                return vacancy.Name.Contains(VacanciesFilter, StringComparison.InvariantCultureIgnoreCase) &&
                vacancy.ProfeccionalArea?.Name.Contains(SpheresFilter, StringComparison.InvariantCultureIgnoreCase) == true &&
                vacancy.Specialty.Contains(SpecialtiesFilter, StringComparison.InvariantCultureIgnoreCase) &&
                vacancy.Employment.Contains(EmpFilter, StringComparison.InvariantCultureIgnoreCase) &&
                vacancy.Schedule.Contains(SchedulesFilter, StringComparison.InvariantCultureIgnoreCase) &&
               // b.Contains(IdsFilter, StringComparison.InvariantCultureIgnoreCase) &&
                vacancy.Education.Contains(EducationsFilter, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
        //
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
  
}