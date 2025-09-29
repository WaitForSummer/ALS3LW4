using System;
using System.Collections.Generic;
using System.Globalization;

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
}
