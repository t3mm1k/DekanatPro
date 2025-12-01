using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Shared;
using WindowsForm_View;

namespace Presentier
{
    internal class StudentPresenter
    {
        private IModel<Student> model;
        private IView view;

        public StudentPresenter(IView view,  IModel<Student> model)
        {
            //this.model = model;
            this.view = view;

            model.DataChanged += OnModelDataChanged;
            view.AddDataEvent += OnAddData;
            view.DeleteDataEvent += model.Delete;
        }

        private void OnModelDataChanged(IEnumerable<Student> students)
        {
            List<StudentEventArgs> sArgs = new List<StudentEventArgs>();

            foreach (Student stud in students)
            {
                sArgs.Add(new StudentEventArgs()
                {
                    Id = stud.Id,
                    Name = stud.Name,
                    Group = stud.Group,
                    Speciality = stud.Speciality,
                });
            }
            view.RedrawForm(sArgs);
        }

        private void OnAddData(EventArgs args)
        {
            StudentEventArgs sArgs = args as StudentEventArgs;
            //Student student = new Student();
            student.Id = sArgs.Id;
            student.Name = sArgs.Name;
            student.Speciality = sArgs.Speciality;
            student.Group = sArgs.Group;
            model.Insert(student);
        }
    }
}
