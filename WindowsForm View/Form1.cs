using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using Business_Logic;
using DataAccessLayer; 
using Model;


namespace WinForms_View
{
    public partial class Form2 : Form
    {
        private LogicWithFactory logic;

        public Form2()
        {
            InitializeComponent();

            // Используем новую логику с фабрикой репозиториев
            logic = new LogicWithFactory();

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnShowHistogram.Click += BtnShowHistogram_Click;

            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            BuildChart();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSpeciality.Text) ||
                string.IsNullOrWhiteSpace(txtGroup.Text) ||
                string.IsNullOrWhiteSpace(txtStudentNumber.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!logic.CanAddStudent(txtStudentNumber.Text))
            {
                MessageBox.Show("Студент с таким номером уже существует!");
                return;
            }

            var student = new Student(
                txtName.Text,
                txtSpeciality.Text,
                txtGroup.Text,
                txtStudentNumber.Text
            );

            logic.AddStudent(student);

            RefreshGrid();
            BuildChart();

            MessageBox.Show("Студент добавлен!");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentNumber.Text))
            {
                MessageBox.Show("Введите номер студенческого для удаления!");
                return;
            }

            logic.DeleteStudent(txtStudentNumber.Text);

            RefreshGrid();
            BuildChart();

            MessageBox.Show("Студент удалён!");
        }

        private void BtnShowHistogram_Click(object sender, EventArgs e)
        {
            BuildChart();
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

        private void BuildChart()
        {
            try
            {
                var histogram = logic.GetHistogram();

                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                if (histogram.Count == 0)
                {
                    MessageBox.Show("Нет данных для построения гистограммы.");
                    return;
                }

                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Студенты",
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                };

                foreach (var item in histogram)
                {
                    series.Points.AddXY(item.Key, item.Value);
                }

                chart1.Series.Add(series);
                chart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении диаграммы: {ex.Message}");
            }
        }
    }
}
