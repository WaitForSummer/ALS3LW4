using System;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using LW4;

namespace LW4.Console
{

    public class Program
    {
        public static void Task1()
        {
            // demostrating work of program for task 1
            System.Console.WriteLine("=== Starting task 1 ===\n");
            System.Console.WriteLine("Please, enter number of rows for the first matrix: ");
            int rows = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("\nPlease, enter number of columns for the first matrix: ");
            int columns = int.Parse(System.Console.ReadLine());

            MyMatrix mm1 = new MyMatrix(rows, columns);

            System.Console.WriteLine("\nPlease, enter number of rows for the second matrix: ");
            rows = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Please, enter number of columns for the second matrix: ");
            rows = int.Parse(System.Console.ReadLine());

            MyMatrix mm2 = new MyMatrix(rows, columns);
            
            System.Console.WriteLine("\nMatrix 1: ");
            mm1.Print();

            System.Console.WriteLine("\nMatrix 2: ");
            mm2.Print();

            MyMatrix resM = mm1 + mm2;
            System.Console.WriteLine($"\nResult of summaryzing matrices: ");
            resM.Print();

            resM = mm1 - mm2;
            System.Console.WriteLine($"\nResult of substracting matrices: ");
            resM.Print();

            resM = mm1 * 2;
            System.Console.WriteLine($"\nResult of multiplying the first matrix by number: ");
            resM.Print();

            resM = 5 * mm2;
            System.Console.WriteLine($"\nResult of multiplying the second matrix by number: ");
            resM.Print();

            resM = mm1 / 5;
            System.Console.WriteLine($"\nResult of dividing the first matrix by number: ");
            resM.Print();

            resM = mm2 / 5;
            System.Console.WriteLine($"\nResult of dividing the second matrix by number: ");
            resM.Print();

            resM = mm1 * mm2;
            System.Console.WriteLine($"\nResult of multiplying matrices: "); 
            resM.Print();
        }

        public static void Task2()
        {
            // Demonstrating work for the second task
            // initialize variables
            // array of cars
            Car[] cars =
            {
                new Car("Toyota Camry", 2020, 210),
                new Car("BMW M5", 2018, 250),
                new Car("Audi A5", 2022, 240),
                new Car("Honda Civic", 2019, 200),
                new Car("Mercedec G-Class", 2021, 230)
            };

            System.Console.WriteLine("Array of cars: ");
            for (int i = 0; i < cars.Length; i++) 
            {
                System.Console.WriteLine(cars[i].ToString());
            }

            // Demonstrating sort by name
            System.Console.WriteLine("\n=== Sort by Name ===");
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.Name));
            for (int i = 0; i < cars.Length; i++) 
            {
                System.Console.WriteLine(cars[i].ToString());
            }

            // Demonstrating sort by year
            System.Console.WriteLine("\n=== Sort by Year ===");
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.Year));
            for (int i = 0;i < cars.Length; i++)
            {
                System.Console.WriteLine(cars[i].ToString());
            }

            // Demonstrating sort by speed
            System.Console.WriteLine("\n=== Sort by Speed ===");
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.Speed));
            for (int i = 0; i < cars.Length; i++) 
            {
                System.Console.WriteLine(cars[i].ToString());
            }

            // Demonstrating sort by year reverse
            System.Console.WriteLine("\n=== Sort by Year reverse ===");
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.Year));
            Array.Reverse(cars);
            for (int i = 0; i < cars.Length; i++) 
            {
                System.Console.WriteLine(cars[i].ToString());
            }
        }

        public static void Main(string[] args)
        {
            Task1();

            Task2();
        }
    }
}
