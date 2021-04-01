using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TheRace;
using System.Linq;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry race;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
        }

        [Test]
        public void TestAddDriver()
        {
            UnitCar car = new UnitCar("bmw", 150, 2000);
            UnitDriver driver = new UnitDriver("pesho", car);

            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void AddDriverThrowException_IfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void IfDriverName_IsAlreadyExist_ThrowException()
        {
            UnitCar car = new UnitCar("bmw", 150, 2000);
            UnitDriver driver = new UnitDriver("pesho", car);
            UnitCar newCar = new UnitCar("vw", 200, 1800);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(new UnitDriver("pesho", newCar)));
        }
        [Test]
        public void TestIfAddDriverThrowCorrectMessage()
        {
            UnitCar car = new UnitCar("bmw", 150, 2000);
            UnitDriver driver = new UnitDriver("pesho", car);

            Assert.AreEqual(race.AddDriver(driver), $"Driver {driver.Name} added in race.");

        }

        [Test]
        public void IfDriverCount_IsLessThenMinPaticipants()
        {
            UnitCar car = new UnitCar("bmw", 150, 2000);
            UnitDriver driver = new UnitDriver("pesho", car);

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());

        }

        [Test]
        public void AverageHorsePower()
        {
            UnitCar car;
            UnitDriver driver;
            double expectedResult = 0;

            for (int i = 0; i < 3; i++)
            {
                car = new UnitCar($"brand{i}",i+100, 1500 + i);
                driver = new UnitDriver($"name{i}", car);
                expectedResult += car.HorsePower;

                race.AddDriver(driver);
            }

            Assert.AreEqual(expectedResult / 3, race.CalculateAverageHorsePower());
           
        }
    }
}