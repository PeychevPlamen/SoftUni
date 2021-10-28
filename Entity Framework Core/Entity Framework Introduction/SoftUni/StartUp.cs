using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            using SoftUniContext db = new SoftUniContext();

            // string result = GetEmployeesFullInformation(db);  // Problem 03

            // string result = GetEmployeesWithSalaryOver50000(db); // Problem 04

            // string result = GetEmployeesFromResearchAndDevelopment(db);  // Problem 05

            string result = AddNewAddressToEmployee(db);  // Problem 06

            Console.WriteLine(result);

        }

        // Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmployee = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in allEmployee)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {(employee.Salary):f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmployee = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in allEmployee)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        // Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakovEmployee = context.Employees
                .First(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            string[] allEmployeesByAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            return String.Join(Environment.NewLine, allEmployeesByAddresses);
        }
    }
}
