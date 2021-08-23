using System;
using System.Collections.Generic;
using System.Linq;

namespace NJ06LINQ_Employees
{
    class Program
    {
        class Employee
        {
            public string Name { get; set;  }
            public int Salary { get; set; }
        }

        static void Main(string[] args)
        {
            Employee[] employees = new Employee[] {
              new Employee() { Name="Andras", Salary=420},
              new Employee(){ Name="Bela", Salary=400},
              new Employee(){ Name="Csaba", Salary=250},
              new Employee(){ Name="David", Salary=300},
              new Employee(){ Name="Endre", Salary=620},
              new Employee(){ Name="Ferenc", Salary=350},
              new Employee(){ Name="Gabor", Salary=410},
              new Employee(){ Name="Hunor", Salary=500},
              new Employee(){ Name="Imre", Salary=900},
              new Employee(){ Name="Janos", Salary=600},
              new Employee(){ Name="Karoly", Salary=700},
              new Employee(){ Name="Laszlo", Salary=400},
              new Employee(){ Name="Marton", Salary=500}
            };

            DisplayMostEarner(employees);
            DisplayLessThanAverageEarners(employees);
            DisplayEmployeesBySalaryAscendingOrder(employees);
            /*Display the name of employees who earn the same amount and sort the result by salaries then names in an ascending order*/
            Task4(employees);
            /*Group the employees in the following salary ranges: 200-399, 400-599, 600-799, 800-999*/
            Task5(employees);
        }

        private static void Task5(Employee[] employees)
        {
            Console.WriteLine("Task5");
            var result = from e in employees
                         orderby e.Salary
                         group e by new { Range = WhichRangeIsEmployeeIn(e) };

            foreach (var item in result)
            {
                Console.WriteLine();
                Console.Write(item.Key + " - ");
                foreach (var element in item)
                {
                    Console.Write($"[{element.Name} - {element.Salary}] ");
                }
            }
            Console.WriteLine();
        }

        private static string WhichRangeIsEmployeeIn(Employee employee)
        {
            if (employee.Salary < 399 && employee.Salary >= 200)
            {
                return "200-399";
            } else if (employee.Salary < 599 && employee.Salary >= 400)
            {
                return "400-599";
            } else if (employee.Salary < 799 && employee.Salary >= 600)
            {
                return "600-799";
            } else
            {
                return "800-999";
            }
        }

        private static void Task4(Employee[] employees)
        {
            Console.WriteLine("----Task4---");
            var result = from e in employees
                         orderby e.Salary, e.Name
                         group e by e.Salary;


            foreach (var item in result)
            {
                Console.Write(item.Key + " -");
                foreach (var itemResult in item)
                {
                    Console.Write($" {itemResult.Name}");
                }
                Console.WriteLine();
            }
           
        }

        private static void DisplayEmployeesBySalaryAscendingOrder(Employee[] employees)
        {
            Console.WriteLine("---DisplayEmployeesBySalaryAscendingOrder---");
            var result = employees.OrderBy(e => e.Salary);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void DisplayLessThanAverageEarners(Employee[] employees)
        {
            Console.WriteLine("---DisplayLessThanAverageEarners---");
            var average = employees.Average(e => e.Salary);

            var results = employees.Where(e => e.Salary < average);
            Console.WriteLine("Average: "+ average);
            foreach (var item in results)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void DisplayMostEarner(Employee[] employees)
        {
            Console.WriteLine("---DisplayMostEarner---");
            Console.WriteLine(employees.OrderByDescending(e => e.Salary).First().Name); 
        }
    }
}
