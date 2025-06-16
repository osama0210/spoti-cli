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
            Console.WriteLine("1. Show my library");
            Console.WriteLine("2. Add a playlist");
            Console.WriteLine("3. View albums");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    client.ShowLibrary();
                    break;

                case "2":
                    client.AddPlaylist();
                    break;

                case "3":
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
            
        
        
        // Hier maak ik een nieuwe SongCollection aan om liedjes op te slaan en te beheren.
        SongCollection collection = new SongCollection();
        


    }
}