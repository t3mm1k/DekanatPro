//using Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Business_Logic
{
    public class Logic
    {
        private List<Student> students { get; set; } = new List<Student>();

        public void AddStudent(string name, string speciality, string group, string studentNumber)
        {
            students.Add(new Student(name, speciality, group, studentNumber));
        }

        public bool canAddStudent(string studentNumber)
        {
            return students.Where(Student => Student.StudentNumber == studentNumber).Count() == 0;
        }

        public void DeleteStudent(string studentNumber)
        {
            students = students.Where(Student => Student.StudentNumber != studentNumber).ToList();
        }

        public DataTable GetSheet()
        {
            DataTable sheet = new DataTable();

            sheet.Columns.Add("Имя", typeof(string));
            sheet.Columns.Add("Специальность", typeof(string));
            sheet.Columns.Add("Группа", typeof(string));
            sheet.Columns.Add("Студ. Билет", typeof(string));

            foreach (Student student in students)
            {
                sheet.Rows.Add(student.Name, student.Speciality, student.Group, student.StudentNumber);
            }

            return sheet;
        }

        public Dictionary<string, int> GetHistogram()
        {
            var histogram = students
                .GroupBy(Student => Student.Speciality)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            return histogram;
        }

    }

}
