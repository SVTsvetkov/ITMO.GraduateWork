using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class HospitalContext : DbContext
    {
        static HospitalContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public HospitalContext() : base("DBConnection")
        {
            
        }
    
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RecordService> RecordServices { get; set; }
    }
}
