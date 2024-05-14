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
    public partial class ScheduleTableForm : Form
    {
        private Employee employee;
        public ScheduleTableForm(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;

            if (employee.Schedules.Count == 0 )
            {
                var days = Enum.GetValues(typeof(DayOfWeek));
                foreach (DayOfWeek day in days )
                {
                    ScheduleDoctor scheduleDoctor = new ScheduleDoctor();
                    scheduleDoctor.DayOfWeek = day;
                    scheduleDoctor.Start = new TimeSpan(9, 0, 0);
                    scheduleDoctor.Finish = new TimeSpan(18, 0, 0);
                    employee.Schedules.Add(scheduleDoctor);
                }
                DBController.Instance.Save();
            }
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = employee.Schedules;
        }

        private void ScheduleTableForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ApplicationHelper.Instance.CurrentEmployee.TypePost == TypePost.MainManager)
            {
                ScheduleDoctor scheduleDoctor = dataGridView1.SelectedRows[0].DataBoundItem as ScheduleDoctor;

                EditScheduleForm form = new EditScheduleForm(scheduleDoctor);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
