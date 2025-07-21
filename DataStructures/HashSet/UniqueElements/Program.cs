using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> listA = new List<int> { 1, 2, 3, 4, 5 };
        List<int> listB = new List<int> { 4, 5, 6, 7, 8 };

        HashSet<int> setA = new HashSet<int>(listA);
        HashSet<int> setB = new HashSet<int>(listB);

        setA.ExceptWith(setB);

        foreach (var sets in setA)
        {
            Console.Write(sets);
        }
          
        Console.ReadKey();

    }
}