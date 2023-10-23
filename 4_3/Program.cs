using System;
using System.Collections;
using System.Collections.Generic;

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

public class CarCatalog
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public IEnumerable<Car> ForwardIteration()
    {
        foreach (var car in cars)
        {
            yield return car;
        }
    }

    public IEnumerable<Car> Reverse()
    {
        for (int i = cars.Count - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> FilterByProductionYear(int year)
    {
        foreach (Car car in cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> FilterByMaxSpeed(int maxSpeed)
    {
        foreach (Car car in cars)
        {
            if (car.MaxSpeed >= maxSpeed)
            {
                yield return car;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CarCatalog catalog = new CarCatalog();

        catalog.AddCar(new Car { Name = "Car 1", ProductionYear = 2010, MaxSpeed = 200 });
        catalog.AddCar(new Car { Name = "Car 2", ProductionYear = 2008, MaxSpeed = 180 });
        catalog.AddCar(new Car { Name = "Car 3", ProductionYear = 2008, MaxSpeed = 220 });
        catalog.AddCar(new Car { Name = "Car 4", ProductionYear = 2015, MaxSpeed = 300 });

        Console.WriteLine("Прямой проход:");
        foreach (Car car in catalog.ForwardIteration())
        {
            car.Print();
        }

        Console.WriteLine("\nОбратный проход:");
        foreach (Car car in catalog.Reverse())
        {
            car.Print();
        }

        Console.WriteLine("\nПроход с фильтром по году выпуска (2008):");
        foreach (Car car in catalog.FilterByProductionYear(2008))
        {
            car.Print();
        }

        Console.WriteLine("\nПроход с фильтром по максимальной скорости (220):");
        foreach (Car car in catalog.FilterByMaxSpeed(220))
        {
            car.Print();
        }
    }
}
