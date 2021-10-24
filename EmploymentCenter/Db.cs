using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EmploymentCenter;
using System.IO;

namespace Employment_Center
{
    public class Db : DbContext
    {
        static Db db;
        private Db()
        {
            Database.EnsureCreated();
        }

        public static Db GetDb()
        {
            if (db == null)
                db = new Db();
            return db;
        }

        public DbSet<ProfeccionalArea> ProfeccionalAreas { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Unemployed> Unemployeds { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sb = new SqlConnectionStringBuilder();

            sb.DataSource = File.ReadAllText("sqlserver.txt");  // DESKTOP-G64T7H2
            sb.InitialCatalog = "EmploymentCenter250521";
            sb.IntegratedSecurity = true;

            optionsBuilder.UseSqlServer(sb.ToString());

            base.OnConfiguring(optionsBuilder);
        }

    }
}
