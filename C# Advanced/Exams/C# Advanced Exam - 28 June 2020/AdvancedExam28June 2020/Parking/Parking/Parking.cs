using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        //public int Count => data.Count;

        //or
        public int Count { get { return data.Count; } }
        public string Type { get; set; }

        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model);

            if (car == null)
            {
                return false;
            }

            data.Remove(car);
            return true;

        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(y => y.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();

            statistics.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                statistics.AppendLine(car.ToString());
            }
            return statistics.ToString();
        }
    }
}
