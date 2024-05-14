using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class DBController
    {
        private static DBController instance;
        private HospitalContext context = new HospitalContext();

        public static DBController Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBController();
                return instance;
            }
        }

        public void Add(Employee employee)
        {
            if (employee.Id == 0)
                context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Remove(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public List<Employee> GetEmloyees()
        {
            return context.Employees.ToList();
        }

        public void Add(Patient patient)
        {
            if (patient.Id == 0)
                context.Patients.Add(patient);
            context.SaveChanges();
        }

        public void Remove(Patient patient)
        {
            context.Patients.Remove(patient);
            context.SaveChanges();
        }

        public List<Patient> GetPatients()
        {
            return context.Patients.ToList();
        }

        public List<Specialization> GetSpecializations()
        {
            return context.Specializations.ToList();
        }

        public List<Service> GetServices()
        {
            return context.Services.ToList();
        }

        public List<Cabinet> GetCabinets()
        {
            return context.Cabinets.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public List<RecordService> GetRecordServices()
        {
            return context.RecordServices.ToList();
        }
    }
}
