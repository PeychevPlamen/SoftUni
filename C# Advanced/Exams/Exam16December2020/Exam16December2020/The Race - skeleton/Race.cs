using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public int Count => data.Count;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Racer racer)
        {
            if (Capacity > Count)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(m => m.Name == name);

            if (racer == null)
            {
                return false;
            }

            data.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"Racers participating at {Name}:");

            foreach (var item in data)
            {
                report.AppendLine(item.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
