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
    public partial class PatientRecordForm : Form
    {
        Record record;
        Patient patient;
        List<RecordService> recordServices = new List<RecordService>();

        public PatientRecordForm(Patient patient, Record record = null)
        {
            InitializeComponent();

            this.record = record;
            this.patient = patient;

            if (record != null ) {
                textBoxDoctor.Text = record.Employee.ToString();
                textBoxDate.Text = record.Date.ToShortDateString();
                textBoxCost.Text = record.TotalCost.ToString();
                textBoxDiagnoz.Text = record.Diagnosis;
                textBoxTime.Text = record.Time.ToString("hh\\:mm");
                recordServices = record.Services;
                textBoxService.Text = record.Service.Name;

                ShowData();
            }
        }

        private void ShowData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            if (recordServices.Count > 0)
            {
                dataGridView1.DataSource = recordServices;
                dataGridView1.Refresh();
            }

            textBoxCost.Text = record.TotalCost.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (record == null)
            {
                record = new Record();
                patient.Records.Add(record);
            }
            record.Time = TimeSpan.Parse(textBoxTime.Text);
            record.Diagnosis = textBoxDiagnoz.Text;
            record.Services = recordServices;

            DBController.Instance.Save();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (record == null)
            {
                MessageBox.Show("Сначала сохраните данные");
            }
            else
            {
                PatientServiceForm form = new PatientServiceForm(record);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                RecordService recordService = (RecordService)dataGridView1.SelectedRows[0].DataBoundItem;
                PatientServiceForm form = new PatientServiceForm(record, recordService);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно желаете удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RecordService recordService = (RecordService)dataGridView1.SelectedRows[0].DataBoundItem;
                    record.Services.Remove(recordService);

                    DBController.Instance.Save();
                    ShowData();
                }
            }
        }
    }
}
