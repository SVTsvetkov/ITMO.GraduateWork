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
    public partial class FindPatientForm : Form
    {
        private Patient patient;
        public Patient Patient => patient;

        public FindPatientForm()
        {
            InitializeComponent();
            ShowData();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DBController.Instance.GetPatients().Where(t => t.Surname == textBoxSurname.Text).ToList();
        }

        private void ShowData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DBController.Instance.GetPatients().OrderBy(t => t.Surname).ToList();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            patient = dataGridView1.SelectedRows[0].DataBoundItem as Patient;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            PatientForm form = new PatientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowData();
            }
        }
    }
}
