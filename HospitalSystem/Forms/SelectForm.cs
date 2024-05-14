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
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void buttonEmployes_Click(object sender, EventArgs e)
        {
            EmployeTableForm form = new EmployeTableForm();
            form.Show();
        }

        private void buttonPatients_Click(object sender, EventArgs e)
        {
            PatientTableForm form = new PatientTableForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindFreeRecordsForm form = new FindFreeRecordsForm();
            form.Show();
        }

        private void SelectForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
