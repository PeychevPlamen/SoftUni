using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();

        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + components.Average(x => x.OverallPerformance); 
            }
        }

        public override decimal Price
            => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(x=>x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, Id));
            }

            var compToRemove = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(compToRemove);

            return compToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(x=>x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, Id));
            }

            var peripheralToRemove = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            double peripheralsAverage = Peripherals.Count > 0 ? Peripherals.Average(x => x.OverallPerformance) : 0;

            StringBuilder sb = new StringBuilder(0);

            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format(SuccessMessages.ComputerComponentsToString, components.Count));

            foreach (var comp in components)
            {
                sb.AppendLine($"  {comp}");
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripheralsAverage:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
