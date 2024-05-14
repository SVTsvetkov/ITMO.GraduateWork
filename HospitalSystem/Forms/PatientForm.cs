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
    public partial class PatientForm : Form
    {
        Patient patient;

        public PatientForm(Patient patient = null)
        {
            InitializeComponent();

            this.patient = patient;

            if(patient != null )
            {
                textBoxName.Text = patient.Name;
                textBoxSurname.Text = patient.Surname;
                textBoxMiddleName.Text = patient.MiddleName;
                comboBoxSex.SelectedIndex = (int)patient.Sex;
                textBoxEmail.Text = patient.Email;
                dateTimePicker1.Value = patient.Birthday;
                textBoxPhone.Text = patient.Phone;
                comboBoxStatus.SelectedIndex = (int)patient.Status;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxSurname.Text == "")
            {
                MessageBox.Show("Введите имя и фамилию");
                return;
            }

            if (patient == null)
                patient = new Patient();

            patient.Name = textBoxName.Text;
            patient.Surname = textBoxSurname.Text;
            patient.MiddleName = textBoxMiddleName.Text;
            patient.Sex = (Sex)comboBoxSex.SelectedIndex;
            patient.Email = textBoxEmail.Text;
            patient.Birthday = dateTimePicker1.Value;
            patient.Phone = textBoxPhone.Text;
            patient.Status = (StatusPatient)comboBoxStatus.SelectedIndex;

            DBController.Instance.Add(patient);

            DialogResult = DialogResult.OK;
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            if (patient == null)
                MessageBox.Show("Сначала сохраните данные пациента");
            else
            {
                PatientTableRecordsForm form = new PatientTableRecordsForm(patient);
                form.ShowDialog();
            }
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            if (patient == null)
                MessageBox.Show("Сначала сохраните данные пациента");
            else
            {
                PatientAllServicesForm form = new PatientAllServicesForm(patient);
                form.ShowDialog();
            }
        }
    }
}
