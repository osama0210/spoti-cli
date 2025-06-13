namespace spotiCLI;

public class Library
{
    private List<Playlist> playlists = new List<Playlist>();
    private List<Album> albums = new List<Album>();
    private List<Song> likedSongs = new List<Song>();

    public List<Playlist> Playlists
    {
        get { return playlists; }
        set { playlists = value; }
    }

    public List<Album> Albums { get; set; }
    public List<Song> LikedSongs { get; set; }

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
                Console.WriteLine($"- {album.Title}");
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

    public void RemovePlaylist(Playlist playlist)
    {
        playlists.Remove(playlist);
    }
}