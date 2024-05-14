using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{ 
    public class ApplicationHelper
    {
        private static ApplicationHelper instance;

        public static ApplicationHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationHelper();
                }
                return instance;
            }
        }
        public Employee CurrentEmployee { get; set; }
    }
}
