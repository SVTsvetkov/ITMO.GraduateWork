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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Employee employee = DBController.Instance.GetEmloyees().
                FirstOrDefault(t => t.Login == textBoxLogin.Text && t.Password == textBoxPassword.Text);
            
         
            ApplicationHelper.Instance.CurrentEmployee = employee;

            if (employee != null)
            {
                SelectForm form = new SelectForm();
                form.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
