namespace spotiCLI;

public abstract class SongCollection
{
    private string title;
    public List<Song> songs = new List<Song>();

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public SongCollection()
    {
        songs = new List<Song>();
    }

    // Speelt alle nummers af (simulatie)
    public void PlayAll()
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("Er staan geen nummers in deze collectie.");
            return;
        }
        Console.WriteLine($"Alle nummers in '{Title}' worden afgespeeld:");
        /*foreach (var song in songs)
        {
            Console.WriteLine($"Afspelen: {song.Title} van {song.Artist}");
        }*/
    }

    // Shufflet de nummers in de collectie
    public void Shuffle()
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("Er staan geen nummers in deze collectie.");
            return;
        }
        var rnd = new Random();
        songs = songs.OrderBy(x => rnd.Next()).ToList();
        Console.WriteLine($"De nummers in '{Title}' zijn geschud.");
    }

    // Toont alle nummers in de collectie
    public void ShowSongs()
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("Er staan geen nummers in deze collectie.");
            return;
        }
        Console.WriteLine($"Nummers in '{Title}':");
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