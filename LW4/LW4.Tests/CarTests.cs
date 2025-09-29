using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
            var exceptedOrder = new[] { "Audi", "BMW", "Honda", "Mercedes", "Toyota" };

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

            Assert.IsTrue(res > 0);
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

    // testing car catalog
    [TestClass]
    public class CarCatalogTests
    {
        private Car[] testCars;
        private CarCatalog carCatalog;

        // testing initializing
        [TestInitialize]
        public void Setup()
        {
            testCars = new Car[]
            {
                new Car("Toyota Camry", 2020, 210),
                new Car("BMW X5", 2018, 250),
                new Car("Audi A4", 2022, 240),
                new Car("Honda Civic", 2019, 200),
                new Car("Mercedes C-Class", 2021, 230),
                new Car("Ford Focus", 2018, 190),
                new Car("Tesla Model 3", 2022, 260),
                new Car("Volkswagen Golf", 2020, 220)
            };

            carCatalog = new CarCatalog(testCars);
        }

        // testing constructor
        [TestMethod]
        public void CarCatalog_ConstructorIsCorrectlyWork()
        {
            Car[] testCars = new Car[]
            {
                new Car("Toyota", 2020, 200),
                new Car("BMW", 2018, 250),
                new Car("Audi", 2022, 240),
                new Car("Honda", 2019, 180),
                new Car("Mercedes", 2021, 230)
            };
            CarCatalog testCarCatalog = new CarCatalog(testCars);

            var exceptedNames = new string[] { "Toyota", "BMW", "Audi", "Honda", "Mercedes" };
            var exceptedYears = new int[] { 2020, 2018, 2022, 2019, 2021 };
            var exceptedMaxSpeeds = new int[] { 200, 250, 240, 180, 230 };

            for (int i = 0; i < testCars.Length; i++)
            {
                Assert.AreEqual(exceptedNames[i], testCarCatalog[i].Name);
                Assert.AreEqual(exceptedYears[i], testCarCatalog[i].Year);
                Assert.AreEqual(exceptedMaxSpeeds[i], testCarCatalog[i].Speed);
            }
        }

        // testing constructor for exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarCatalog_AcceptingIncorrectArgument_ShouldGiveException()
        {
            var testCarCatalog = new CarCatalog(null);
        }

        // testing GetEnumerator
        [TestMethod]
        public void CarCatalog_GetEnumerator_ReturnsAllCarsInOrder()
        {
            var expectedNames = testCars.Select(c => c.Name).ToArray();

            var res = new List<string>();
            foreach (var car in carCatalog)
            {
                res.Add(car.Name);
            }

            CollectionAssert.AreEqual(expectedNames, res);
        }

        // testing reverse
        [TestMethod]
        public void CarCatalog_Reverse_ReturnsCarsInReverseOrder()
        {
            var expectedNames = testCars.Select(c => c.Name).Reverse().ToArray();

            var res = new List<string>();
            foreach(var car in carCatalog.Reverse())
            {
                res.Add(car.Name);
            }

            CollectionAssert.AreEqual(expectedNames, res);
        }

        // testing filter by year
        [TestMethod]
        public void FilterByYear_ExistingYear_ReturnsCorrectCars()
        {
            int targetYear = 2020;

            var res = new List<Car>();
            foreach (var car in carCatalog.FilterByProductionYear(targetYear)) 
            {
                res.Add(car);
            }

            Assert.AreEqual(2, res.Count);
            foreach (var car in res)
            {
                Assert.AreEqual(targetYear, car.Year);
            }
        }

        // testing filter by not existing year
        [TestMethod]
        public void FilterByYear_NotExistingYear_ReturnsEmptyCollection()
        {
            int targetYear = 1990;

            var res = new List<Car>();
            foreach (var car in carCatalog.FilterByProductionYear(targetYear))
            {
                res.Add(car);
            }

            Assert.AreEqual(0, res.Count);
        }

        // testing filter by year valid range
        [TestMethod]
        public void FilterByProductionYearRange_ValidRange_ReturnsCorrectCars()
        {
            int startYear = 2019;
            int endYear = 2021;

            var result = new List<Car>();
            foreach (var car in carCatalog.FilterByProductionYearRange(startYear, endYear))
            {
                result.Add(car);
            }

            Assert.AreEqual(4, result.Count);
            foreach (var car in result)
            {
                Assert.IsTrue(car.Year >= startYear);
                Assert.IsTrue(car.Year <= endYear);
            }
        }

        // testing filter by speed 
        [TestMethod]
        public void FilterByMaxSpeed_ValidSpeed_ReturnsCorrectCars()
        {
            
            int minSpeed = 230;

            
            var result = new List<Car>();
            foreach (var car in carCatalog.FilterByMaxSpeed(minSpeed))
            {
                result.Add(car);
            }

            // Assert
            Assert.AreEqual(4, result.Count);
            foreach (var car in result)
            {
                Assert.IsTrue(car.Speed >= minSpeed);
            }
        }

        [TestMethod]
        public void FilterByMaxSpeedRange_ValidRange_ReturnsCorrectCars()
        {
            
            int minSpeed = 200;
            int maxSpeed = 230;

            
            var result = new List<Car>();
            foreach (var car in carCatalog.FilterByMaxSpeedRange(minSpeed, maxSpeed))
            {
                result.Add(car);
            }

            // Assert
            Assert.AreEqual(4, result.Count);
            foreach (var car in result)
            {
                Assert.IsTrue(car.Speed >= minSpeed);
                Assert.IsTrue(car.Speed <= maxSpeed);
            }
        }

        [TestMethod]
        public void FilterByName_ExistingName_ReturnsCorrectCars()
        {
            
            string searchTerm = "a";

            
            var result = new List<Car>();
            foreach (var car in carCatalog.FilterByName(searchTerm))
            {
                result.Add(car);
            }

            // Assert
            Assert.IsTrue(result.Count > 0);
            foreach (var car in result)
            {
                Assert.IsTrue(car.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }
        }

        [TestMethod]
        public void FilterByName_NonExistingName_ReturnsEmptyCollection()
        {
            
            string searchTerm = "XYZ";

            
            var result = new List<Car>();
            foreach (var car in carCatalog.FilterByName(searchTerm))
            {
                result.Add(car);
            }

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void MultipleIterators_WorkIndependently()
        {
            
            var forwardResults = new List<string>();
            var reverseResults = new List<string>();

            
            foreach (var car in carCatalog)
            {
                forwardResults.Add(car.Name);
            }

            foreach (var car in carCatalog.Reverse())
            {
                reverseResults.Add(car.Name);
            }

            // Assert
            Assert.AreEqual(testCars.Length, forwardResults.Count);
            Assert.AreEqual(testCars.Length, reverseResults.Count);
            CollectionAssert.AreEqual(forwardResults.AsEnumerable().Reverse().ToList(), reverseResults);
        }

        [TestMethod]
        public void EmptyCatalog_AllIterators_ReturnNoElements()
        {
            
            var emptyCatalog = new CarCatalog(new Car[0]);

            int count = 0;
            foreach (var car in emptyCatalog)
            {
                count++;
            }
            Assert.AreEqual(0, count);

            count = 0;
            foreach (var car in emptyCatalog.Reverse())
            {
                count++;
            }
            Assert.AreEqual(0, count);

            count = 0;
            foreach (var car in emptyCatalog.FilterByProductionYear(2020))
            {
                count++;
            }
            Assert.AreEqual(0, count);
        }
    }
}