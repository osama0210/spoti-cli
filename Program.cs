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
            Console.WriteLine("2. Add a playlist");
            Console.WriteLine("3. View my albums");
            Console.WriteLine("4. View all albums");
            Console.WriteLine("5. Add album to my library");
            Console.WriteLine("6. Exit");
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
                    client.ShowAlbums();
                    break;
                case "4":
                    client.ShowAllAlbums();
                    break;
                
                case "5":
                    client.AddAlbumToLibrary();
                    break;
                case "6":
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