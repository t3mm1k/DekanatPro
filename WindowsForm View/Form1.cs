using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using Business_Logic;

namespace WinForms_View
{
    public partial class Form2 : Form
    {
        private Logic logic = new Logic();


        public Form2()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnShowHistogram.Click += BtnShowHistogram_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logic.AddStudent("Подкур Артем", "ПИ", "КИ24-21Б", "1");
            logic.AddStudent("Трачук Дмитрий", "ПИ", "КИ24-21Б", "2");
            logic.AddStudent("Тимофеев Александр", "ПИ", "КИ24-21Б", "3");


            logic.AddStudent("Попов Дмитрий", "ИВТ", "КИ24-06Б", "4");
            logic.AddStudent("Иванов Михаил", "ИВТ", "КИ24-06Б", "5");
            logic.AddStudent("Капустин Генадий", "ИВТ", "КИ24-О6Б", "6");

            BuildChart();
            RefreshGrid();

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

            if (!logic.canAddStudent(txtStudentNumber.Text))
            {
                MessageBox.Show("Студент с таким номером студенческого уже добавлен!");
                return;
            }

            logic.AddStudent(txtName.Text, txtSpeciality.Text, txtGroup.Text, txtStudentNumber.Text);
            RefreshGrid();
            BuildChart();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentNumber.Text))
            {
                MessageBox.Show("Введите студенческий билет для удаления!");
                return;
            }

            logic.DeleteStudent(txtStudentNumber.Text);
            RefreshGrid();
            BuildChart();
        }

        private void BtnShowHistogram_Click(object sender, EventArgs e)
        {
            BuildChart();
        }

        private void RefreshGrid()
        {
            DataTable sheet = logic.GetSheet();
            dataGridView1.DataSource = sheet;
        }

        private void BuildChart()
        {
            var histogram = logic.GetHistogram();
            chart1.Series.Clear();

            // // Create a new series
            // Series series = new Series("My Data");
            // series.ChartType = SeriesChartType.Column; // Or Line, Pie, etc.
            //
            // // Add data points
            // series.Points.AddXY("Category A", 10);
            // series.Points.AddXY("Category B", 25);
            // series.Points.AddXY("Category C", 15);
            //
            // // Add the series to the chart
            // chart1.Series.Add(series);
            //
            // // Set chart title
            // chart1.Titles.Clear();
            // chart1.Titles.Add("My Chart Title");

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

            //chartArea.AxisX.Interval = 1;
            //chartArea.AxisX.LabelStyle.Angle = -45;
            //chart1.Series["Студенты"].ChartType =
                //System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            Series series = new Series
            {
                Name = "Студенты",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                // XValueType = ChartValueType.String 
            };

            foreach (var item in histogram)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart1.Series.Add(series);
            chart1.Invalidate();
        }


        private void chart1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
