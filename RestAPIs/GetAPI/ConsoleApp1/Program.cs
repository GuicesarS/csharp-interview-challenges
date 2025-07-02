namespace ConsoleApp1;
class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();
        var responseClient = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
        if (responseClient.IsSuccessStatusCode)
        {
            Console.WriteLine("Success");
            
            string json = await responseClient.Content.ReadAsStringAsync();
            Console.WriteLine(json);
        }
        else
        {
            string errorMessage = await responseClient.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {responseClient.StatusCode}");
            Console.WriteLine(errorMessage);
        }
    }
}