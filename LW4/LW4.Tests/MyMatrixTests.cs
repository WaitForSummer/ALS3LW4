using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW4.Tests
{
    // testing constructor, indexer, operators, and edge cases
    [TestClass]
    public class MyMatrixTests
    {
        // testing data constants
        private double testMin = 1.0;
        private double testMax = 10.0;

        private MyMatrix CreateTestMatrix(int rows, int columns)
        {
            return new MyMatrix(rows, columns, testMin, testMax);
        }

        // constructor tests
        // testing that constructor creates matrix with correct dimensions
        [TestMethod]
        public void Contructor_ValidDimensions_CreatesMatrixWithCorrectSize()
        {
            var matrix = CreateTestMatrix(3, 4);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(4, matrix.Columns);
        }

        // tesing that constructor throws exception for negative column count
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NegativeColumns_ThrowsArgumentException()
        {
            var matrix = CreateTestMatrix(2, -1);
        }

        // testing that constructor throws exception for zero row count
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ZeroRows_ThrowsArgumentExceprion()
        {
            var matrix = CreateTestMatrix(0, 3);
        }

        // Indexer testing
        // testing that indexer correctly retrieves values
        [TestMethod]
        public void Indexer_GetValidElement_ReturnsCorrectValue()
        {
            var matrix = new MyMatrix(2, 2, 0, 0);
            matrix[0, 0] = 5.5;
            matrix[1, 1] = 10.2;

            Assert.AreEqual(5.5, matrix[0, 0]);
            Assert.AreEqual(10.2, matrix[1, 1]);
        }

        // testing that indexer correctly sets values
        [TestMethod]
        public void Indexer_SetValidElement_ChangeValue()
        {
            var matrix = CreateTestMatrix(2, 2);
            double newValue = 7.7;

            matrix[1, 0] = newValue;

            Assert.AreEqual(newValue, matrix[1, 0]);
        }

        // testing that indexer throws exception for invalid row access
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetInvalidRow_ThrowsIndexOutOfRange()
        {
            var matrix = CreateTestMatrix(2, 2);

            var value = matrix[5, 0];
        }

        // testing that indexer throws exception for invalid column access
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_SetInvalidColumn_ThrowsIndexOutOfRangeExceprion()
        {
            var matrix = CreateTestMatrix(2, 2);

            matrix[0, -1] = 1.0;
        }

        // Operator tests
        // testing matrix addition
        [TestMethod]
        public void Addition_SameSizeMatrices_ReturnsCorrectSumNatrix()
        {
            var matrix1 = new MyMatrix(2, 2, 0, 0);
            var matrix2 = new MyMatrix(2, 2, 0, 0);

            matrix1[0, 0] = 1; matrix1[0, 1] = 2;
            matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            matrix2[0, 0] = 5; matrix2[0, 1] = 6;
            matrix2[1, 0] = 7; matrix2[1, 1] = 8;

            var result = matrix1 + matrix2;

            Assert.AreEqual(6, result[0, 0]);
            Assert.AreEqual(8, result[0, 1]);
            Assert.AreEqual(10, result[1, 0]);
            Assert.AreEqual(12, result[1, 1]);
        }

        // testing addition throws exception for different-sized matrices
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Addition_DifferenceSizeMatrices_ThrowsInvalidOperationException()
        {
            var matrix1 = CreateTestMatrix(2, 2);
            var matrix2 = CreateTestMatrix(3, 2);

            var result = matrix1 + matrix2;
        }
    }
}