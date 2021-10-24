using Employment_Center;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmploymentCenter
{
    public class UnemployedVM : INotifyPropertyChanged
    {
        Db Db;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Unemployed> Unemployeds { get; set; }
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }
        public ObservableCollection<Course> Courses { get; set; }

        public Command AddUnemployed { get; set; }
        public Command SaveUnemployed { get; set; }
        public Command DeleteUnemployed { get; set; }

        public List<string> Educations { get; set; }
        public List<MaleStruct> Males { get; set; }

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

        private void LoadUnemployeds()
        {
            Unemployeds = new ObservableCollection<Unemployed>(Db.Unemployeds.Where(u => u.ResultUnemployed != "Закрыта"));
            SignalChanged("Unemployeds");
        }
        public UnemployedVM()
        {   
            Db = Db.GetDb();
            Unemployeds = new ObservableCollection<Unemployed>(Db.Unemployeds.Where(u => u.ResultUnemployed != "Закрыта"));
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);
            Courses = new ObservableCollection<Course>(Db.Courses);

            Males = new List<MaleStruct>(new MaleStruct[] {
                new MaleStruct { Name = "Мужской", Value = true} ,
                new MaleStruct { Name = "Женский", Value = false } });

            Educations = new List<string>(new string[] { "Среднее", "Среднее профессиональное", "Незаконченное высшее",
                "Высшее", "Магистр", "Доктор наук", "Не имеется" });

            /*ProfeccionalAreas = new List<string>(new string[] { "Среднее", "", "",
                "", "", "", "" });*/

            AddUnemployed = new Command(() =>
            {
                var unemployed = new Unemployed { FIO = "Имя", ResultUnemployed = "В ожидании", Specialty="Специальность", Education = "Не имеется" };//, Birthday = Birthday.Today 
                Db.Unemployeds.Add(unemployed);
                SelectedUnemployed = unemployed;
            });

            SaveUnemployed = new Command(() =>
            {
                try
                {
                    Db.SaveChanges();
                    LoadUnemployeds();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            DeleteUnemployed = new Command(() =>
            {
                Db.Unemployeds.Remove(selectedUnemployed);
                Db.SaveChanges();
                LoadUnemployeds();
            });

        }
    
    }
       
}
