using System;
using PostClass;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response is OK (200)");
                var json = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(json);
                
                var jsonSerializerOptions = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
                
                // Deserialize json and convert it to List 
                var post = JsonSerializer.Deserialize<List<Post>>(json, jsonSerializerOptions); 
                
                var filterPost = post.Where(x => x.UserId == 1);
                
                foreach (var item in filterPost)
                {
                    Console.WriteLine($"UserId = {item.UserId}, Id = {item.Id}, Title = {item.Title}");
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}