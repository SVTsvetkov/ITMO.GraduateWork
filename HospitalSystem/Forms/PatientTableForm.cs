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
    public partial class PatientTableForm : Form
    {
        public PatientTableForm()
        {
            InitializeComponent();

            ShowData();

            удалитьToolStripMenuItem.Visible = ApplicationHelper.Instance.CurrentEmployee.TypePost == TypePost.MainManager;

            if (ApplicationHelper.Instance.CurrentEmployee.TypePost == TypePost.Doctor ||
                ApplicationHelper.Instance.CurrentEmployee.TypePost == TypePost.Assistant)
            {
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
        }

        private void ShowData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DBController.Instance.GetPatients().OrderBy(t=>t.Surname).ToList();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientForm form = new PatientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowData();
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Patient patient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;
                PatientForm form = new PatientForm(patient);
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
                    Patient patient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;

                    DBController.Instance.Remove(patient);
                    ShowData();
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DBController.Instance.GetPatients().Where(t=>t.Surname == textBoxSurname.Text).ToList();

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
