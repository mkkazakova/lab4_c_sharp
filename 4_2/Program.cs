using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public void Print()
    {
        Console.WriteLine($"Name: {Name}   Год выпуска: {ProductionYear}   Max v: {MaxSpeed}");
    }
}

public class CarComparer : IComparer<Car>
{
    private string _sortBy; // параметр, по которому сортируем

    public CarComparer(string sortBy)
    {
        _sortBy = sortBy;
    }

    public int Compare(Car x, Car y)
    {
        switch (_sortBy)
        {
            case "Name":
                return string.Compare(x.Name, y.Name);
            case "ProductionYear":
                return x.ProductionYear.CompareTo(y.ProductionYear);
            case "MaxSpeed":
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            default:
                throw new ArgumentException("Invalid sort criteria");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Car[] cars = new Car[]
        {
            new Car{ Name = "Toyota  ", ProductionYear = 2020, MaxSpeed = 200 },
            new Car{ Name = "Mercedes", ProductionYear = 2018, MaxSpeed = 220 },
            new Car{ Name = "Ford    ", ProductionYear = 2019, MaxSpeed = 180 }
        };

        // Сортировка по названию
        Array.Sort(cars, new CarComparer("Name"));
        Console.WriteLine("Сортировка по названию:");
        foreach (Car car in cars)
        {
            car.Print();  
        }

        // Сортировка по году выпуска
        Array.Sort(cars, new CarComparer("ProductionYear"));
        Console.WriteLine("Сортировка по году выпуска:");
        foreach (Car car in cars)
        {
            car.Print();
        }

        // Сортировка по максимальной скорости
        Array.Sort(cars, new CarComparer("MaxSpeed"));
        Console.WriteLine("Сортировка по максимальной скорости:");
        foreach (Car car in cars)
        {
            car.Print();
            // Console.WriteLine($"Name: {car.Name}   Год выпуска: {car.ProductionYear}   Max v: {car.MaxSpeed}");
        }
    }
}
