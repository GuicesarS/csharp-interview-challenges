using Newtonsoft.Json.Linq;

class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Success");
            string json = await response.Content.ReadAsStringAsync();
            
            // Convertion JToken
            JToken token = JToken.Parse(json);

            /* if (city == "South Christy")
               Console.WriteLine($"{id} - {name} - {city}"); 
            */
            
            var filter = token
                .Where(x => x["address"]["city"].ToString() == "South Christy")
                .ToList();
            
            foreach (JToken user in filter)
            {
                string id = user["id"].ToString();
                string name = user["name"].ToString();
                string city = user["address"]["city"].ToString();

                Console.WriteLine($"Id:{id}, Name:{name}, City:{city}");
            }
        }
        else
        {   
            string errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Error");
            Console.WriteLine(errorMessage);
        }
    }
}
