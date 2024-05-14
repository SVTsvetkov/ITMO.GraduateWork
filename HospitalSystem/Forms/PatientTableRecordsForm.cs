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
    public partial class PatientTableRecordsForm : Form
    {
        private Patient patient;

        public PatientTableRecordsForm(Patient patient)
        {
            InitializeComponent();

            this.patient = patient;

            ShowData();
        }

        private void ShowData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            if (patient.Records.Count > 0)
            {
                dataGridView1.DataSource = patient.Records.OrderByDescending(t=>t.Date).ToList();
                dataGridView1.Refresh();
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Record record = (Record)dataGridView1.SelectedRows[0].DataBoundItem;
                PatientRecordForm form = new PatientRecordForm(patient, record);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }
                private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно желаете удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Record record = (Record)dataGridView1.SelectedRows[0].DataBoundItem;
                    patient.Records.Remove(record);

                    DBController.Instance.Save();
                    ShowData();
                }
            }
        }
    }
}
