namespace HospitalSystem
{
    partial class SelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEmployes = new System.Windows.Forms.Button();
            this.buttonPatients = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEmployes
            // 
            this.buttonEmployes.Location = new System.Drawing.Point(73, 70);
            this.buttonEmployes.Name = "buttonEmployes";
            this.buttonEmployes.Size = new System.Drawing.Size(134, 48);
            this.buttonEmployes.TabIndex = 0;
            this.buttonEmployes.Text = "Сотрудники";
            this.buttonEmployes.UseVisualStyleBackColor = true;
            this.buttonEmployes.Click += new System.EventHandler(this.buttonEmployes_Click);
            // 
            // buttonPatients
            // 
            this.buttonPatients.Location = new System.Drawing.Point(281, 70);
            this.buttonPatients.Name = "buttonPatients";
            this.buttonPatients.Size = new System.Drawing.Size(134, 48);
            this.buttonPatients.TabIndex = 1;
            this.buttonPatients.Text = "Пациенты";
            this.buttonPatients.UseVisualStyleBackColor = true;
            this.buttonPatients.Click += new System.EventHandler(this.buttonPatients_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Запись к врачу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 209);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPatients);
            this.Controls.Add(this.buttonEmployes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно выбора";
            this.Load += new System.EventHandler(this.SelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEmployes;
        private System.Windows.Forms.Button buttonPatients;
        private System.Windows.Forms.Button button1;
    }
}