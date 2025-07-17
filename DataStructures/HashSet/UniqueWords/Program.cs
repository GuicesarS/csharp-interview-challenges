using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        string text = "this is a test this is only a test";
        string[] parts = text.Split(' ');

        HashSet<string> uniqueWords = new HashSet<string>(parts);
        foreach (string word in uniqueWords)
        {
            //if (!uniqueWords.Contains(word))
            //{                                     Just to show how to use HashSet - We don't need this check
            //    uniqueWords.Add(word);
            //}

            Console.Write($"{word} ");
        }

        Console.ReadKey();
    }
}