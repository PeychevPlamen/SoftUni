using EasterRaces.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
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
            throw new NotImplementedException();
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
