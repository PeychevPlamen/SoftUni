using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
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

            // string result = AddNewAddressToEmployee(db);  // Problem 06

            // string result = GetEmployeesInPeriod(db); // Problem 07

            // string result = GetAddressesByTown(db); // Problem 08

            string result = GetEmployee147(db);

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

        // Restore DB
        public static void Restore(SoftUniContext context)
        {
            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.AddressId = 291;

            var addressToDelete = context.Addresses
                .Where(a => a.AddressText == "Vitoshka 15");

            context.RemoveRange(addressToDelete.ToList());

            context.SaveChanges();
        }

        // Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                       .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue
                           ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                           : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                string managerFullName = $"{employee.ManagerFirstName} {employee.ManagerLastName}";

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {managerFullName}");

                foreach (var projects in employee.Projects)
                {
                    sb.AppendLine($"--{projects.ProjectName} - {projects.StartDate} - {projects.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var allAddresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var address in allAddresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectsName = ep.Project.Name
                        })
                        .OrderBy(ep => ep.ProjectsName)
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"{p.ProjectsName}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
