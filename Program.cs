namespace spotiCLI;

class jetbProgram
{
    static void Main(string[] args)
    {
        Person newUser = new Person();
        Client client = new Client(newUser);

        
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== SpotiCLI Main Menu ===");
            Console.WriteLine("1. Open library");
            Console.WriteLine("2. Explore Albums");
            Console.WriteLine("3. Friends List");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    client.ShowLibraryMenu();
                    break;

                case "2":
                    client.ShowAllAlbums();
                    break;

                case "3":
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                    break;
                case "99":
                    client.RemovePlaylistByTitle();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
        
    }
}