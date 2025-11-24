using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using WindowsForm_View;


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

        public void RedrawForm(IEnumerable<EventArgs> data)
        {
            Students_ListView.Items.Clear();

            foreach (StudentEventArgs item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Name);

                listViewItem.SubItems.Add(item.Speciality);
                listViewItem.SubItems.Add(item.Group);
                listViewItem.SubItems.Add(item.Id);

                Students_ListView.Items.Add(listViewItem);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty || txtId.Text == String.Empty || txtSpeciality.Text == String.Empty || txtGroup.Text == String.Empty) {
                MessageBox.Show("Не все поля заполнены.");
            }
            else 
            {
                AddDataEvent?.Invoke(new StudentEventArgs()
                {
                    Id = txtId.Text,
                    Name = txtName.Text,
                    Speciality = txtSpeciality.Text,
                    Group = txtGroup.Text
                }); 
                txtId.Text = String.Empty;
                txtSpeciality.Text = String.Empty;
                txtName.Text = String.Empty;
                txtGroup.Text = String.Empty;
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Students_ListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Студент не выбран.");
            }
            else 
            DeleteDataEvent?.Invoke(Students_ListView.SelectedIndices[0]);
        }
    }
}
