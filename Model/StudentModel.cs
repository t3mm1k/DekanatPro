using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class StudentModel
    {
        private List<Student> _students = new List<Student>();

        private event Action<IEnumerable<Student>> DataChanged;


        public void Delete(int id)
        {
            _students = _students.Where(student =>  student.Id != id).ToList();
        }

        public void Insert(Student student)
        {
            _students.Add(student); 
        }

        private void InvokeDataChanged()
        {
            DataChanged?.Invoke(_students);
        }

                
    }
}
