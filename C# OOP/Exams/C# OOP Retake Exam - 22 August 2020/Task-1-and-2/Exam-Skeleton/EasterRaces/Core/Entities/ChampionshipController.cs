using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> drivers;
        private IRepository<IRace> racers;
        private IRepository<ICar> cars;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            racers = new RaceRepository();
            
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            throw new NotImplementedException();
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            throw new NotImplementedException();
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            throw new NotImplementedException();
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            Driver currDriver = new Driver(driverName);
            drivers.Add(currDriver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
