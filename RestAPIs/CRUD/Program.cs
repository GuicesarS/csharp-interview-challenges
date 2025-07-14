namespace csharp_interview_challenges.RestAPIs.CRUD;
class Program
{
    public static async Task Main(string[] args)
    {
        string? option;
        do
        {
            Console.WriteLine("\n1 - List Post");
            Console.WriteLine("2 - Create Post");
            Console.WriteLine("3 - Update Post");
            Console.WriteLine("4 - Delete Post");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter: ");
            option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    await PostsHandler.GetPostDetails();
                    break;
                case "2":
                    await PostsHandler.CreatePost();
                    break;
                case "3":
                    await PostsHandler.EditPost();
                    break;
                case "4":
                    await PostsHandler.DeletePost();
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
           
        }
        while (option != "0");
    }
}
