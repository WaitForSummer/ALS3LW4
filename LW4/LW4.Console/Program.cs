using System;
using LW4;

namespace LW4.Console
{

    public class Program
    {
        public static void Task1()
        {
            // demostrating work of program for task 1
            System.Console.WriteLine("Please, enter number of rows for the first matrix: ");
            int rows = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Please, enter number of columns for the first matrix: ");
            int columns = int.Parse(System.Console.ReadLine());

            MyMatrix mm1 = new MyMatrix(rows, columns);

            System.Console.WriteLine("Please, enter number of rows for the second matrix: ");
            rows = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Please, enter number of columns for the second matrix: ");
            rows = int.Parse(System.Console.ReadLine());

            MyMatrix mm2 = new MyMatrix(rows, columns);

            MyMatrix resM = mm1 + mm2;
            System.Console.WriteLine($"Result of summaryzing matrices: ");
            resM.Print();

            resM = mm1 - mm2;
            System.Console.WriteLine($"Result of substracting matrices: ");
            resM.Print();

            resM = mm1 * 2;
            System.Console.WriteLine($"Result of multiplying the first matrix by number: ");
            resM.Print();

            resM = 5 * mm2;
            System.Console.WriteLine($"Result of multiplying the second matrix by number: ");
            resM.Print();

            resM = mm1 / 5;
            System.Console.WriteLine($"Result of dividing the first matrix by number: ");
            resM.Print();

            resM = mm2 / 5;
            System.Console.WriteLine($"Result of dividing the second matrix by number: ");
            resM.Print();

            resM = mm1 * mm2;
            System.Console.WriteLine($"Result of multiplying matrices: "); 
            resM.Print();
        }

        public static void Main(string[] args)
        {
            Task1();
        }
    }
}
