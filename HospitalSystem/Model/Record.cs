using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class Record
    {
        public int Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Diagnosis { get; set; }
        public virtual List<RecordService> Services { get; set; } = new List<RecordService>(); 
        public int TotalCost => Services.Sum(t => t.Cost); 
        public virtual Service Service { get; set; }
    }
}
