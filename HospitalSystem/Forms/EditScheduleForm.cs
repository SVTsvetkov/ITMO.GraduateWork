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
    public partial class EditScheduleForm : Form
    {
        ScheduleDoctor scheduleDoctor;

        public EditScheduleForm(ScheduleDoctor scheduleDoctor)
        {
            InitializeComponent();
        
            this.scheduleDoctor = scheduleDoctor;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                scheduleDoctor.Start = TimeSpan.Parse(textBoxStart.Text);
                scheduleDoctor.Finish = TimeSpan.Parse(textBoxFinish.Text);

                DBController.Instance.Save();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Неверно задано время");
            }
          
        }
    }
}
