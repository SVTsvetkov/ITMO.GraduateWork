using System;
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
    public partial class DoctorRecords : Form
    {
        Employee employee;

        public DoctorRecords(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;

            ShowData();
        }

        private void ShowData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = employee.Records.
                Where(t => t.Date.Date == dateTimePicker1.Value.Date).
                OrderBy(t=>t.Time).
                ToList();
        }

        private void DoctorRecords_Load(object sender, EventArgs e)
        {

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
