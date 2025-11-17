using Business_Logic;
using Model;
using Ninject;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using WindowsForm_View;
using Shared;


namespace WinForms_View
{
    public partial class Form2 : Form, IView
    {
        private Logic logic;
        private event Action<EventArgs> AddDataEvent;
        private event Action<int> DeleteDataEvent;
        public Form2()
        {
            InitializeComponent();

            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<Logic>();


            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnShowHistogram.Click += BtnShowHistogram_Click;

            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddDataEvent?.Invoke(new StudentEventArgs()
            {
                Name = txtName.Text,
                Speciality = txtSpeciality.Text,
                Group = txtGroup.Text,
            });
        }

            }

            //if (string.IsNullOrWhiteSpace(txtName.Text) ||
            //    string.IsNullOrWhiteSpace(txtSpeciality.Text) ||
            //    string.IsNullOrWhiteSpace(txtGroup.Text))
            //{
            //    MessageBox.Show("Заполните все поля!");
            //    return;
            //}

            //var student = new Student(
            //    txtName.Text,
            //    txtSpeciality.Text,
            //    txtGroup.Text
            //);

            //logic.AddStudent(student);

            //RefreshGrid();
            //BuildChart();

        //    MessageBox.Show("Студент добавлен!");
        //}

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для удаления!");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Cells["Id"].Value != null && int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out int id))
            {
                logic.DeleteStudent(id);
                RefreshGrid();
                MessageBox.Show("Студент удалён!");
            }
            else
            {
                MessageBox.Show("Ошибка при получении ID студента!");
            }
        }

        private void RefreshGrid()
        {
            try
            {
                DataTable sheet = logic.GetSheet();
                dataGridView1.DataSource = sheet;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    }
}
