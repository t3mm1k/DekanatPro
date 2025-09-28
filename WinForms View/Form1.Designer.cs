namespace WinForms_View
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblName = new System.Windows.Forms.Label();
            lblSpeciality = new System.Windows.Forms.Label();
            lblGroup = new System.Windows.Forms.Label();
            lblStudentNumber = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            txtSpeciality = new System.Windows.Forms.TextBox();
            txtGroup = new System.Windows.Forms.TextBox();
            txtStudentNumber = new System.Windows.Forms.TextBox();
            btnAdd = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnShowHistogram = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(20, 25);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(34, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Имя:";
            // 
            // lblSpeciality
            // 
            lblSpeciality.AutoSize = true;
            lblSpeciality.Location = new System.Drawing.Point(20, 75);
            lblSpeciality.Name = "lblSpeciality";
            lblSpeciality.Size = new System.Drawing.Size(95, 15);
            lblSpeciality.TabIndex = 1;
            lblSpeciality.Text = "Специальность:";
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.Location = new System.Drawing.Point(20, 125);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new System.Drawing.Size(49, 15);
            lblGroup.TabIndex = 2;
            lblGroup.Text = "Группа:";
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.AutoSize = true;
            lblStudentNumber.Location = new System.Drawing.Point(20, 175);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new System.Drawing.Size(73, 15);
            lblStudentNumber.TabIndex = 3;
            lblStudentNumber.Text = "Студ. билет:";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(150, 25);
            txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(200, 23);
            txtName.TabIndex = 4;
            // 
            // txtSpeciality
            // 
            txtSpeciality.Location = new System.Drawing.Point(150, 75);
            txtSpeciality.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSpeciality.Name = "txtSpeciality";
            txtSpeciality.Size = new System.Drawing.Size(200, 23);
            txtSpeciality.TabIndex = 5;
            // 
            // txtGroup
            // 
            txtGroup.Location = new System.Drawing.Point(150, 125);
            txtGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new System.Drawing.Size(200, 23);
            txtGroup.TabIndex = 6;
            // 
            // txtStudentNumber
            // 
            txtStudentNumber.Location = new System.Drawing.Point(150, 175);
            txtStudentNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtStudentNumber.Name = "txtStudentNumber";
            txtStudentNumber.Size = new System.Drawing.Size(200, 23);
            txtStudentNumber.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(20, 225);
            btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(111, 29);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(150, 225);
            btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(124, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnShowHistogram
            // 
            btnShowHistogram.Location = new System.Drawing.Point(280, 225);
            btnShowHistogram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnShowHistogram.Name = "btnShowHistogram";
            btnShowHistogram.Size = new System.Drawing.Size(146, 29);
            btnShowHistogram.TabIndex = 10;
            btnShowHistogram.Text = "Гистограмма";
            btnShowHistogram.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new System.Drawing.Point(449, 4);
            dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(731, 250);
            dataGridView1.TabIndex = 11;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new System.Drawing.Point(20, 281);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new System.Drawing.Size(1160, 356);
            chart1.TabIndex = 12;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 652);
            Controls.Add(chart1);
            Controls.Add(lblName);
            Controls.Add(lblSpeciality);
            Controls.Add(lblGroup);
            Controls.Add(lblStudentNumber);
            Controls.Add(txtName);
            Controls.Add(txtSpeciality);
            Controls.Add(txtGroup);
            Controls.Add(txtStudentNumber);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnShowHistogram);
            Controls.Add(dataGridView1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Text = "Управление студентами";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpeciality;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblStudentNumber;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSpeciality;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtStudentNumber;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShowHistogram;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
