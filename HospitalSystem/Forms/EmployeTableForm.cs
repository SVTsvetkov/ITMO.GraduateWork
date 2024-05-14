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
    public partial class EmployeTableForm : Form
    {
        public EmployeTableForm()
        {
            InitializeComponent();

            comboBoxSpec.DataSource = DBController.Instance.GetSpecializations();

            ShowData();

            menuStrip1.Visible = ApplicationHelper.Instance.CurrentEmployee.TypePost == TypePost.MainManager;
        }

        private void ShowData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DBController.Instance.GetEmloyees().OrderBy(t => t.Surname).ToList();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EmployeeForm employeeForm = new EmployeeForm();
            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                ShowData();
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee employee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem;
                EmployeeForm employeeForm = new EmployeeForm(employee);
                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно желаете удалить запись?", "Удаление", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Employee employee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem;                 
                    DBController.Instance.Remove(employee);
                    ShowData();
                }
            }
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DBController.Instance.GetEmloyees().
                Where(t => t.Surname == textBoxSurname.Text).ToList();
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            ShowData();            
            textBoxSurname.Clear();
            comboBoxSpec.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxSpec.SelectedIndex != -1)
            {
                Specialization specialization = (Specialization)comboBoxSpec.SelectedItem;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DBController.Instance.GetEmloyees().
                    Where(t => t.Specialization == specialization).
                    OrderBy(t => t.Surname).ToList();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                TypePost typePost = (TypePost)e.Value;
                switch (typePost)
                {
                    case TypePost.Assistant:
                        e.Value = "Ассистент";
                        break;
                    case TypePost.Doctor:
                        e.Value = "Врач";
                        break;
                    case TypePost.Administrator:
                        e.Value = "Администратор";
                        break;
                    case TypePost.MainManager:
                        e.Value = "Управляющий";
                        break;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee employee = (Employee)dataGridView1.SelectedRows[0].DataBoundItem;
                EmployeeForm employeeForm = new EmployeeForm(employee);
                employeeForm.IsReadOnly = true;
                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }
            }
        }
    }
}
