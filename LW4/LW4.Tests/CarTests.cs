using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW4.Tests
{
    // Testing car
    [TestClass]
    public class CarTests
    {
        // testing constructor
        [TestMethod]
        public void Car_Constructor_SetsPropertiesCorrectly()
        {
            var car = new Car("Test Car", 2020, 200);

            Assert.AreEqual("Test Car", car.Name);
            Assert.AreEqual(2020, car.Year);
            Assert.AreEqual(200, car.Speed);
        }

        // testing tostring method
        [TestMethod]
        public void Car_ToString_ReturnsCorrectFormat()
        {
            var car = new Car("BMW M5", 2022, 250);

            var res = car.ToString();

            Assert.AreEqual("BMW M5 (2022), Max Speed: 250 km/h", res);
        }

        // testing editing prop
        [TestMethod]
        public void Car_Properties_CanBeModified()
        {
            var car = new Car("Initial", 2000, 100);

            car.Name = "Modified";
            car.Year = 2023;
            car.Speed = 300;

            Assert.AreEqual("Modified", car.Name);
            Assert.AreEqual(2023, car.Year);
            Assert.AreEqual(300, car.Speed);
        }
    }

    // testing car comperer
    [TestClass]
    public class CarCompererTests
    {
        // init field
        private Car[] testCars;

        [TestInitialize]
        public void Setup()
        {
            testCars = new Car[]
            {
                new Car("Toyota", 2020, 200),
                new Car("BMW", 2018, 250),
                new Car("Audi", 2022, 240),
                new Car("Honda", 2019, 180),
                new Car("Mercedes", 2021, 230)
            };
        }

        // testing compare by name
        [TestMethod]
        public void CarComparer_SortByName_AscendingOrder()
        {
            var comparer = new CarComparer(CarComparer.SortBy.Name);
            var exceptedOrder = new[] { "Audi", "BMW", "Honda", "Nercedes", "Toyota" };

            Array.Sort(testCars, comparer);

            for (int i = 0; i < testCars.Length; i++)
            {
                Assert.AreEqual(exceptedOrder[i], testCars[i].Name);
            }
        }

        // testing comapre by year
        [TestMethod]
        public void CarComperer_SortByYear_AscendingOrder()
        {
            var comparer = new CarComparer(CarComparer.SortBy.Year);
            var exceptedYear = new[] { 2018, 2019, 2020, 2021, 2022 };

            Array.Sort(testCars, comparer);

            for (int i = 0; i < testCars.Length; i++)
            {
                Assert.AreEqual(exceptedYear[i], testCars[i].Year);
            }
        }

        // testing sort by speed
        [TestMethod]
        public void CarComparer_SortBymaxSpeed_AscendingOrder()
        {
            var comparer = new CarComparer(CarComparer.SortBy.Speed);
            var exceptedSpeed = new[] { 180, 200, 230, 240, 250 };

            Array.Sort(testCars, comparer);

            for (int i = 0; i < testCars.Length; i++)
            {
                Assert.AreEqual(exceptedSpeed[i], testCars[i].Speed);
            }
        }

        // testing sort the first car is null
        [TestMethod]
        public void CarComparer_Compare_NullFirstCar_ReturnsNegative()
        {
            var comparer = new CarComparer(CarComparer.SortBy.Name);
            Car nullCar = null;
            var validCar = new Car("Test", 2020, 200);

            var res = comparer.Compare(validCar, nullCar);

            Assert.IsTrue(res < 0);
        }

        // testing sort the second car is null
        [TestMethod]
        public void CarComparer_Compare_NullSecondCar_ReturnsPositive()
        {
            var comparer = new CarComparer(CarComparer.SortBy.Name);
            var validCar = new Car("Test", 2020, 200);
            Car nullCar = null;

            var result = comparer.Compare(validCar, nullCar);

            Assert.IsTrue(result > 0);
        }

        // testing campare w both null obj
        [TestMethod]
        public void CarComparer_Compare_BothNull_ReturnsZero()
        {
            var comparer = new CarComparer(CarComparer.SortBy.Name);
            Car nullCar1 = null;
            Car nullCar2 = null;

            var result = comparer.Compare(nullCar1, nullCar2);

            Assert.AreEqual(0, result);
        }

        // test for campare w same names
        [TestMethod]
        public void CarComparer_SortByName_WithDuplicateNames()
        {
            var carsWithDuplicates = new Car[]
            {
                new Car("BMW", 2020, 200),
                new Car("Audi", 2019, 220),
                new Car("BMW", 2021, 240)
            };
            var comparer = new CarComparer(CarComparer.SortBy.Name);

            Array.Sort(carsWithDuplicates, comparer);

            Assert.AreEqual("Audi", carsWithDuplicates[0].Name);
        }

        // testing compare objects w same year
        [TestMethod]
        public void CarComparer_SortByYear_WithSameYears()
        {
            var carsWithSameYear = new Car[]
            {
                new Car("Car1", 2020, 200),
                new Car("Car2", 2020, 220),
                new Car("Car3", 2020, 180)
            };
            var comparer = new CarComparer(CarComparer.SortBy.Year);

            Array.Sort(carsWithSameYear, comparer);

            foreach (var car in carsWithSameYear)
            {
                Assert.AreEqual(2020, car.Year);
            }
        }
    }
}
