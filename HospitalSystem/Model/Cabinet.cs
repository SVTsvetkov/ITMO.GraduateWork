﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class Cabinet
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
