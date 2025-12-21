using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gazprombank = new GazprombankSalaryTransferStrategy();
            var sberbank = new SberbankSalaryTransferStrategy();

            Employee petrov = new ManagerEmployee("Петров Иван Васильевич", 45000m, gazprombank);
            Employee ivanova = new EngineerEmployee("Иванова Томара Евгеньевна", 60000m, sberbank);
            Employee sidorov = new ScientistEmployee("Сидоров Леонид Аркадьевич", 50000m, gazprombank);

            // Декоратор: добавляем доп. характеристику уже созданному сотруднику.
            sidorov = new DegreeDecorator(
                sidorov,
                "Бесполезные исследования, требующие инвестиций правительства",
                "Влияние фазы луны на способность хомячков к полётам",
                2015);

            var employees = new List<Employee> { petrov, ivanova, sidorov };

            PrintEmployees(employees);

            // Показ изменения: добавили сертификат и сменили стратегию перечисления.
            Console.WriteLine(sidorov.FullName + ": добавлен сертификат о владении английским языком");
            sidorov = new EnglishCertificateDecorator(sidorov, "Экзамен по английскому", 2007);

            Console.WriteLine(ivanova.FullName + ": замена сервиса");
            ivanova.SalaryTransferStrategy = gazprombank;

            employees[2] = sidorov;

            Console.WriteLine();
            PrintEmployees(employees);
        }

        private static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.GetInfo());
                Console.WriteLine();
                Console.WriteLine(new string('=', 20));
                Console.WriteLine();
            }
        }
    }

    // ====== Strategy ======
    internal interface ISalaryTransferStrategy
    {
        string ServiceName { get; }
        decimal CommissionPercent { get; }
        decimal CalculateNetSalary(decimal baseSalary);
    }

    internal sealed class SberbankSalaryTransferStrategy : ISalaryTransferStrategy
    {
        public string ServiceName { get { return "Сбербанк"; } }
        public decimal CommissionPercent { get { return 1.0m; } }

        public decimal CalculateNetSalary(decimal baseSalary)
        {
            return baseSalary - (baseSalary * (CommissionPercent / 100m));
        }
    }

    internal sealed class GazprombankSalaryTransferStrategy : ISalaryTransferStrategy
    {
        public string ServiceName { get { return "Газпромбанк"; } }
        public decimal CommissionPercent { get { return 1.5m; } }

        public decimal CalculateNetSalary(decimal baseSalary)
        {
            return baseSalary - (baseSalary * (CommissionPercent / 100m));
        }
    }

    // ====== Core Employee + positions (inheritance) ======
    internal abstract class Employee
    {
        protected Employee(string fullName, decimal baseSalary, ISalaryTransferStrategy salaryTransferStrategy)
        {
            FullName = fullName;
            BaseSalary = baseSalary;
            SalaryTransferStrategy = salaryTransferStrategy;
        }

        public string FullName { get; private set; }
        public decimal BaseSalary { get; set; }
        public ISalaryTransferStrategy SalaryTransferStrategy { get; set; }

        public abstract string PositionTitle { get; }

        public decimal SalaryAfterCommission
        {
            get { return SalaryTransferStrategy.CalculateNetSalary(BaseSalary); }
        }

        public virtual string GetInfo()
        {
            var culture = new CultureInfo("ru-RU");
            return string.Join(Environment.NewLine,
                FullName,
                "Базовая зарплата:" + BaseSalary.ToString("0", culture),
                "Для перечисления зарплаты используется сервис " + SalaryTransferStrategy.ServiceName,
                "Зарплата после удержания комиссии сервиса: " + SalaryAfterCommission.ToString("0", culture),
                "Должность: " + PositionTitle);
        }
    }

    internal sealed class ManagerEmployee : Employee
    {
        public ManagerEmployee(string fullName, decimal baseSalary, ISalaryTransferStrategy salaryTransferStrategy)
            : base(fullName, baseSalary, salaryTransferStrategy) { }

        public override string PositionTitle { get { return "Менеджер"; } }
    }

    internal sealed class EngineerEmployee : Employee
    {
        public EngineerEmployee(string fullName, decimal baseSalary, ISalaryTransferStrategy salaryTransferStrategy)
            : base(fullName, baseSalary, salaryTransferStrategy) { }

        public override string PositionTitle { get { return "Инженер"; } }
    }

    internal sealed class ScientistEmployee : Employee
    {
        public ScientistEmployee(string fullName, decimal baseSalary, ISalaryTransferStrategy salaryTransferStrategy)
            : base(fullName, baseSalary, salaryTransferStrategy) { }

        public override string PositionTitle { get { return "Научный сотрудник"; } }
    }

    // ====== Decorator ======
    internal abstract class EmployeeDecorator : Employee
    {
        protected readonly Employee Inner;

        protected EmployeeDecorator(Employee inner)
            : base(inner.FullName, inner.BaseSalary, inner.SalaryTransferStrategy)
        {
            Inner = inner;
        }

        public override string PositionTitle { get { return Inner.PositionTitle; } }

        public override string GetInfo()
        {
            return Inner.GetInfo();
        }
    }

    internal sealed class EnglishCertificateDecorator : EmployeeDecorator
    {
        private readonly string _examName;
        private readonly int _year;

        public EnglishCertificateDecorator(Employee inner, string examName, int year)
            : base(inner)
        {
            _examName = examName;
            _year = year;
        }

        public override string GetInfo()
        {
            return base.GetInfo()
                   + Environment.NewLine
                   + Environment.NewLine
                   + "Экзамен: " + _examName
                   + Environment.NewLine
                   + "Год получения сертификата: " + _year;
        }
    }

    internal sealed class DegreeDecorator : EmployeeDecorator
    {
        private readonly string _scienceField;
        private readonly string _topic;
        private readonly int _defenseYear;

        public DegreeDecorator(Employee inner, string scienceField, string topic, int defenseYear)
            : base(inner)
        {
            _scienceField = scienceField;
            _topic = topic;
            _defenseYear = defenseYear;
        }

        public override string GetInfo()
        {
            return base.GetInfo()
                   + Environment.NewLine
                   + Environment.NewLine
                   + "Научная работа: " + _topic
                   + Environment.NewLine
                   + "Год защиты: " + _defenseYear
                   + Environment.NewLine
                   + "Область: " + _scienceField;
        }
    }
}
