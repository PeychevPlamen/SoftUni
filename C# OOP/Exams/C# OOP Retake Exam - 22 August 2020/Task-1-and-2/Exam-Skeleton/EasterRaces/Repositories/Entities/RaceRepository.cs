using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> raceRepository;

        public RaceRepository()
        {
            raceRepository = new List<IRace>();
        }

        public void Add(IRace model)
        {
            raceRepository.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return raceRepository;
        }

        public IRace GetByName(string name)
        {
            return raceRepository.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return raceRepository.Remove(model);
        }
    }
}
