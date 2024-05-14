using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class RecordService
    {
        public int Id { get; set; }
        public virtual Service Service { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public virtual Record Record { get; set; }
        public DateTime Date => Record.Date;
        public Employee Employee => Record.Employee;
    }
}
