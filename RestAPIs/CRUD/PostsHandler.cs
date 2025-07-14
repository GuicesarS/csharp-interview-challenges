using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;


namespace csharp_interview_challenges.RestAPIs.CRUD;

public class PostsHandler
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;

    public PostsHandler() { }

    public PostsHandler(int userId, int id, string title, string body)
    {
        UserId = userId;
        Id = id;
        Title = title;
        Body = body;
    }

    public static async Task GetPostDetails()
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var postsList = System.Text.Json.JsonSerializer.Deserialize<List<PostsHandler>>(json, options);

            if (postsList != null)
            {
                foreach (var post in postsList.Take(5))
                {
                    Console.WriteLine($"\nUserId: {post.UserId}");
                    Console.WriteLine($"Id: {post.Id}");
                    Console.WriteLine($"Title: {post.Title}");
                    Console.WriteLine($"Body: {post.Body}");
                }
            }
            else
            {
                Console.WriteLine("No posts found.");
            }
        }
        else
        {
            Console.WriteLine($"Error fetching posts: {response.StatusCode}");
        }
    } //Get

    public static async Task CreatePost()
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        Console.WriteLine("Enter UserId:");
        int userId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Id:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Body:");
        string body = Console.ReadLine();

        var post = new PostsHandler(userId, id, title, body);
        var response = await client.PostAsJsonAsync(url, post);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Post created successfully.");
            var createdPost = await response.Content.ReadFromJsonAsync<PostsHandler>();
            // We are using ReadFromJsonAsync<T>() to automatically deserialize the JSON response
            // into a C# object of type T (e.g., Post, User, etc).

            Console.WriteLine($"\nUserId: {createdPost.UserId}");
            Console.WriteLine($"Id: {createdPost.Id}");
            Console.WriteLine($"Title: {createdPost.Title}");
            Console.WriteLine($"Body: {createdPost.Body}");

            Console.ReadKey();
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode}");
            Console.WriteLine($"Error: {error}");
        }

    } //Post

    public static async Task EditPost() //Put
    {
        string BaseUrl = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        Console.WriteLine("Enter the Id of the post you want to update:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new Title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter new Body:");
        string body = Console.ReadLine();

        Console.WriteLine("Enter new UserId:");
        int userId = int.Parse(Console.ReadLine());

        var updatedPost = new PostsHandler(userId, id, title, body);

        string urlWithId = $"{BaseUrl}/{id}";
        var response = await client.PutAsJsonAsync(urlWithId, updatedPost);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Post updated successfully.");
            var post = await response.Content.ReadFromJsonAsync<PostsHandler>();

            Console.WriteLine($"\nUserId: {post.UserId}");
            Console.WriteLine($"Id: {post.Id}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"Body: {post.Body}");
        }
        else
        {
            Console.WriteLine($"Error updating post: {response.StatusCode}");
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {error}");
        }
    }

    public static async Task DeletePost() //Delete
    {
        string BaseUrl = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        Console.WriteLine("Enter the Id of the post you want to delete:");
        int id = int.Parse(Console.ReadLine());

        string urlWithId = $"{BaseUrl}/{id}";
        var response = await client.DeleteAsync(urlWithId);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Post deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {error}");
        }
    }
}
