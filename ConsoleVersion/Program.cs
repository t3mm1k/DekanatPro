using Business_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic;
using System.Data;

namespace ConsoleVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            logic.AddStudent("Подкур Артем", "ПИ", "КИ24-21Б", "1");
            logic.AddStudent("Трачук Дмитрий", "ПИ", "КИ24-21Б", "2");
            logic.AddStudent("Тимофеев Александр", "ПИ", "КИ24-21Б", "3");


            logic.AddStudent("Попов Дмитрий", "ИВТ", "КИ24-06Б", "4");
            logic.AddStudent("Иванов Михаил", "ИВТ", "КИ24-06Б", "5");
            // logic.AddStudent("Капустин Генадий", "ИВТ", "КИ24-О6Б", "6");
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Показать таблицу студентов");
                Console.WriteLine("4. Показать гистограмму");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Имя студента: ");
                        string name = Console.ReadLine();
                        Console.Write("Специальность: ");
                        string speciality = Console.ReadLine();
                        Console.Write("Группа: ");
                        string group = Console.ReadLine(); ;
                        Console.Write("Номер студенческого билета: ");
                        string studentNumber = Console.ReadLine();
                        logic.AddStudent(name, speciality, group, studentNumber);
                        Console.WriteLine("Студент добавлен!\n");
                        break;
                    case "2":
                        Console.Write("Номер студенческого билета: ");
                        string studentnumber = Console.ReadLine();
                        logic.DeleteStudent(studentnumber);

                        Console.WriteLine("Студент добавлен!\n");
                        break;
                    case "3":
                        Console.WriteLine(SheetToString(logic.GetSheet()));
                        break;
                    case "4":
                        Console.WriteLine(HistogramToString(logic.GetHistogram()));
                        break;
                    case "5":
                        return;
                }
            }


            string HistogramToString(Dictionary<string, int> histogram)
            {
                if (histogram.Count == 0)
                    return "Нет данных";

                int max = histogram.Values.Max();
                var keys = histogram.Keys.ToList();

                var sb = new System.Text.StringBuilder();

                for (int level = max; level >= 1; level--)
                {
                    foreach (var key in keys)
                    {
                        if (histogram[key] >= level)
                            sb.Append("  *  ");
                        else
                            sb.Append("     ");
                    }
                    sb.AppendLine();
                }

                sb.AppendLine(new string('-', keys.Count * 5));
                int maxKeyLen = keys.Max(k => k.Length);

                for (int i = 0; i < maxKeyLen; i++)
                {
                    foreach (var key in keys)
                    {
                        if (i < key.Length)
                            sb.Append($"  {key[i]}  ");
                        else
                            sb.Append("     ");
                    }
                    sb.AppendLine();
                }

                return sb.ToString();
            }


             string SheetToString(DataTable table)
            {
                string result = "";
                foreach (DataColumn col in table.Columns)
                {
                    result += $"{col.ColumnName}\t";
                }

                result += "\n";

                foreach (DataRow row in table.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        result += $"{item}\t";
                    }
                    result += "\n";
                }
                return result;
            }

            // DataTable sheet = logic.getHistogram();

        }
    }
}
