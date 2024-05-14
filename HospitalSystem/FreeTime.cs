using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    [NotMapped] 
    public class FreeTime
    {        public FreeTime(TimeSpan start, TimeSpan finish)
        {
            Start = start;
            Finish = finish;
        }

        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }

    }
}
