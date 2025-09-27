﻿using System;
using System.Runtime.Serialization.Formatters;

namespace LW4
{
    public class MyMatrix
    {
        // fields
        // row
        private int m; 
        // column
        private int n;
        private double[,] matrix;
        
        // Constructor
        public MyMatrix(int m, int n)
        {
            // Check for correct params
            if (m <= 0 || n <= 0)
                throw new ArgumentException("Count of n or/and m must be >0");

            // initializing
            this.m = m;
            this.n = n;
            matrix = new double[m, n];

            // Entering min value
            Console.WriteLine("Enter min value for elements: ");
            double min = double.Parse(Console.ReadLine());

            // Entering max value
            Console.WriteLine("Enter max value for elements: ");
            double max = double.Parse(Console.ReadLine());

            // filling elements w rand values
            Random random = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = (random.NextDouble() + min) % max;
        }

        // user indexator
        public double this[int row, int col]
        {
            get 
            {
                if (row < 0 || row >= m || col < 0 || col >= n)
                    throw new IndexOutOfRangeException("Oops! Index out of range");

                return matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= m || col < 0 || col >= n)
                    throw new IndexOutOfRangeException("Oops! Index out of range");

                matrix[row, col] = value;
            }
        }

        // Overriden operators
        // overrriden summary operator
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            // checking
            if (a.m != b.m || a.n != b.n)
                throw new InvalidOperationException("You can only summarize matrices of the same size.");

            // initializing
            MyMatrix newMatrix = new MyMatrix(a.m, a.n);

            // summary 
            for (int i = 0; i < a.m; i++)
                for (int j = 0; j < a.n; j++)
                    newMatrix.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];

            // returning result
            return newMatrix;
        }

        // overrriden difference operator
        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            // checking
            if (a.n != b.n || a.m != b.m) 
                throw new InvalidOperationException("You can only substract mattrices of the same size.");
            // initializing
            MyMatrix newMatrix = new MyMatrix(a.m, a.n);

            // summary 
            for (int i = 0; i < a.m; i++)
                for (int j = 0; j < a.n; j++)
                    newMatrix.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];

            // returning result
            return newMatrix;
        }

        // overriden multiplying by number (matrix from the left side)
        public static MyMatrix operator*(MyMatrix a, double num)
        {
            // initializing
            MyMatrix newMatrix = new MyMatrix(a.m, a.n);

            // multiplying
            for (int i = 0; i < a.m; i++)
                for (int j = 0; j < a.n; j++)
                    newMatrix.matrix[i, j] = num * a.matrix[i, j];

            // returning result
            return newMatrix;
        }

        // overriden multiplying by number (number from the left side)
        public static MyMatrix operator *(double num, MyMatrix a)
        {
            MyMatrix newMatrix = a * num;

            return newMatrix;
        }

        // overriden dividing by number
        public static MyMatrix operator /(MyMatrix a, double num)
        {
            // checking
            if (num == 0)
                throw new DivideByZeroException("Sudenly, you can't divide by zero(((");
            // initializing
            MyMatrix newMatrix = new MyMatrix(a.m, a.n);

            // multiplying
            for (int i = 0; i < a.m; i++)
                for (int j = 0; j < a.n; j++)
                    newMatrix.matrix[i, j] = num / a.matrix[i, j];

            // returning result
            return newMatrix;
        }

        // overriden multiplying among matrix
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            // checking
            if (a.n != b.m)
                throw new InvalidOperationException("Wrong matrix to multiplying");

            // initializing
            MyMatrix newMatrix = new MyMatrix(a.m, a.n);

            // multiplying
            for (int i = 0; i < a.m; ++i)
            {
                for (int j = 0; j < b.n; ++j)
                {
                    double sum = 0;
                    for (int k = 0; k < a.n; ++k)
                        sum += a.matrix[i, k] * b.matrix[k, j];

                    newMatrix.matrix[i, j] = sum;
                }
            }
            return newMatrix;
        }
    }
}
