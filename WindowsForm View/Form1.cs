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
        public Form2()
        {
            InitializeComponent();
        }

        public event Action<EventArgs> AddDataEvent;
        public event Action<int> DeleteDataEvent;

        public void RedrawForm(IEquatable<EventArgs> data)
        {
            Students_ListView.Items.Clear();
            
            foreach(StudentEventArgs item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Name);
                listViewItem.SubItems.Add(item.Speciality);
                listViewItem.SubItems.Add(item.Group);

                Students_ListView.Items.Add(listViewItem);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddDataEvent?.Invoke(new StudentEventArgs()
            {
                Id = 
                Name = txtName.Text,
                Speciality = txtSpeciality.Text,
                Group = txtGroup.Text,
            });
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteDataEvent?.Invoke(Students_ListView.SelectedIndices[0]);
        }

        // }
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
