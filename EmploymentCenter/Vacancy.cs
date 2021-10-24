using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; } //название
        public string Firm { get; set; } //фирма    
        public string Salary { get; set; }//зп(всегда в рублях)
        public string Position { get; set; }//требуемая должность
        public string Employment { get; set; }//занятость
        public string Schedule { get; set; }//график
        public string Specialty { get; set; }//требуемая специальность
        public ProfeccionalArea ProfeccionalArea { get; set; }
        public string Experience { get; set; } // требуемый опыт работы
        public string Education { get; set; } // требуемое образование
        public long Contact { get; set; }//контактные данные вакансии
        public string ResultVacancy { get; set; } // результат - принят/ не принято
       // public string idUnemployed { get; set; }
       public List<Unemployed> Unemployeds { get; set; }

        //public Unemployed Unemployed { get; set; }
       // в архиве или нет. Если нет - отображаем в списке доступных к взаимодействию.
                                          // Если да - отображаем в окне Архив и делаем недоступным для взаимодействия на других окнах,кроме архива.

    }
}
