using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    [Table("Employee")]
    public class Employee : Person
    {
        public TypePost TypePost { get; set; }
        public virtual Specialization Specialization { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public virtual Cabinet Cabinet { get; set; }

        public virtual List<ScheduleDoctor> Schedules { get; set; } = new List<ScheduleDoctor>();
        public virtual List<Record> Records { get; set; } = new List<Record>();
    }
}
