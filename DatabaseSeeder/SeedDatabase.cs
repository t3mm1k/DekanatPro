using System;
using System.Collections.Generic;
using Business_Logic;
using Model;

namespace DatabaseSeeder
{
    class SeedDatabase
    {
        static void Main(string[] args)
        {
            try
            {
                
                LogicWithFactory logic = new LogicWithFactory();
                
                var students = new List<Student>
                {
                    new Student("Иванов Иван Иванович", "Программная инженерия", "КИ24-25Б", "001"),
                    new Student("Петров Петр Петрович", "Информационные системы и технологии", "КИ24-06Б", "002"),
                    new Student("Сидорова Анна Сергеевна", "Кибербезопасность", "КИ24-15Б", "003"),
                    new Student("Козлов Алексей Дмитриевич", "Программная инженерия", "КИ24-21Б", "004")
                };
                
                
                foreach (var student in students)
                {
                    if (logic.CanAddStudent(student.StudentNumber))
                    {
                        logic.AddStudent(student);
                        Console.WriteLine($"Добавлен: {student.Name} ({student.StudentNumber})");
                    }
                    else
                    {
                        Console.WriteLine($"⚠ Студент {student.Name} ({student.StudentNumber}) уже существует");
                    }
                }
                
                
                var allStudents = logic.GetAllStudents();
                Console.WriteLine($"Всего студентов в базе: {allStudents.Count}");
                
                foreach (var student in allStudents)
                {
                    Console.WriteLine($"- {student.Name} | {student.Speciality} | {student.Group} | {student.StudentNumber}");
                }
                

                
                Console.WriteLine("\nБаза данных успешно заполнена!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка при заполнении базы данных: {ex.Message}");
                Console.WriteLine($"Детали: {ex}");
            }
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
