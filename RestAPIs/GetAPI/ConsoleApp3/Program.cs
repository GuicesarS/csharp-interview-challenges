/*
    Exercise 1 – GET + LINQ Filter
    Goal: Fetch users and display only those who live in a specific city.

    Endpoint: https://jsonplaceholder.typicode.com/users

    Task:

    Deserialize the JSON into a list of user objects.

    Filter users where address.city == "South Christy".

    Print their name, email, and city.

*/

using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using UserNamespace;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://jsonplaceholder.typicode.com/users";

        using HttpClient client = new HttpClient();
        {
            var response = await client.GetAsync(url); // Get all response in URL

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync(); // Read content as String

                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var users = JsonSerializer.Deserialize<List<Users>>(json, options); 

                var filterUser = users
                .Where(x => x.Address.City == "South Christy" && x.Address != null)
                .ToList();

                foreach (var data in filterUser)
                {
                    Console.WriteLine($"Name: {data.Name}, Email: {data.Email}, City: {data.Address.City}"); 
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
           
        }
    }
}