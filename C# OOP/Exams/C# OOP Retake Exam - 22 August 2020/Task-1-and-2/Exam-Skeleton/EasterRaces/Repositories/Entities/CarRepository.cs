using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> carRepository;

        public CarRepository()
        {
            carRepository = new List<ICar>();
        }

        public void Add(ICar model)
        {
            carRepository.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return carRepository;
        }

        public ICar GetByName(string name)
        {
            return carRepository.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return carRepository.Remove(model);
        }
    }
}
