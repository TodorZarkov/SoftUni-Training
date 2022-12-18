using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            string garageName = "Garaja na Pesho  - Gosho & Stamat";
            int machinesAvailable = 2;

            Garage garage;
            Car car;

            [SetUp]
            public void Init()
            {
                garage = new Garage(garageName, machinesAvailable);
                car = new Car("Renault Megane", 3);
            }

            [Test]
            public void Constructor()
            {
                Garage garage = new Garage(garageName, machinesAvailable);
                Assert.AreEqual(garageName, garage.Name);
                Assert.AreEqual(machinesAvailable, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [TestCase("", 12)]
            public void NamePropInvalid(string name, int number)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, number));
            }

            [TestCase("   ", 12)]
            public void NamePropEdge(string name, int number)
            {
                Garage garage = new Garage(name, number);
                Assert.AreEqual(name, garage.Name);
            }

            [TestCase("some name", 1)]
            public void MachinesAvailablePropEdge(string name, int number)
            {
                Garage garage = new Garage(name, number);
                Assert.AreEqual(number, garage.MechanicsAvailable);
            }
            [TestCase("some name", -5)]
            public void MachinesAvailablePropInvalid(string name, int number)
            {
                Assert.Throws<ArgumentException>(() => new Garage(name, number));
            }
            [TestCase("some name", 0)]
            public void MachinesAvailablePropInvalidEdge(string name, int number)
            {
                Assert.Throws<ArgumentException>(() => new Garage(name, number));
            }

            [Test]
            public void AddCarMethod()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }
            [Test]
            public void AddCarMethodInvalid()
            {
                garage.AddCar(car);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car));
            }

            [Test]
            public void FixCarMethod()
            {
                garage.AddCar(new Car("1", 1));
                garage.AddCar(new Car("2", 2));
                Car car = garage.FixCar("1");
                Assert.AreEqual(0, car.NumberOfIssues);
            }
            [Test]
            public void FixCarMethodInvalid()
            {
                garage.AddCar(new Car("1", 1));
                garage.AddCar(new Car("2", 2));
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("5"));
            }

            [Test]
            public void RemoveFixedCarMethod()
            {
                garage.AddCar(new Car("1", 1));
                garage.AddCar(new Car("2", 2));
                Car car = garage.FixCar("1");
                Assert.AreEqual(1, garage.RemoveFixedCar());
            }
            [Test]
            public void RemoveFixedCarMethodInvalid()
            {
                garage.AddCar(new Car("1", 1));
                garage.AddCar(new Car("2", 2));
                Assert.Throws<InvalidOperationException>(()=>garage.RemoveFixedCar());
            }

            [Test]
            public void ReportMethod()
            {
                garage.AddCar(new Car("1", 1));
                garage.AddCar(new Car("2", 2));
                Car car = garage.FixCar("1");
                Assert.AreEqual("There are 1 which are not fixed: 2.", garage.Report());
            }
        }
    }
}