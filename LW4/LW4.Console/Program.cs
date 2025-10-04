namespace LW4.Console
{
    public class Program
    {
        public static void Task1()
        {
            System.Console.WriteLine("=== Task 1 ===\n");

            // get matrix1 from user
            System.Console.WriteLine("Enter number of rows for the first matrix: ");
            int rows = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Enter number of columns for the first matrix: ");
            int columns = int.Parse(System.Console.ReadLine());

            // create first matrix
            MyMatrix matrix1 = new MyMatrix(rows, columns);

            // get matrix2 from user
            System.Console.WriteLine("\nEnter number of rows for the second matrix: ");
            rows = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Enter number of columns for the second matrix: ");
            columns = int.Parse(System.Console.ReadLine());

            // create matrix2
            MyMatrix matrix2 = new MyMatrix(rows, columns);

            // display matrices
            System.Console.WriteLine("\nMatrix 1:");
            matrix1.Print();

            System.Console.WriteLine("\nMatrix 2:");
            matrix2.Print();

            // matrix addition
            try
            {
                MyMatrix result = matrix1 + matrix2;
                System.Console.WriteLine("\nMatrix1 + Matrix2:");
                result.Print();
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"\nAddition error: {ex.Message}");
            }

            // matrix subtraction
            try
            {
                MyMatrix result = matrix1 - matrix2;
                System.Console.WriteLine("\nMatrix1 - Matrix2:");
                result.Print();
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"\nSubtraction error: {ex.Message}");
            }

            // matrix multiplication
            try
            {
                MyMatrix result = matrix1 * matrix2;
                System.Console.WriteLine("\nMatrix1 * Matrix2:");
                result.Print();
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"\nMultiplication error: {ex.Message}");
            }

            // scalar operations
            MyMatrix scalarResult = matrix1 * 2;
            System.Console.WriteLine("\nMatrix1 * 2:");
            scalarResult.Print();

            MyMatrix divisionResult = matrix1 / 3;
            System.Console.WriteLine("\nMatrix1 / 3:");
            divisionResult.Print();
        }

        public static void Task2()
        {
            System.Console.WriteLine("\n=== Task 2: Car Sorting with IComparer ===\n");

            // create car array
            Car[] cars = {
                new Car("Toyota Camry", 2020, 210),
                new Car("BMW M5", 2018, 250),
                new Car("Audi A5", 2022, 240),
                new Car("Honda Civic", 2019, 200),
                new Car("Mercedes G-Class", 2021, 230)
            };

            // display array
            System.Console.WriteLine("Original array of cars:");
            foreach (var car in cars)
            {
                System.Console.WriteLine(car);
            }

            // demonstrate sorting by different criteria

            System.Console.WriteLine("\n--- Sorted by Name ---");
            Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.Name));
            foreach (var car in cars)
            {
                System.Console.WriteLine(car);
            }

            System.Console.WriteLine("\n--- Sorted by Production Year ---");
            Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ProductionYear));
            foreach (var car in cars)
            {
                System.Console.WriteLine(car);
            }

            System.Console.WriteLine("\n--- Sorted by Max Speed ---");
            Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.MaxSpeed));
            foreach (var car in cars)
            {
                System.Console.WriteLine(car);
            }

            // Demonstrate reverse sorting
            System.Console.WriteLine("\n--- Sorted by Production Year (Descending) ---");
            Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ProductionYear));
            Array.Reverse(cars);
            foreach (var car in cars)
            {
                System.Console.WriteLine(car);
            }
        }

        public static void Task3()
        {
            System.Console.WriteLine("\n=== Task 3: CarCatalog with Iterators ===\n");

            Car[] cars = {
                new Car("Toyota Camry", 2020, 210),
                new Car("BMW M5", 2018, 250),
                new Car("Audi A5", 2022, 240),
                new Car("Honda Civic", 2019, 200),
                new Car("Mercedes G-Class", 2021, 230),
                new Car("Ford Focus", 2020, 190)
            };

            // create car catalog
            CarCatalog catalog = new CarCatalog(cars);

            // demonstrating
            // standard IEnumerable
            System.Console.WriteLine("1. Forward iteration:");
            foreach (var car in catalog)
            {
                System.Console.WriteLine($"  {car}");
            }

            // reverse iteration
            System.Console.WriteLine("\n2. Reverse iteration:");
            foreach (var car in catalog.GetReverseEnumerator())
            {
                System.Console.WriteLine($"  {car}");
            }

            // filtered iteration by production year
            System.Console.WriteLine("\n3. Cars from year 2020:");
            foreach (var car in catalog.GetCarsByProductionYear(2020))
            {
                System.Console.WriteLine($"  {car}");
            }

            // filtered iteration by maximum speed
            System.Console.WriteLine("\n4. Cars with max speed >= 230 km/h:");
            foreach (var car in catalog.GetCarsByMaxSpeed(230))
            {
                System.Console.WriteLine($"  {car}");
            }

            // additional demonstration
            System.Console.WriteLine("\n5. Cars from 2019 to 2021:");
            foreach (var car in catalog.GetCarsByProductionYearRange(2019, 2021))
            {
                System.Console.WriteLine($"  {car}");
            }
        }

        public static void Main(string[] args)
        {
            Task1();

            System.Console.WriteLine("\nPress any key to continue to Task 2...");
            System.Console.ReadKey();
            System.Console.Clear();

            Task2();

            System.Console.WriteLine("\nPress any key to continue to Task 3...");
            System.Console.ReadKey();
            System.Console.Clear();

            Task3();

            System.Console.WriteLine("\nPress any key to exit...");
            System.Console.ReadKey();
        }
    }
}