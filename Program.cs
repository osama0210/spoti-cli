namespace spotiCLI;

class jetbProgram
{
    static void Main(string[] args)
    {
        Person newUser = new Person();
        Client client = new Client(newUser);
        Artist artist = new Artist();
        //Album album = new Album();
        Library library = new Library();
        //string[] artists = { "T" };
        //Album[] albums = { ("T","A","B","D") };
        //artist.artistlist.AddRange(artists);
        //album.albumsList.AddRange(albums);
        //library.Albums.AddRange(albums);


        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== SpotiCLI Main Menu ===");
            Console.WriteLine("1. Show my library");
            Console.WriteLine("2. Explore Albums");
            Console.WriteLine("3. Friends List");
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