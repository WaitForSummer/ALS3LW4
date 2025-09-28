using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW4.Tests
{
    [TestClass]
    public class MyMatrixTests
    {
        private double testMin = 1.0;
        private double testMax = 10.0;

        // support method
        private MyMatrix CreateTestMatrix(int rows, int columns)
        {
            return new MyMatrix(rows, columns, testMin, testMax);
        }

        // Testing constructor
        [TestMethod]
        public void Contructor_ValidDimensions_CreatesMatrixWithCorrectSize()
        {
            var matrix = CreateTestMatrix(3, 4);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(4, matrix.Columns);
        }

        // Testing constructor with negative columns variable
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NegativeColumns_ThrowsArgumentException()
        {
            var matrix = CreateTestMatrix(2, -1);
        }

        // Testing constructor with zero rows variable
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ZeroRows_ThrowsArgumentExceprion()
        {
            var matrix = CreateTestMatrix(0, 3);
        }

        // Testing indexer getting
        [TestMethod]
        public void Indexer_GetValidElement_ReturnsCorrectValue()
        {
            var matrix = new MyMatrix(2, 2, 0, 0);
            matrix[0, 0] = 5.5;
            matrix[1, 1] = 10.2;

            Assert.AreEqual(5.5, matrix[0, 0]);
            Assert.AreEqual(10.2, matrix[1, 1]);
        }

        // Testing indexer setting
        [TestMethod]
        public void Indexer_SetValidElement_ChangeValue()
        {
            var matrix = CreateTestMatrix(2, 2);
            double newValue = 7.7;

            matrix[1, 0] = newValue;

            Assert.AreEqual(newValue, matrix[1, 0]);
        }

        // Testing invalid getting argument for indexer
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetInvalidRow_ThrowsIndexOutOfRange()
        {
            var matrix = CreateTestMatrix(2, 2);

            var value = matrix[5, 0];
        }

        // Testing invalid setting argument for indexer
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_SetInvalidColumn_ThrowsIndexOutOfRangeExceprion()
        {
            var matrix = CreateTestMatrix(2, 2);

            matrix[0, -1] = 1.0;
        }

        // Testing for sum
        [TestMethod]
        public void Addition_SameSizeMatrices_ReturnsCorrectSumNatrix()
        {
            var matrix1 = new MyMatrix(2, 2, 0, 0);
            var matrix2 = new MyMatrix(2, 2, 0, 0);

            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            matrix2[0, 0] = 5;
            matrix2[0, 1] = 6;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 8;

            var result = matrix1 + matrix2;

            Assert.AreEqual(6, result[0, 0]);
            Assert.AreEqual(8, result[0, 1]);
            Assert.AreEqual(10, result[1, 0]);
            Assert.AreEqual(12, result[1, 1]);
        }

        // Testing addition method
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Addition_DifferenceSizeMatrices_ThrowsInvalidOperationException()
        {
            var matrix1 = CreateTestMatrix(2, 2);
            var matrix2 = CreateTestMatrix(3, 2);

            var result = matrix1 + matrix2;
        }

        // Testing substraction method
        [TestMethod]
        public void Substraction_SameSizeMatrices_ReturnsCorrectDifferenceMatrix()
        {
            var matrix1 = new MyMatrix(2, 2, 0, 0);
            var matrix2 = new MyMatrix(2, 2, 0, 0);

            matrix1[0, 0] = 10;
            matrix1[0, 1] = 8;
            matrix1[1, 0] = 6;
            matrix1[1, 1] = 4;

            matrix2[0, 0] = 1;
            matrix2[0, 1] = 2;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 4;

            var result = matrix1 - matrix2;

            Assert.AreEqual(9, result[0, 0]);
            Assert.AreEqual(6, result[0, 1]);
            Assert.AreEqual(3, result[1, 0]);
            Assert.AreEqual(0, result[1, 1]);
        }

        // Testing substraction method with difference size
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Substraction_DifferenceSizeMatrices_ThrowsInvalidOperationException()
        {
            var matrix1 = CreateTestMatrix(2, 2);
            var matrix2 = CreateTestMatrix(3, 3);

            var result = matrix1 - matrix2;
        }

        // Testing scalar multiplication right
        [TestMethod]
        public void ScalarMultiplication_MatrixOnRight_ReturnsCorrectResult()
        {
            var matrix = new MyMatrix(2, 2, 0, 0);
            matrix[0, 0] = 2;
            matrix[0, 1] = 4;
            matrix[1, 0] = 6;
            matrix[1, 1] = 8;
            double scalar = 3;

            var res = matrix * scalar;

            Assert.AreEqual(6, res[0, 0]);
            Assert.AreEqual(12, res[0, 1]);
            Assert.AreEqual(18, res[1, 0]);
            Assert.AreEqual(24, res[1, 1]);
        }

        // Testing scalar multiplication left
        [TestMethod]
        public void ScalarMultiplication_ScalarOnLeft_ReturnsSameResult()
        {
            var matrix = new MyMatrix(2, 2, 0, 0);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
            double scalar = 2;

            var res1 = matrix * scalar;
            var res2 = scalar * matrix;

            Assert.AreEqual(res1[0, 0], res2[0, 0]);
            Assert.AreEqual(res1[0, 1], res2[0, 1]);
            Assert.AreEqual(res1[1, 0], res2[1, 0]);
            Assert.AreEqual(res1[1, 1], res2[1, 1]);
        }

        // Testing division
        [TestMethod]
        public void ScalarDivision_ValidDivisor_ReturnsCorrectResult()
        {
            var matrix = new MyMatrix(2, 2, 0, 0);
            matrix[0, 0] = 10;
            matrix[0, 1] = 20;
            matrix[1, 0] = 30;
            matrix[1, 1] = 40;
            double divisor = 2;

            var res = matrix / divisor;

            Assert.AreEqual(5, res[0, 0]);
            Assert.AreEqual(10, res[0, 1]);
            Assert.AreEqual(15, res[1, 0]);
            Assert.AreEqual(20, res[1, 1]);
        }

        // Testing division by zero
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ScalarDivision_ByZero_ThrowsDivideByZeroException()
        {
            var matrix = CreateTestMatrix(2, 2);

            var res = matrix / 0;
        }

        // Testing matrix multiplication
        [TestMethod]
        public void MatrixMultiplication_ValidMatrices_ReturnsCorrectProduct()
        {
            var matrix1 = new MyMatrix(2, 3, 0, 0);
            var matrix2 = new MyMatrix(3, 2, 0, 0);

            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = 3;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 5;
            matrix1[1, 2] = 6;

            matrix2[0, 0] = 7;
            matrix2[0, 1] = 8;
            matrix2[1, 0] = 9;
            matrix2[1, 1] = 10;
            matrix2[2, 0] = 11;
            matrix2[2, 1] = 12;

            var res = matrix1 * matrix2;

            Assert.AreEqual(2, res.Rows);
            Assert.AreEqual(2, res.Columns);

            Assert.AreEqual(58, res[0, 0]);
            Assert.AreEqual(64, res[0, 1]);
            Assert.AreEqual(139, res[1, 0]);
            Assert.AreEqual(154, res[1, 1]);
        }

        // Testing wrong matrix multiplication
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MatrixMultiplication_IncompatibleSizes_ThrowsInvalidOperationException()
        {
            var matrix1 = CreateTestMatrix(2, 3);
            var matrix2 = CreateTestMatrix(2, 3);

            var res = matrix1 * matrix2;
        }

        // Testing identity matrix
        [TestMethod]
        public void MatrixMultiplication_IdentityMatrix_ReturnsOriginalMatrix()
        {
            var matrix = new MyMatrix(2, 2, 0, 0);
            matrix[0, 0] = 2;
            matrix[0, 1] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;

            var identity = new MyMatrix(2, 2, 0, 0);
            identity[0, 0] = 1;
            identity[0, 1] = 0;
            identity[1, 0] = 0;
            identity[1, 1] = 1;

            var res = matrix * identity;

            Assert.AreEqual(matrix[0, 0], res[0, 0]);
            Assert.AreEqual(matrix[0, 1], res[0, 1]);
            Assert.AreEqual(matrix[1, 0], res[1, 0]);
            Assert.AreEqual(matrix[1, 1], res[1, 1]);
        }

        // Testing constructor
        public void Properties_RowsAndColumns_ReturnCorrectValues()
        {
            var matrix = CreateTestMatrix(2, 2);

            // if not exception - true
            try
            {
                matrix.Print();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Method Print exception: {ex.Message}");
            }
        }

        // Testing superposition of methods
        [TestMethod]
        public void MultipleOperations_CombinationOfOperations_ReturnsCorrectResult()
        {
            var matrix1 = new MyMatrix(2, 2, 0, 0);
            var matrix2 = new MyMatrix(2, 2, 0, 0);

            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            matrix2[0, 0] = 2;
            matrix2[0, 1] = 0;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = 2;

            var res = (matrix1 + matrix2) * 2;

            Assert.AreEqual(6, res[0, 0]);
            Assert.AreEqual(4, res[0, 1]);
            Assert.AreEqual(8, res[1, 0]);
            Assert.AreEqual(12, res[1, 1]);
        }
    }
}