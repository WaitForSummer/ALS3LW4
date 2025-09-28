using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LW4.Tests
{
    [TestClass]
    public sealed class MyMatrixTests
    {
        // min and max values
        private double minTest = 1.0;
        private double maxTest = 10.0;

        // method
        private MyMatrix CreatetestMatrix(int rows, int columns)
        {
            var matrix = new MyMatrix(rows, columns, minTest, maxTest);
        }

        // Testing constructor
        [TestMethod]
        public void constructorTesting()
        {
            MyMatrix testMatrix = new MyMatrix(3, 4);
        }
    }
}
