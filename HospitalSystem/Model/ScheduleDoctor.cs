using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class ScheduleDoctor
    {
        public int Id { get; set; }
        public virtual Employee Employee { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
    }
}
