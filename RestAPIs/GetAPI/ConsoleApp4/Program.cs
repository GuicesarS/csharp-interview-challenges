/*
    Exercise 2 – GET + Grouping with LINQ
    Goal: Count how many posts each user has made.

    Endpoint: https://jsonplaceholder.typicode.com/posts

    Task:

    Deserialize into a list of posts.

    Group by userId using LINQ.

    Print each userId and the total number of posts they made.
*/
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using UserClass;

class Program
{
    public static async Task Main(string[] args)
    {
        var url = "https://jsonplaceholder.typicode.com/posts";

        using HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<User>>(json, options);

            var filterUsers = users
            .GroupBy(x => x.UserId)
            .ToList();

            foreach (var user in filterUsers)
            {
                Console.WriteLine($"User: {user.Key} / Posts:{user.Count()}");
            }
            
        }
    }
}