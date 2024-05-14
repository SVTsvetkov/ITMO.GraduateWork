using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    [Table("Patient")]
    public class Patient : Person
    {
        public StatusPatient Status { get; set; }
        public string Diseases { get; set; }

        public virtual List<Record> Records { get; set; } = new List<Record>();
       
    }
}
