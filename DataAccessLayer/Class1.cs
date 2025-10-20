using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public class Class1
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            
            var repository = new EntityRepository(connectionString);
            
            // Пример использования
            var student = new Student("Иван Иванов", "Информатика", "ИТ-21", "2021001");
            repository.Create(student);
            
            var allStudents = repository.ReadAll();
            var foundStudent = repository.ReadById("2021001");
            
            Console.WriteLine("Студенты в базе данных:");
            foreach (var s in allStudents)
            {
                Console.WriteLine($"ФИО: {s.Name}, Специальность: {s.Speciality}, Группа: {s.Group}, Номер: {s.StudentNumber}");
            }
        }
    }
}
