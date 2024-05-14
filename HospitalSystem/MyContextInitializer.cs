using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class MyContextInitializer : CreateDatabaseIfNotExists<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
            base.Seed(context);

            int[] numberCabinets = {1,2,3,4,5};
            for (int i = 0; i < numberCabinets.Length; i++)
            {
                Cabinet cabinet = new Cabinet();
                cabinet.Number = numberCabinets[i];
                context.Cabinets.Add(cabinet);
            }

            string[] specName = { "гигиенист", "терапевт", "хирург", "имплантолог", "ортопед",
                "ортодонт", "детский стоматолог", "парадонтолог" };

            foreach (var item in specName)
            {
                Specialization specialization = new Specialization();
                specialization.Name = item;
                context.Specializations.Add(specialization);
            }

            string[] serviceNames = { "Консультация и диагностика", "Лечение зубов", "Микропротезирование",
                "Хирургия и имплантация", "Протезирование зубов (ортопедия)", "Установка ортодонтических контрукций (ортодонтия)",
                "Профессиональная гигиена полости рта", "Отбеливание зубов",
                "Лечение десен (пародонтология)" };

            foreach (var item in serviceNames)
            {
                Service service = new Service();
                service.Name = item;
                context.Services.Add(service);
            }

            Employee employee = new Employee();
            employee.Login = "admin";
            employee.Password = "admin";
            employee.TypePost = TypePost.MainManager;
            employee.Birthday = DateTime.Now;
            context.Employees.Add(employee);

            context.SaveChanges();
        }
    }
}
