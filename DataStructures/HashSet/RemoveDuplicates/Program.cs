using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example list with duplicates
        List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5 };

        // Create a HashSet from the List to remove duplicates
        HashSet<int> uniqueNumbers = new HashSet<int>(numbers);

        foreach (int number in uniqueNumbers)
        {
            Console.Write($"{number} ");
        }

        Console.ReadKey();

    }
}