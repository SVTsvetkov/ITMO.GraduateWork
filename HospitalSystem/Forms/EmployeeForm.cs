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
    public partial class EmployeeForm : Form
    {
        private Employee employee;
        public bool IsReadOnly { get; set; } = false;

        public EmployeeForm(Employee employee = null)
        {
            InitializeComponent();

            comboBoxCabinet.DataSource = DBController.Instance.GetCabinets();
            comboBoxSpec.DataSource = DBController.Instance.GetSpecializations();

            comboBoxSpec.SelectedItem = null;
            comboBoxCabinet.SelectedItem = null;

            if (employee != null)
            {
                this.employee = employee;

                textBoxName.Text = employee.Name;
                textBoxSurname.Text = employee.Surname;
                textBoxMiddleName.Text = employee.MiddleName;
                comboBoxSex.SelectedIndex = (int)employee.Sex;
                comboBoxPost.SelectedIndex = (int)employee.TypePost;
                comboBoxSpec.SelectedItem = employee.Specialization;
                textBoxEmail.Text = employee.Email;
                dateTimePicker1.Value = employee.Birthday;
                textBoxLogin.Text = employee.Login;
                textBoxPassword.Text = employee.Password;
                textBoxPhone.Text = employee.Phone;
                comboBoxCabinet.SelectedItem = employee.Cabinet;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxSurname.Text == "")
            {
                MessageBox.Show("Введите имя и фамилию");
                return;
            }

            if (comboBoxSex.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите пол");
                return;
            }

            if (comboBoxPost.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите должность");
                return;
            }

            TypePost typePost = (TypePost)comboBoxPost.SelectedIndex;
            if (typePost == TypePost.Doctor || typePost == TypePost.Assistant)
            {
                if (comboBoxCabinet.SelectedItem == null)
                {
                    MessageBox.Show("Выберите кабинет");
                    return;
                }
            }

            if (typePost == TypePost.Doctor)
            {
                if (comboBoxSpec.SelectedItem == null)
                {
                    MessageBox.Show("Выберите специализацию");
                    return;
                }
            }

            if (employee == null)
                employee = new Employee();

            employee.Name = textBoxName.Text;
            employee.Surname = textBoxSurname.Text;
            employee.MiddleName = textBoxMiddleName.Text;
            employee.Sex = (Sex)comboBoxSex.SelectedIndex;
            employee.TypePost = typePost;
            employee.Specialization = (Specialization)comboBoxSpec.SelectedItem;
            employee.Email = textBoxEmail.Text;
            employee.Birthday = dateTimePicker1.Value;
            employee.Login = textBoxLogin.Text;
            employee.Password = textBoxPassword.Text;
            employee.Phone = textBoxPhone.Text;
            employee.Cabinet = (Cabinet)comboBoxCabinet.SelectedItem;

            DBController.Instance.Add(employee);

            DialogResult = DialogResult.OK;
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            if (employee != null)
            {
                ScheduleTableForm form = new ScheduleTableForm(employee);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные");
            }
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            
            if (employee != null)
            {
                DoctorRecords form = new DoctorRecords(employee);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные");
            }
        }

        private void comboBoxPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypePost typePost = (TypePost)comboBoxPost.SelectedIndex;

            comboBoxSpec.Enabled = false;
            label9.Enabled = false;

            label12.Enabled = false;
            comboBoxCabinet.Enabled = false;

            if (typePost == TypePost.Doctor)
            {
                comboBoxSpec.Enabled = true;
                label9.Enabled = true;

                label12.Enabled = true;
                comboBoxCabinet.Enabled = true;
            }
            else if (typePost == TypePost.Assistant)
            {
                label12.Enabled = true;
                comboBoxCabinet.Enabled = true;
            }
        }

        private void buttonScheduleByDate_Click(object sender, EventArgs e)
        {
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if (IsReadOnly)
            {
                textBoxName.ReadOnly = true;
                textBoxSurname.ReadOnly = true;
                textBoxMiddleName.ReadOnly = true;
                comboBoxSex.Enabled = false;
                textBoxEmail.ReadOnly = true;
                comboBoxPost.Enabled = false;
                comboBoxSpec.Enabled = false;
                dateTimePicker1.Enabled = false;
                textBoxLogin.ReadOnly = true;
                textBoxPassword.ReadOnly = true;
                textBoxPhone.ReadOnly = true;
                comboBoxCabinet.Enabled = false;
            }

            if (ApplicationHelper.Instance.CurrentEmployee.TypePost != TypePost.MainManager)
            {
                textBoxLogin.Visible= false;
                textBoxPassword.Visible= false;
                label11.Visible = false;
                label10.Visible = false;
            }
        }
    }
}
