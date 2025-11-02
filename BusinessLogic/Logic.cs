using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using Model;

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
            _repository.Create(student);
        }

        public bool CanAddStudent(int id)
        {
            return _repository.ReadById(id) == null;
        }

        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
        }

        public List<Student> GetAllStudents()
        {
            return _repository.ReadAll().ToList();
        }

        public DataTable GetSheet()
        {
            var students = _repository.ReadAll();
            DataTable sheet = new DataTable();
            sheet.Columns.Add("Id", typeof(int));
            sheet.Columns.Add("Имя", typeof(string));
            sheet.Columns.Add("Специальность", typeof(string));
            sheet.Columns.Add("Группа", typeof(string));

            foreach (var s in students)
                sheet.Rows.Add(s.Id, s.Name, s.Speciality, s.Group);

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
