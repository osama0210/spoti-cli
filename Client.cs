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
            Console.WriteLine($"{i + 1}. {albums[i].Title} ({albums[i].ReleaseDate})");
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
                    Console.WriteLine($"{gekozenAlbum.Title} is toegevoegd aan jouw bibliotheek!");
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
    new Album("SummerVibe", new Artist("Jane Smith"), new DateTime(2023, 6, 1),
    new List<Song>() // Hier kun je een lijst van songs toevoegen hard coded of leeg laten
    ),
    new Album("WinterChill", new Artist("Unknown"), new DateTime(2023, 12, 1),
    new List<Song>()
    ),
    new Album("AutumnLeaves", new Artist("John Doe"), new DateTime(2023, 10, 1),
        new List<Song>()
    )
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

    // Methode om een nummer af te spelen vanuit een playlist via console
    public void PlaySongFromPlaylist()
    {
        Console.WriteLine("Voer de naam in van de playlist:");
        string playlistName = Console.ReadLine();

        var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist niet gevonden.");
            return;
        }

        Console.WriteLine("Voer de titel in van het nummer dat je wilt afspelen:");
        string songTitle = Console.ReadLine();

        playlist.PlaySong(songTitle);
    }

    // Methode om een nummer te pauzeren vanuit een playlist via console
    public void PauseSongFromPlaylist()
    {
        Console.WriteLine("Voer de naam in van de playlist:");
        string playlistName = Console.ReadLine();

        var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist niet gevonden.");
            return;
        }

        playlist.PauseSong();
    }

    // Methode om een nummer te hervatten vanuit een playlist via console
    public void ResumeSongFromPlaylist()
    {
        Console.WriteLine("Voer de naam in van de playlist:");
        string playlistName = Console.ReadLine();

        var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist niet gevonden.");
            return;
        }

        playlist.ResumeSong();
    }

    // Methode om een nummer toe te voegen aan een playlist via console
    public void AddSongToPlaylist()
    {
        // Vraag de gebruiker om de naam van de playlist
        Console.WriteLine("Voer de naam in van de playlist:");
        string playlistName = Console.ReadLine();

        // Zoek de playlist op basis van de naam
        var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist niet gevonden.");
            return;
        }

        // Toon alle beschikbare nummers zodat gebruiker kan kiezen
        Console.WriteLine("Beschikbare nummers:");
        foreach (var song in activeUser.Library.AllSongs)
        {
            Console.WriteLine($"- {song.SongName}");
        }

        // Vraag de gebruiker om de naam van het nummer dat toegevoegd moet worden
        Console.WriteLine("Voer de naam in van het nummer dat je wilt toevoegen:");
        string songName = Console.ReadLine();

        // Zoek het nummer in de volledige songlijst (bijv. in Library of SongCollection)
        var songToAdd = activeUser.Library.AllSongs.FirstOrDefault(s => s.SongName == songName);
        if (songToAdd == null)
        {
            Console.WriteLine("Nummer niet gevonden.");
            return;
        }

        // Voeg het nummer toe aan de playlist
        playlist.AddSong(songToAdd);
        Console.WriteLine($"'{songName}' is toegevoegd aan playlist '{playlistName}'.");
    }

    // Methode om een nummer te verwijderen uit een playlist via console
    public void RemoveSongFromPlaylist()
    {
        Console.WriteLine("Voer de naam in van de playlist:");
        string playlistName = Console.ReadLine();

        var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist niet gevonden.");
            return;
        }

        Console.WriteLine("Voer de naam in van het nummer dat je wilt verwijderen:");
        string songName = Console.ReadLine();

        var song = playlist.songs.FirstOrDefault(s => s.SongName == songName);
        if (song == null)
        {
            Console.WriteLine("Nummer niet gevonden in de playlist.");
            return;
        }

        playlist.RemoveSong(song);
        Console.WriteLine($"'{songName}' is verwijderd uit playlist '{playlistName}'.");
    }

}