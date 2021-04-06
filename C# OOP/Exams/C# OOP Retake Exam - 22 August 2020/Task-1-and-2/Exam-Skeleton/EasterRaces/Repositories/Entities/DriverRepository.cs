using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> driverRepository;

        public DriverRepository()
        {
            driverRepository = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            driverRepository.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return driverRepository;
        }

        public IDriver GetByName(string name)
        {
            return driverRepository.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return driverRepository.Remove(model);
        }
    }
}
