using System;
using System.Collections;
using System.Globalization;
using System.Runtime.ExceptionServices;

namespace LW4
{
    public class Car
    {
        // init prop
        public string Name { get; set; }
        public int Year { get; set; }
        public int Speed { get; set; }

        // constructor
        public Car(string name, int year, int speed)
        {
            Name = name;
            Year = year;
            Speed = speed;
        }

        public override string ToString()
        {
            return $"{Name} ({Year}), Max Speed: {Speed} km/h";
        }
    }

    public class CarComparer: IComparer<Car>
    {
        public enum SortBy
        {
            Name, Year, Speed
        }

        private SortBy sortCrit;

        public CarComparer(SortBy sort)
        {
            sortCrit = sort;
        }

        public int Compare(Car x, Car y) 
        { 
            if (x == null &&  y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            switch (sortCrit)
            {
                case SortBy.Name:
                    return string.Compare(x.Name, y.Name, StringComparison.Ordinal);

                case SortBy.Year:
                    return x.Year.CompareTo(y.Year);

                case SortBy.Speed:
                    return x.Speed.CompareTo(y.Speed);

                default:
                    return 0;
            }
        }
    }

    public class CarCatalog : IEnumerable<Car>
    {
        // initializing 
        private Car[] cars;

        // constructor
        public CarCatalog(Car[] cars)
        {
            this.cars = cars ?? throw new ArgumentNullException(nameof(cars));
        }

        // foreach from the first to last
        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in this.cars)
            {
                yield return car;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // reverse foreach
        public IEnumerable<Car> Reverse()
        {
            for (int i = this.cars.Length - 1; i >= 0; i--)
            {
                yield return this.cars[i];
            }
        }

        // sort by year
        public IEnumerable<Car> FilterByProductionYear(int year)
        {
            foreach (var car in this.cars)
            {
                if (car.Year == year)
                {
                    yield return car;
                }
            }
        }

        // sort by year diap
        public IEnumerable<Car> FilterByProductionYearRange(int startYear, int endYear)
        {
            foreach (var car in this.cars)
            {
                if (car.Year >=  startYear && car.Year <= endYear)
                {
                    yield return car;
                }
            }
        }

        // filter w speed
        public IEnumerable<Car> FilterByMaxSpeed (int minSpeed)
        {
            foreach(var car in this.cars)
            {
                if (car.Speed >=  minSpeed)
                {
                    yield return car;
                }
            }
        }

        // filter w speed range
        public IEnumerable<Car> FilterByMaxSpeedRange (int minSpeed, int maxSpeed)
        {
            foreach (var car in this.cars)
            {
                if (car.Speed >= minSpeed && car.Speed <= maxSpeed)
                {
                    yield return car;
                }
            }
        }
        
        // filter by name
        public IEnumerable<Car> FilterByName(string name)
        {
            foreach (var car in this.cars)
            {
                if (car.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    yield return car;
                }
            }
        }
    }
}
