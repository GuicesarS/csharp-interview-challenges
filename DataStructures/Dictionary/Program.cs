using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int,string> cars = new Dictionary<int,string>();
       
        cars.Add(10, "Volvo");
        cars.Add(20, "BMW");
        cars.Add(30, "Ford");
        cars.Add(40, "Mazda");
        cars.Add(50, "Fiat");

        Console.WriteLine($"Cars Dictionary Count: {cars.Count}");
        Console.WriteLine();
       
        // Display all cars
        foreach (var car in cars)
        {
            Console.WriteLine($"Id: {car.Key} Name: {car.Value}");
        }

        if (cars.ContainsKey(20))
        {
            Console.WriteLine("\nCar with Id 20 exists.");
        }
        else
        {
            Console.WriteLine("Car with Id 20 does not exist.");
        }
       
        if(cars.TryGetValue(40, out string carName))
        {
            Console.WriteLine($"\nCar with Id 40: {carName}");
        }
        else
        {
            Console.WriteLine("Car with Id 40 does not exist.");
        }
        Console.ReadKey();

    }
}