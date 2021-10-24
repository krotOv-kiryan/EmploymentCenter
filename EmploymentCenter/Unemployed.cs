using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter
{
    public class Unemployed
    {
        public int Id { get; set; }
        public string FIO { get; set; }//ФИО
        public string Address { get; set; }//Адрес проживания
        public string Specialty { get; set; }//профессия/специальность
        public long Contact { get; set; }//контактные данные
        public DateTime Birthday { get; set; }
        public bool Male { get; set; }//пол 
        public string Experience { get; set; } // опыт работы   
        public ProfeccionalArea ProfeccionalArea { get; set; }
        public Course Course { get; set; }
        public string Education { get; set; }
        public string ResultUnemployed { get; set; }
        //public string idVacancy { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
