using Business_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataAccessLayer;


namespace ConsoleVersion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Desktop\DekPro\DekanatPro\DataAccessLayer\Database1.mdf;Integrated Security=True";

                IRepository<Student> repo = new DapperRepository(conn);

                Logic logic = new Logic(repo);

                while (true)
                {
                    Console.WriteLine("\nМеню:");
                    Console.WriteLine("1. Добавить студента");
                    Console.WriteLine("2. Удалить студента");
                    Console.WriteLine("3. Показать всех студентов");
                    Console.WriteLine("4. Показать гистограмму по специальностям");
                    Console.WriteLine("5. Выход");
                    Console.Write("Выберите действие: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudentMenu(logic);
                            break;

                        case "2":
                            DeleteStudentMenu(logic);
                            break;

                        case "3":
                            ShowAllStudents(logic);
                            break;

                        case "4":
                            ShowHistogram(logic);
                            break;

                        case "5":
                            return;

                        default:
                            Console.WriteLine("Неверный выбор!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void AddStudentMenu(Logic logic)
        {
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Console.Write("Специальность: ");
            string spec = Console.ReadLine();
            Console.Write("Группа: ");
            string group = Console.ReadLine();
            Console.Write("Номер студенческого: ");
            string num = Console.ReadLine();

            if (logic.CanAddStudent(num))
            {
                logic.AddStudent(new Student(name, spec, group, num));
                Console.WriteLine("Студент добавлен!");
            }
            else
            {
                Console.WriteLine("Студент с таким номером уже существует!");
            }
        }

        private static void DeleteStudentMenu(Logic logic)
        {
            Console.Write("Номер студенческого: ");
            string delNum = Console.ReadLine();
            logic.DeleteStudent(delNum);
            Console.WriteLine("Студент удалён!");
        }

        private static void ShowAllStudents(Logic logic)
        {
            var students = logic.GetAllStudents();
            Console.WriteLine("\nСписок студентов:");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentNumber}: {s.Name} - {s.Speciality} ({s.Group})");
            }
        }

        private static void ShowHistogram(Logic logic)
        {
            var histogram = logic.GetHistogram();
            if (histogram.Count == 0)
            {
                Console.WriteLine("Нет данных для построения гистограммы.");
                return;
            }

            int max = 0;
            foreach (var val in histogram.Values)
                if (val > max) max = val;

            var keys = new List<string>(histogram.Keys);

            for (int level = max; level >= 1; level--)
            {
                foreach (var key in keys)
                {
                    Console.Write(histogram[key] >= level ? "  *  " : "     ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', keys.Count * 5));
            int maxKeyLen = 0;
            foreach (var k in keys)
                if (k.Length > maxKeyLen) maxKeyLen = k.Length;

            for (int i = 0; i < maxKeyLen; i++)
            {
                foreach (var key in keys)
                {
                    Console.Write(i < key.Length ? $"  {key[i]}  " : "     ");
                }
                Console.WriteLine();
            }
        }
    }
}  