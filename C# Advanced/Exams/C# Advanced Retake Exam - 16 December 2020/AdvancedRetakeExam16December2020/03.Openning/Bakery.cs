using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        public int Count => data.Count;
        //or
        // public int Count { get { return data.Count; } }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            if (employee == null)
            {
                return false;
            }

            data.Remove(employee);
            return true;
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }
        public string Report()
        {
            StringBuilder employee = new StringBuilder();

            employee.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var person in data)
            {
                employee.AppendLine(person.ToString());
            }

            return employee.ToString();
        }
    }
}
