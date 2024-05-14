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
    public partial class FindFreeRecordsForm : Form
    {
        public FindFreeRecordsForm()
        {
            InitializeComponent();

            comboBoxSpec.DataSource = DBController.Instance.GetSpecializations();
            comboBoxService.DataSource = DBController.Instance.GetServices();
        }

        private void FindFreeRecordsForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ShowFreeTime();
        }

        void ShowFreeTime()
        {
            dataGridView2.DataSource = null;

            if (dataGridView1.SelectedRows.Count == 0)
                return;

            DateTime date = dateTimePicker1.Value.Date;
            Employee employee = dataGridView1.SelectedRows[0].DataBoundItem as Employee;

            var records = employee.Records.Where(t => t.Date.Date == date);
            List<FreeTime> freeTime = new List<FreeTime>();

            var schedule = employee.Schedules.FirstOrDefault(t => t.DayOfWeek == date.DayOfWeek);
            for (int i = schedule.Start.Hours; i < schedule.Finish.Hours; i++)
            {
                if (!records.Any(t => t.Time.Hours == i))
                {
                    freeTime.Add(new FreeTime(new TimeSpan(i, 0, 0), new TimeSpan(i + 1, 0, 0)));
                }
            }
            dataGridView2.DataSource = freeTime;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            Specialization specialization = comboBoxSpec.SelectedItem as Specialization;

            var doctors = DBController.Instance.GetEmloyees().Where(t => t.TypePost == TypePost.Doctor && t.Specialization == specialization);
            List<Employee> employees = new List<Employee>();
            foreach (Employee employee in doctors)
            {
                var records = employee.Records.Where(t => t.Date.Date == date);
                bool check = false;
                var schedule = employee.Schedules.FirstOrDefault(t => t.DayOfWeek == date.DayOfWeek);
                for (int i = schedule.Start.Hours; i < schedule.Finish.Hours; i++)
                {
                    if (!records.Any(t => t.Time.Hours == i))
                    {
                        check = true;
                    }
                }
                if (check)
                    employees.Add(employee);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = employees;
        }

        private void buttonCreateRecord_Click(object sender, EventArgs e)
        {
            if (comboBoxSpec.SelectedItem == null || comboBoxService.SelectedItem == null)
            {
                MessageBox.Show("Выберите специализацию и услугу");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите врача");
                return;
            }

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите время");
                return;
            }

            FindPatientForm form = new FindPatientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Patient patient = form.Patient;
                Employee employee = dataGridView1.SelectedRows[0].DataBoundItem as Employee;
                FreeTime time = dataGridView2.SelectedRows[0].DataBoundItem as FreeTime;

                Record record = new Record();
                patient.Records.Add(record);
                record.Employee = employee;
                record.Date = dateTimePicker1.Value;
                record.Time = time.Start;
                record.Service = (Service)comboBoxService.SelectedItem;

                DBController.Instance.Save();

                MessageBox.Show("Запись успешно создана");
                ShowFreeTime();
            }
        }
    }
}
