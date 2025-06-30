using System;
using System.Text.Json;

namespace InitialEx
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var url = "https://jsonplaceholder.typicode.com/posts";

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(url); // I'm making a request GET when I need all information
                var convertString = await response.Content.ReadAsStringAsync();

                // var responseString2 = await httpClient.GetStringAsync(url); //When I want to manipulate the response

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    var responseString = await response.Content.ReadAsStringAsync(); // Returning the response content as a string (Everything We get from the URL) 

                    // At this point, we can think like this: "What If que don't want the return as a string but as an object?"
                    // So I'll deserialize it and convert it according to my needs

                    var example = JsonSerializer.Deserialize<List<Example>>(responseString,  // Our variable will be empty because our response doesn't use caseInsensitive (id, title, body)
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); // (Id, Title, Body)
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }

            }
        }
    }
}