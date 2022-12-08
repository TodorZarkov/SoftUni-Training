namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        Car regularCar;
        Car car50l;

        [SetUp]
        public void Init()
        {
            regularCar = new Car("BMW", "3", 12.58, 70.5);
            car50l = new Car("BMW", "3", 10, 70.5);
            car50l.Refuel(50);
        }


        [Test]
        public void Test_Constructor_Regular()
        {
            Car car = new Car("BMW", "3", 12.58, 70.5);
            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("3", car.Model);
            Assert.AreEqual(12.58, car.FuelConsumption);
            Assert.AreEqual(70.5, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void Test_Constructor_Incorrect()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "3", 12.58, 70.5));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "", 12.58, 70.5));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "3", 0, 70.5));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "3", -5, 70.5));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "3", 12.58, 0));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "3", 12.58, -5));
        }

        [Test]
        public void Test_Refuel_Regular()
        {
            regularCar.Refuel(55.88);
            Assert.AreEqual(55.88, regularCar.FuelAmount,"regular");
            regularCar.Refuel(2);
            Assert.AreEqual(57.88, regularCar.FuelAmount,"regular consecutive");
            regularCar.Refuel(20);
            Assert.AreEqual(70.5, regularCar.FuelAmount,"irregular overfueling");
        }
        
        [Test]
        public void Test_Refuel_Edge()
        {
            regularCar.Refuel(70.5);
            Assert.AreEqual(70.5, regularCar.FuelAmount,"edge full");
        }

        [Test]
        public void Test_Refuel_Incorrect()
        {
            Assert.Throws<ArgumentException>(() => regularCar.Refuel(0));
            Assert.Throws<ArgumentException>(() => regularCar.Refuel(-2));
            //Assert.Throws<ArgumentException>(() => regularCar.Refuel(100));
        }

        [Test]
        public void Test_Drive_Regular()
        {
            car50l.Drive(150);
            Assert.AreEqual(35.0d, car50l.FuelAmount,"regular");
            car50l.Drive(100);
            Assert.AreEqual(25.0d, car50l.FuelAmount,"consecutive");
            car50l.Drive(250);
            Assert.AreEqual(0.0d, car50l.FuelAmount,"edge");

            car50l.Drive(-5);
            Assert.AreEqual(0.5d, car50l.FuelAmount,"strange case");
            car50l.Drive(0);
            Assert.AreEqual(0.5d, car50l.FuelAmount,"edge 0");

        }

        [Test]
        public void Test_Drive_Incorrect()
        {
            Assert.Throws<InvalidOperationException>(() => car50l.Drive(500.1));
        }
    }
}