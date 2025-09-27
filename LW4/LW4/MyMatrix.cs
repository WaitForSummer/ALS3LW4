using System;

namespace LW4
{
    public class MyMatrix
    {
        // fields
        private int m;
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
        }

    }
}
