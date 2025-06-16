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
            Console.WriteLine("99. delete playlist");
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
                case "99":
                    client.RemovePlaylistByTitle();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
            
        
        
        // Hier maak ik een nieuwe SongCollection aan om liedjes op te slaan en te beheren.
        SongCollection collection = new SongCollection();

        
        // Hier voeg ik een nieuw liedje toe aan de collectie met titel, artiest en album en lyrics{optioneel}.
        Song song = new Song();
        Console.WriteLine("Currently playing Song is: ");
        song.title = "Gods plan";
        song.artist = "Drake";
        song.album = "2020 vibes";
        song.lyrics =
            "She say, “Do you love me?” I tell her, “Only partly”\nI only love my bed and my mama, I'm sorry\n";
        
        
        
        // Laat alle liedjes in de collectie zien in de console, inclusief titel, artiest, album en lyrics.
        collection.ShowSongs();


    }
}