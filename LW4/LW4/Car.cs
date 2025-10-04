using System.Collections;

namespace LW4
{
    public class Car
    {
        // auto-properties
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

        // constructor
        public Car(string name, int productionYear, int maxSpeed)
        {
            Name = name;
            ProductionYear = productionYear;
            MaxSpeed = maxSpeed;
        }

        // overridden ToString
        public override string ToString()
        {
            return $"{Name} ({ProductionYear}), Max Speed: {MaxSpeed} km/h";
        }
    }

    // comparer
    public class CarComparer : IComparer<Car>
    {
        public enum SortCriteria
        {
            Name,
            ProductionYear,
            MaxSpeed
        }

        private SortCriteria criteria;

        public CarComparer(SortCriteria criteria)
        {
            this.criteria = criteria;
        }

        // realize Compare method
        public int Compare(Car x, Car y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // compare based on selected criteria
            switch (criteria)
            {
                case SortCriteria.Name:
                    return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
                case SortCriteria.ProductionYear:
                    return x.ProductionYear.CompareTo(y.ProductionYear);
                case SortCriteria.MaxSpeed:
                    return x.MaxSpeed.CompareTo(y.MaxSpeed);
                default:
                    // should never reach
                    return 0; 
            }
        }
    }

    public class CarCatalog : IEnumerable<Car>
    {
        private Car[] cars;

        // constructor
        public CarCatalog(Car[] cars)
        {
            this.cars = cars ?? throw new ArgumentNullException(nameof(cars));
        }

        // forward iteration from first to last element
        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in cars)
            {
                yield return car;
            }
        }

        // explicit interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // reverse iteration from last to first element
        public IEnumerable<Car> GetReverseEnumerator()
        {
            for (int i = cars.Length - 1; i >= 0; i--)
            {
                yield return cars[i];
            }
        }

        // iteration with production year filter
        public IEnumerable<Car> GetCarsByProductionYear(int year)
        {
            foreach (var car in cars)
            {
                if (car.ProductionYear == year)
                {
                    yield return car;
                }
            }
        }

        // iteration with maximum speed filter
        public IEnumerable<Car> GetCarsByMaxSpeed(int maxSpeed)
        {
            foreach (var car in cars)
            {
                if (car.MaxSpeed >= maxSpeed)
                {
                    yield return car;
                }
            }
        }

        // addition method with speed range 
        public IEnumerable<Car> GetCarsByProductionYearRange(int startYear, int endYear)
        {
            foreach (var car in cars)
            {
                if (car.ProductionYear >= startYear && car.ProductionYear <= endYear)
                {
                    yield return car;
                }
            }
        }
    }
}