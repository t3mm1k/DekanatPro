using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Business_Logic
{
    public class Logic
    {
        private readonly IRepository<Student> repository;

        public Logic(IRepository<Student> repository)
        {
            Console.WriteLine(nameof(repository));
            this.repository = repository;
        }

        public void AddStudent(Student student)
        {
            if (repository.ReadById(student.StudentNumber) == null)
                repository.Create(student);
        }

        public bool CanAddStudent(string studentNumber)
        {
            return repository.ReadById(studentNumber) == null;
        }

        public void DeleteStudent(string studentNumber)
        {
            repository.Delete(studentNumber);
        }

        public List<Student> GetAllStudents()
        {
            return repository.ReadAll().ToList();
        }

        public DataTable GetSheet()
        {
            var students = repository.ReadAll();
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
            return repository.ReadAll()
                .GroupBy(s => s.Speciality)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
