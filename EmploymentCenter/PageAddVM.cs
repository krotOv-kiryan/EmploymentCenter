using Employment_Center;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmploymentCenter
{
    internal class PageAddVM : INotifyPropertyChanged
    {
        Db Db;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<ProfeccionalArea> ProfeccionalAreas { get; set; }

        public Command AddProfeccionalArea { get; set; }
        public Command SaveProfeccionalArea { get; set; }
        public Command DeleteProfeccionalArea { get; set; }

        private ProfeccionalArea selectedProfeccionalArea;
        public ProfeccionalArea SelectedProfeccionalArea
        {
            get => selectedProfeccionalArea;
            set
            {
                selectedProfeccionalArea = value;
                SignalChanged();
            }
        }

        public Command AddCourse { get; set; }
        public Command SaveCourse { get; set; }
        public Command DeleteCourse { get; set; }

        private Course selectedCourse;
        public Course SelectedCourse
        {
            get => selectedCourse;
            set
            {
                selectedCourse = value;
                SignalChanged();
            }
        }
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


        private void LoadCourses()
        {
            Courses = new ObservableCollection<Course>(Db.Courses);
            SignalChanged("Courses");
        }
        private void LoadProfeccionalAreas()
        {
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);
            SignalChanged("ProfeccionalAreas");
        }
        public PageAddVM()
        {
            Db = Db.GetDb();
            LoadCourses();
            LoadProfeccionalAreas();
            ProfeccionalAreas = new ObservableCollection<ProfeccionalArea>(Db.ProfeccionalAreas);
            Courses = new ObservableCollection<Course>(Db.Courses);

            AddCourse = new Command(() =>
            {
                var course = new Course { Name = "Курс" };

                Db.Courses.Add(course);
                SelectedCourse = course;
            });

            SaveCourse = new Command(() =>
            {
                try
                {
                    Db.SaveChanges();
                    LoadCourses();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            DeleteCourse = new Command(() =>
            {
                Db.Courses.Remove(selectedCourse);
                Db.SaveChanges();
                LoadCourses();
            });
            AddProfeccionalArea = new Command(() =>
            {
                var profeccionalArea = new ProfeccionalArea { Name = "Название" };

                Db.ProfeccionalAreas.Add(profeccionalArea);
                SelectedProfeccionalArea = profeccionalArea;
            });

            SaveProfeccionalArea = new Command(() =>
            {
                try
                {
                    Db.SaveChanges();
                    LoadProfeccionalAreas();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            DeleteProfeccionalArea = new Command(() =>
            {
                Db.ProfeccionalAreas.Remove(selectedProfeccionalArea);
                Db.SaveChanges();
                LoadProfeccionalAreas();
            });

        }
    }
}