namespace spotiCLI;

public class SongCollection
{
    private List<Song> songs;

    public SongCollection()
    {
        songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        if (songs.Any(s => s.Title.Equals(song.Title, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Error: This song is already in the collection.");
            return;
        }

        songs.Add(song);
        Console.WriteLine($"'{song.Title}' added to the collection.");
    }

    public void RemoveSong(string title)
    {
        var songToRemove = songs.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (songToRemove != null)
        {
            songs.Remove(songToRemove);
            Console.WriteLine($"'{title}' is verwijderdt van de album.");
        }
        else
        {
            Console.WriteLine("Error: de song zit niet in de album.");
        }
    }

    public void ShowAllSongs()
    {
        if (!songs.Any())
        {
            Console.WriteLine("Geen songs in de album.");
            return;
        }

        Console.WriteLine("Songs in de album:");
        foreach (var song in songs)
        {
            Console.WriteLine(song.ToString());
        }
    }

    public List<Song> GetAllSongs()
    {
        return songs;
    }
}