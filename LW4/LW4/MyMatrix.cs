using System;

namespace LW4
{
    public class MyMatrix
    {
        // private fields
        private int rows;
        private int columns;
        private double[,] matrix;

        // main constructor
        public MyMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("Count of rows and columns must be greater than 0");

            // init matrix
            this.rows = rows;
            this.columns = columns;
            matrix = new double[rows, columns];

            // get value range
            Console.WriteLine("\nEnter minimum value for matrix elements: ");
            double min = double.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter maximum value for matrix elements: ");
            double max = double.Parse(Console.ReadLine());

            // fill matrix with random values
            Random random = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = random.NextDouble() * (max - min) + min;
        }

        // used for testing
        public MyMatrix(int rows, int columns, double min, double max)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("Count of rows and columns must be greater than 0");

            this.rows = rows;
            this.columns = columns;
            matrix = new double[rows, columns];

            Random random = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = random.NextDouble() * (max - min) + min;
        }

        // public properties
        public int Rows => rows;
        public int Columns => columns;

        // user indexer
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= rows || column < 0 || column >= columns)
                    throw new IndexOutOfRangeException("Matrix index is out of range");
                return matrix[row, column];
            }
            set
            {
                if (row < 0 || row >= rows || column < 0 || column >= columns)
                    throw new IndexOutOfRangeException("Matrix index is out of range");
                matrix[row, column] = value;
            }
        }

        // Overriden operators
        // addition operator
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.rows != b.rows || a.columns != b.columns)
                throw new InvalidOperationException("Matrices must have the same dimensions for addition");

            MyMatrix result = new MyMatrix(a.rows, a.columns, 0, 0);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.columns; j++)
                    result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];

            return result;
        }

        // subtraction operator
        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            if (a.rows != b.rows || a.columns != b.columns)
                throw new InvalidOperationException("Matrices must have the same dimensions for subtraction");

            MyMatrix result = new MyMatrix(a.rows, a.columns, 0, 0);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.columns; j++)
                    result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];

            return result;
        }

        // scalar multiplication (matrix on right, scalar on left)
        public static MyMatrix operator *(MyMatrix a, double scalar)
        {
            MyMatrix result = new MyMatrix(a.rows, a.columns, 0, 0);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.columns; j++)
                    result.matrix[i, j] = a.matrix[i, j] * scalar;

            return result;
        }

        // scalar multiplication (scalar on left, matrix on right)
        public static MyMatrix operator *(double scalar, MyMatrix a)
        {
            return a * scalar;
        }

        // scalar division
        public static MyMatrix operator /(MyMatrix a, double scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("Division by zero is not allowed");

            MyMatrix result = new MyMatrix(a.rows, a.columns, 0, 0);
            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.columns; j++)
                    result.matrix[i, j] = a.matrix[i, j] / scalar;

            return result;
        }

        // multiplication operator
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.columns != b.rows)
                throw new InvalidOperationException("Number of columns in first matrix must equal number of rows in second matrix for multiplication");

            MyMatrix result = new MyMatrix(a.rows, b.columns, 0, 0);

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.columns; k++)
                        sum += a.matrix[i, k] * b.matrix[k, j];
                    result.matrix[i, j] = sum;
                }
            }
            return result;
        }

        // print matrix
        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]:F2}\t");
                }
                Console.WriteLine();
            }
        }
    }
}