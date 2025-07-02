using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    public static async Task Main(string[] args)
    {
        // Adding JSON parsing with JObject and JArray
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

        if (response.StatusCode == System.Net.HttpStatusCode.OK) // HTTP 200 = OK (successful response)
        {
            Console.WriteLine("Success");
            
            var json = await response.Content.ReadAsStringAsync();
            
            JArray users = JArray.Parse(json); // Parse raw JSON string into a JArray (array of users)
            foreach (JObject user in users)
            {
                string name = user["name"].ToString();
                string id = user["id"].ToString();
                string city = user["address"]["city"].ToString();

                Console.WriteLine($"\n Name: {name}, Id: {id}, City: {city}");
                
                // Console.WriteLine(name.GetType()); // Check the runtime type of 'name' (System.String)
            }
        }
    }
}

