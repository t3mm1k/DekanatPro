using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;

namespace Business_Logic
{
    public class Logic
    {
        private readonly IRepository<Student> _repository;

        public Logic(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            if (_repository.ReadById(student.StudentNumber) == null)
                _repository.Create(student);
        }

        public bool CanAddStudent(string studentNumber)
        {
            return _repository.ReadById(studentNumber) == null;
        }

        public void DeleteStudent(string studentNumber)
        {
            _repository.Delete(studentNumber);
        }

        public List<Student> GetAllStudents()
        {
            return _repository.ReadAll().ToList();
        }

        public DataTable GetSheet()
        {
            var students = _repository.ReadAll();
            DataTable sheet = new DataTable();
            sheet.Columns.Add("Имя", typeof(string));
            sheet.Columns.Add("Специальность", typeof(string));
            sheet.Columns.Add("Группа", typeof(string));
            sheet.Columns.Add("Студ. Билет", typeof(string));

            foreach (var s in students)
                sheet.Rows.Add(s.Name, s.Speciality, s.Group, s.StudentNumber);

            return sheet;
        }

        public Dictionary<string, int> GetHistogram()
        {
            return _repository.ReadAll()
                .GroupBy(s => s.Speciality)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
