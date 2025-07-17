using System;
using System.Collections.Generic;

class Program
{ 
    public static void Main(string[] args)
    {
        List<string> listA = new List<string> { "apple", "banana", "orange" };
        List<string> listB = new List<string> { "banana", "kiwi", "orange", "grape" };

        HashSet<string> setA = new HashSet<string>(listA);
        HashSet<string> setB = new HashSet<string>(listB);

        setA.IntersectWith(setB);
        // setA now contains only the common elements between listA and listB

        Console.WriteLine("Common elements:");
        foreach (string item in setA)
        {
            Console.Write($"{item} ");
        }

        Console.ReadKey();
    }
}