using SQLiteIntro.Models;
using SQLiteIntro.Providers;
using System;

namespace SQLiteIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = (IEmployeeRepository)ServiceProvider.Instance.GetService(typeof(IEmployeeRepository));

            var employee = new Employee() {FirstName = "Bob", LastName = "Dylan"};

            employeeRepository.AddEmployeeAsync(employee);

            var employeeRead = employeeRepository.GetEmployeesAsync();

            foreach(var em in employeeRead.Result)
            {
                Console.WriteLine(em);
            }

            Console.ReadKey();
        }
    }
}
