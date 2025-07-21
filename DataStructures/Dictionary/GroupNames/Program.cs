using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<string> names = new List<string> { "Ana", "Amanda", "Bruno", "Beatriz", "Carlos", "Guilherme" };

        Dictionary<char, List<string>> namesByFirstLetter = new Dictionary<char, List<string>>();

        foreach (string name in names)
        {
            char firstLetter = char.ToUpper(name[0]);
            if (!namesByFirstLetter.ContainsKey(firstLetter))
            {
                namesByFirstLetter[firstLetter] = new List<string>();
            }
            namesByFirstLetter[firstLetter].Add(name);
        }

        foreach (var entry in namesByFirstLetter)
        {
            Console.WriteLine($"'{entry.Key}': {string.Join(", ", entry.Value)}");
        }

        Console.ReadKey();

        // Classic grouping pattern:
        //  Check if the first letter already exists as a key in the dictionary.
        //    - If it doesn't exist:
        //         ➜ Create a new empty list.
        //         ➜ Add the current name to that list.
        //    - If it does exist:
        //         ➜ Simply add the name to the existing list.

        //  Practical example:
        //    Ana → 'A' not found → create new list → add Ana.
        //    Amanda → 'A' found → add Amanda to the same list.
        //    Bruno → 'B' not found → create new list → add Bruno.


    }
}