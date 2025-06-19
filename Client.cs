namespace spotiCLI;

public class Client
{
    private Person activeUser;
    /*private Album album;*/

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

    public void ShowLibrary()
    {
        activeUser.Library.ShowLibrary();
    }

    public void ShowPlaylists()
    {
        activeUser.Library.ShowPlaylists();
    }


    public void ShowAlbums()
    {
        activeUser.Library.ShowAlbums();
    }

}