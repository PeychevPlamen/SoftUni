using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private string make;

        private string model;

        private double fuelConsumption;

        private double fuelCapacity;


        [SetUp]
        public void Setup()
        {
            make = "Make";
            model = "Model";
            fuelConsumption = 10;
            fuelCapacity = 100;

            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        [TestCase("make ", "Model", 0, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("make ", "", 10, 100)]
        [TestCase("make ", "Model", -10, 100)]
        [TestCase("make ", "Model", 10, 0)]
        public void Ctor_CheckIfThrowException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Test_Car_Make_IsInvalid_ThrowException()
        {
            make = null;

            Assert.Throws<ArgumentException>(() => new CarManager.Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Check_Car_Make_IsValid()
        {
            make = "BMW";

            string expectedMake = make;

            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(expectedMake, car.Make);

        }

        [Test]
        public void Check_Car_Model_IsValid()
        {
            model = "X3";

            string expectedModel = model;

            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(expectedModel, car.Model);

        }

        [Test]
        [TestCase(15)]
        [TestCase(77)]
        [TestCase(5)]
        public void FuelConsumption_IsValid(double fuel)
        {
            fuelConsumption = fuel;

            double expectedFuelConsuption = fuel;

            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(expectedFuelConsuption, car.FuelConsumption);
        }

        [Test]
        public void FuelCapacity_IsValid()
        {
            fuelCapacity = 99;

            double expectedFuelCapacity = fuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, new CarManager.Car(make, model, fuelConsumption, fuelCapacity).FuelCapacity);
        }

        [Test]
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(-99)]
        public void FuelToRefuel_ThrowException_IsInvalid(double fuelRefuel)
        {
            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelRefuel));
        }

        [Test]
        public void FuelToRefuel_Is_Valid()
        {
            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(55);

            double expectedCarFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedCarFuelAmount, 55);
        }

        [Test]
        public void Drive_A_Car_IsValid()
        {
            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(100);

            double fuelNeeded = (50 / 100) * fuelConsumption;

            car.Drive(50);

            double expectedResult = car.FuelAmount - fuelNeeded;


            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        public void Check_If_Trunk_Is_Empty_ThrowException()
        {
            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10));

        }

        [Test]
        public void Check_If_DecreaseFuelAmount_If_DriveIsValid()
        {
            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(car.FuelCapacity);

            car.Drive(100);

            Assert.That(car.FuelAmount, Is.LessThan(car.FuelCapacity));
        }

        [Test]
        [TestCase(150)]
        public void Test_Refuel_IfAmountIsBigger_ThanCapacity(double fuelToRefuel)
        {
            CarManager.Car car = new CarManager.Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            double expectedAmount = car.FuelCapacity;

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }
    }
}