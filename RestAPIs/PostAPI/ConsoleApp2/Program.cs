using PostClass;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
namespace ConsoleApp2;
class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://jsonplaceholder.typicode.com/posts";
        using (HttpClient client = new HttpClient())
        {
            var post = new PostRequest
            {
                UserId = 10,
                Title = "Testing Post",
                Body = "This is a test"
            };
                   
            var response = await client.PostAsJsonAsync(url, post); //When you make a post, the object is automatically converted to JSON. So you'll need to deserealize the response if you want manipulate it.
            if (response.IsSuccessStatusCode)
            {
                // string jsonResponse = await response.Content.ReadAsStringAsync();
                // Console.WriteLine($"Post Created : {jsonResponse}"); // Print on the screen

                var createdPost = await response.Content.ReadFromJsonAsync<PostRequest>();
                Console.WriteLine($"Post Created: Title = {createdPost.Title} Body: {createdPost.Body}, UserId = {createdPost.UserId}");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode} ");
                Console.WriteLine($"Error: {error} ");
            }

        }
    }
}