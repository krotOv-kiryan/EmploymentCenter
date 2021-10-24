using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter
{
    public class ProfeccionalArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Unemployed> Unemployeds { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
