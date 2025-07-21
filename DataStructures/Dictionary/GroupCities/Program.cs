// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        List<string> cities = new List<string>
        {
           "Lisbon", "London", "Liverpool", "Madrid", "Milan", "Munich", "Porto", "Paris"
        };

        Dictionary<char, List<string>> citiesWithFirstLetter = new Dictionary<char, List<string>>();

        foreach (string city in cities)
        {
            char firstLetter = char.ToUpper(city[0]);
            if (!citiesWithFirstLetter.ContainsKey(firstLetter))
            {
                citiesWithFirstLetter[firstLetter] = new List<string>();
            }
            citiesWithFirstLetter[firstLetter].Add(city);
        }

        foreach (var result in citiesWithFirstLetter)
        {
            Console.WriteLine($" '{result.Key}' : {string.Join(",", result.Value)}");
        }

        Console.ReadKey();

    }
}