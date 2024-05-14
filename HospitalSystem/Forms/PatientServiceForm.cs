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
    public partial class PatientServiceForm : Form
    {
        Record record;
        RecordService recordService;

        public PatientServiceForm(Record record, RecordService recordService = null)
        {
            InitializeComponent();

            comboBoxService.DataSource = DBController.Instance.GetServices();
            this.record = record;

            if (recordService != null )
            {
                this.recordService = recordService;

                comboBoxService.SelectedItem = recordService.Service;
                textBoxCost.Text = recordService.Cost.ToString();
                textBoxDescription.Text = recordService.Description;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxCost.Text, out var cost))
            {
                MessageBox.Show("Введена некорректная стоимость");
                return;
            }

            if (recordService == null)
            {
                recordService = new RecordService();
                record.Services.Add(recordService);
            }

            recordService.Service = (Service)comboBoxService.SelectedItem;
            recordService.Cost = cost;
            recordService.Description = textBoxDescription.Text;

            DBController.Instance.Save();

            DialogResult = DialogResult.OK;
        }
    }
}
