using System;
using System.Net.Http.Json;
using System.Text.Json;
using ConsoleApp1;

class Program
{
    public static async Task Main(string[] args)
    {
        var url = "https://jsonplaceholder.typicode.com/posts";
        var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        using (var httpClient = new HttpClient())
        {
            //Example 1
            var createPerson = new Person()
            {
                Title = "John Doe",
                Body = "Title for John Doe",
                UserId = 1
            };
            var response = await httpClient.PostAsJsonAsync(url, createPerson);
            if (response.IsSuccessStatusCode)
            {
                var person = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Person created: {person}");
            }
            var people = JsonSerializer.Deserialize<List<Person>>(await httpClient.GetStringAsync(url), jsonSerializerOptions);
            
            Console.ReadKey();
        }
    }
}