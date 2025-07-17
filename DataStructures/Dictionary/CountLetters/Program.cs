using System;
using System.Collections.Generic;

class Program
{
       public static void Main(string[] args)
    {

        string input = "Banana";
        input = input.ToLower();

        Dictionary<char, int> Count = new Dictionary<char, int>();

        foreach (char letter in input)
        {
            if (Count.ContainsKey(letter))
            {
                Count[letter]++;
            }
            else
            {
                Count[letter] = 1;
            }
        }

        foreach (var result in Count)
        {
            Console.WriteLine($"Letter: {result.Key}, Count: {result.Value}");
        }

    }
}