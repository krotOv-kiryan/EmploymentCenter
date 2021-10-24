using Employment_Center;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace EmploymentCenter
{
    internal class MainVM : INotifyPropertyChanged
    {
        Db db;
        public Page CurrentPage { get; set; }

        public Command OpenWindowUnemployed { get; set; }
        public Command OpenWindowEmployer { get; set; }
        public Command OpenWindowEmployerDirection { get; set; }
        public Command OpenWindowJobSearch { get; set; }
        public Command OpenWindowAdd { get; set; }
        public Command OpenWindowArchive { get; set; }

        public MainVM()
        {
            //Db = Db.GetDb();
            OpenWindowUnemployed = new Command(() => { CurrentPage = new PageUnemployed(); SignalChanged("CurrentPage"); });
            OpenWindowEmployer = new Command(() => { CurrentPage = new PageEmployer(); SignalChanged("CurrentPage"); });
            OpenWindowEmployerDirection = new Command(() => { CurrentPage = new PageEmployerDirection(); SignalChanged("CurrentPage"); });
            OpenWindowJobSearch = new Command(() => { CurrentPage = new PageJobSearch(); SignalChanged("CurrentPage"); });
            OpenWindowArchive = new Command(() => { CurrentPage = new PageArchive(); SignalChanged("CurrentPage"); });
            OpenWindowAdd = new Command(() => { CurrentPage = new PageAdd(); SignalChanged("CurrentPage"); });
        }
        void SignalChanged([CallerMemberName] string prop = null) =>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
