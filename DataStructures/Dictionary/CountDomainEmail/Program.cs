using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        string input = "user1@gmail.com,user2@hotmail.com,user3@gmail.com,user4@yahoo.com";
        string[] emails = input.Split(',');

        Dictionary<string, int> Count = new Dictionary<string, int>();

        foreach (string email in emails)
        {
            string[] parts = email.Split('@');
            string domain = parts[1]; // parts[0] = username

            if (Count.ContainsKey(domain))
            {
                Count[domain]++; // Count[domain] Key = Count[domain] + 1 Value
            }
            else
            {
                Count[domain] = 1;
            }
        }

        foreach (var result in Count)
        {
            Console.WriteLine($"Domain: {result.Key} = {result.Value}");
        }

        Console.ReadKey();

    }
}
