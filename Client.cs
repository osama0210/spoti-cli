namespace spotiCLI;

public class Client
{
    private Person activeUser;

    public Client(Person user)
    {
        activeUser = user;
    }
    
    public void AddPlaylist()
    {
        Console.WriteLine("Enter playlist name: ");
        String title = Console.ReadLine();
        
        Console.WriteLine("Make playlist public? (y/n):");
        string isPublicInput = Console.ReadLine();
        bool isPublic;
        if (isPublicInput == "y")
        {
            isPublic = true;
        }
        else
        {
            isPublic = false;
        }
        activeUser.Library.AddPlaylist(new Playlist(title, activeUser, isPublic));
    }
    
    public void ShowAllAlbums()
    {
        Console.WriteLine("Beschikbare albums:");
        for (int i = 0; i < albums.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {albums[i].albumName} ({albums[i].ReleaseDate})");
        }
    }

    public void AddAlbumToLibrary()
    {
        ShowAllAlbums();
        Console.WriteLine("Voer het nummer in van het album dat je aan je bibliotheek wilt toevoegen:");
        if (int.TryParse(Console.ReadLine(), out int keuze))
        {
            if (keuze > 0 && keuze <= albums.Count)
            {
                Album gekozenAlbum = albums[keuze - 1];
                // Check of gebruiker het album niet al heeft
                if (!activeUser.Library.Albums.Contains(gekozenAlbum))
                {
                    activeUser.Library.AddAlbum(gekozenAlbum);
                    Console.WriteLine($"{gekozenAlbum.albumName} is toegevoegd aan jouw bibliotheek!");
                }
                else
                {
                    Console.WriteLine("Dit album staat al in jouw bibliotheek.");
                }
            }
            else
            {
                Console.WriteLine("Ongeldige keuze.");
            }
        }
        else
        {
            Console.WriteLine("Voer een geldig getal in.");
        }
    }

    
    /*
    public void AddAlbum()
    {
        Console.WriteLine("Enter Album name: ");
        String albumName = Console.ReadLine();
        Console.WriteLine("Enter Artist name: ");
        string? artistName = Console.ReadLine();
        Console.WriteLine("Enter Song name: ");
        String songName = Console.ReadLine();
        Console.WriteLine("Enter Release Date: ");
        String ReleaseDate = Console.ReadLine();
        
        Console.WriteLine("Make album public? (y/n):");
        string isPublicInput = Console.ReadLine();
        bool isPublic;
        if (isPublicInput == "y")
        {
            isPublic = true;
        }
        else
        {
            isPublic = false;
        }
        activeUser.Library.AddAlbum(new Album("My First Album", new List<Song>(), "2025"));
    }
    */
    
    private List<Album> albums = new List<Album>
    {
        new Album { albumName = "SummerVibe", ReleaseDate = "2025" },
        new Album { albumName = "WinterChill", ReleaseDate = "2024" },
        new Album { albumName = "AutumnLeaves", ReleaseDate = "2023" }  
    };
    
    

    public void RemovePlaylistByTitle()
    {
        Console.WriteLine("Type playlist name to remove");
        string title = Console.ReadLine();
        activeUser.Library.RemovePlaylistByTitle(title);
    }
    
    public void ShowLibraryMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== My Library ===");
            Console.WriteLine("1. Show library content");
            Console.WriteLine("2. Show all playlists");
            Console.WriteLine("3. Manage a playlist");
            Console.WriteLine("4. Show all albums");
            Console.WriteLine("5. Add new playlist");
            Console.WriteLine("6. Delete a playlist");
            Console.WriteLine("7. Delete an album");
            Console.WriteLine("8. share playlistt");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    activeUser.Library.ShowLibrary();
                    break;

                case "2":
                    activeUser.Library.ShowPlaylists();
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    AddPlaylist();
                    break;

                case "6":
                    break;

                case "7":
                    break;
                
                case "8":
                    break;

                case "9":
                    isRunning = false;
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

        }
    }
}