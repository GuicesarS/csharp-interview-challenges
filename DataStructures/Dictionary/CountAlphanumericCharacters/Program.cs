using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {

        string input = "A1!B2@A3#";

        Dictionary<char,int> Count = new Dictionary<char, int>();

        foreach (char character in input)
        {
            if (char.IsLetterOrDigit(character)) // Verify if the character is alphanumeric
            {
                if (Count.ContainsKey(character))
                {
                    Count[character]++;
                }
                else
                {
                    Count[character] = 1;
                }
            }
            else
            {
                Console.WriteLine($"Character '{character}' is not alphanumeric and will be ignored.");
            }
        }

        foreach (var result in Count)
        {
            Console.WriteLine($"\nCharacter: {result.Key}, Count: {result.Value}");
        }

        Console.ReadKey();


    }
}