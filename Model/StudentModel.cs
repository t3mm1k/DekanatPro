using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentModel : IModel<Student> 
    {
        private List<Student> _students = new List<Student>();

        public event Action<IEnumerable<Student>> DataChanged;

        public void Delete(int id)
        {
            _students.RemoveAt(id);
            //_students = _students.Where(student => student.Id != id).ToList();
            InvokeDataChanged();
        }

        public void Insert(Student student)
        {
            _students.Add(student); 
            InvokeDataChanged();
        }

        private void InvokeDataChanged()
        {



            DataChanged?.Invoke(new List<Student>(_students));
        }
    }
}
