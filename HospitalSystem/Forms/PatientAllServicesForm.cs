﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem
{
    public partial class PatientAllServicesForm : Form
    {
        public PatientAllServicesForm(Patient patient)
        {
            InitializeComponent();

            dataGridView1.DataSource = patient.Records.SelectMany(t=>t.Services).OrderByDescending(t=>t.Date).ToList();
        }
    }
}
