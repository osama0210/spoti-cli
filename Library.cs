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
        Console.WriteLine("Your Playlists:");
        foreach (var playlist in playlists)
        {
            Console.WriteLine($"= {playlist.Title}");
        }
        
        Console.WriteLine("\nYour Albums:");
        foreach (var album in albums)
        {
            Console.WriteLine($"- {album.Title}");
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

    public void AddAlbum(Album album)
    {
        albums.Add(album);
    }

    public void RemoveAlbum(Album album)
    {
        albums.Remove(album);
    }
}