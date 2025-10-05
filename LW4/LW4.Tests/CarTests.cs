using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace LW4.Tests
{
    /// <summary>
    /// Unit tests for Car class
    /// Tests constructor, properties, and ToString method
    /// </summary>
    [TestClass]
    public class CarTests
    {
        /// <summary>
        /// Tests that constructor correctly sets all properties
        /// </summary>
        [TestMethod]
        public void Car_Constructor_SetsPropertiesCorrectly()
        {
            var car = new Car("Test Car", 2020, 200);

            Assert.AreEqual("Test Car", car.Name);
            Assert.AreEqual(2020, car.ProductionYear);
            Assert.AreEqual(200, car.MaxSpeed);
        }

        /// <summary>
        /// Tests that ToString returns correctly formatted string
        /// </summary>
        [TestMethod]
        public void Car_ToString_ReturnsCorrectFormat()
        {
            var car = new Car("BMW M5", 2022, 250);

            var res = car.ToString();

            Assert.AreEqual("BMW M5 (2022), Max Speed: 250 km/h", res);
        }

        /// <summary>
        /// Tests that car properties can be modified after creation
        /// </summary>
        [TestMethod]
        public void Car_Properties_CanBeModified()
        {
            var car = new Car("Initial", 2000, 100);

            car.Name = "Modified";
            car.ProductionYear = 2023;
            car.MaxSpeed = 300;

            Assert.AreEqual("Modified", car.Name);
            Assert.AreEqual(2023, car.ProductionYear);
            Assert.AreEqual(300, car.MaxSpeed);
        }
    }
}