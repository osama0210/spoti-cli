namespace spotiCLI;

public class Library
{  
    private List<Artist> artistlist = new List<Artist>
    {
        new Artist("")
    };
    public String [] artistlist2 = { "Drake" };
    private List<Playlist> playlists = new List<Playlist>();
    private List<Album> albums = new List<Album>();
    private List<Song> likedSongs = new List<Song>();

    public List<Playlist> Playlists
    {
        get { return playlists; }
        set { playlists = value; }
    }
    
    public List<Album> Albums
    {
        get { return albums; }
        set { albums = value; }
    }

    public List<Song> LikedSongs { get; set; }

    // Property om alle songs uit albums en playlists te combineren
    public List<Song> AllSongs
    {
        get
        {
            // Voeg een fallback lijst toe met voorbeeldnummers als albums en playlists leeg zijn
            var songsFromAlbums = Albums.SelectMany(album => album.Songs);
            var songsFromPlaylists = Playlists.SelectMany(playlist => playlist.songs);
            var combinedSongs = songsFromAlbums.Concat(songsFromPlaylists).Distinct().ToList();

            if (combinedSongs.Count == 0)
            {
                // Voeg voorbeeldnummers toe
                combinedSongs = Song.Songs10();
            }

            return combinedSongs;
        }
    }

    public void ShowLibrary()
    {
        Console.WriteLine("\nYour Playlists:");
        if (playlists.Count == 0)
        {
            Console.WriteLine("There are no playlists.");
        }
        else
        {
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"{playlist.Title}");
            }
        }
        
        Console.WriteLine("\nYour Albums:");
        if (albums.Count == 0)
        {
            Console.WriteLine("There are not albums");
        }
        else
        {
            foreach (var album in albums)
            {
                Console.WriteLine($"-{album.Title} {album.ReleaseDate}");
            }
        }
    }
    
    public void ShowPlaylists()
    {
        foreach (var playlist in playlists)
        {
            Console.WriteLine(playlist);
        }
    }
    public void AddPlaylist(Playlist playlist)
    {
        playlists.Add(playlist);
    }
    
    public void AddAlbum(Album album)
    {
        albums.Add(album);
    }

    public void RemovePlaylistByTitle (String title)
    {
        Playlist playlistRemove = playlists.FirstOrDefault(p => p.Title == title);
        if (playlistRemove != null)
        {
            playlists.Remove(playlistRemove);
            Console.WriteLine($"Playlist {title} has been removed");
        }
        else
        {
            Console.WriteLine($"there is no playlist with the name {title}");
        }
    }
    
    public void ShowAlbums()
    {
        Console.WriteLine("Albums:");
        if (albums.Count == 0)
        {
            Console.WriteLine("No albums found.");
        }
        else
        {
            foreach (var album in albums)
            {
                Console.WriteLine($"{album.Title} ({album.ReleaseDate})");
            }
        }
    }

}
