namespace spotiCLI;

class jetbProgram
{
    static void Main(string[] args)
    {
        Person newUser = new Person();
        Client client = new Client(newUser);
        
        client.AddPlaylist();
        client.showPlaylists();


        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("=== SpotiCLI Menu ===");
            Console.WriteLine("1. Manage playlists");
            Console.WriteLine("2. Show all playlists");
            Console.WriteLine("3. View albums");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(" Manage playlists (coming soon)");
                    bool playlistmenu = true;
                    while (playlistmenu)
                    {
                        Console.WriteLine("=== SpotiCLI Playlist Manager ===");
                        Console.WriteLine("1. Show my library");
                        Console.WriteLine("2. Manage my playlists");
                        Console.WriteLine("3. Add a playlists");
                        Console.WriteLine("4. Delete a playlists");
                        Console.WriteLine("5. Back to main menu");
                        
                        String playlistChoise = Console.ReadLine();
                    }
                    break;
                
                

                case "2":
                    Console.WriteLine(" Showing all playlists (not implemented yet)");
                    break;

                case "3":
                    Console.WriteLine(" Viewing albums (not implemented yet)");
                    break;

                case "4":
                    Console.WriteLine("Exiting SpotiCLI...");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine(" X Invalid option. Try again.");
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