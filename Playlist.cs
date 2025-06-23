namespace spotiCLI;

public class Playlist : SongCollection
{
    public Person owner;
    private bool isPublic = true;

    public bool IsPublic
    {
        get { return isPublic; }
        set { isPublic = value; }
    }

    public Playlist(string title, Person owner, bool isPublic = true)
    {
        this.Title = title;
        this.owner = owner;
        this.IsPublic = isPublic;
    }

    // Voegt een Song toe aan de playlist
    public void AddSong(Song song)
    {
        if (songs.Any(s => s.Title.Equals(song.Title, StringComparison.OrdinalIgnoreCase)
                        && s.Artist.Equals(song.Artist, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Error: Dit nummer staat al in de playlist.");
            return;
        }

        songs.Add(song);
        Console.WriteLine($"'{song.Title}' is toegevoegd aan de playlist '{Title}'.");
    }

    // Verwijderdt een Song uit de playlist op basis van titel en artiest
    public void RemoveSong()
    {
        Console.WriteLine("Voer de titel van het nummer in dat je wilt verwijderen:");
       Console.ReadLine();
        Console.WriteLine("Voer de artiest van het nummer in:");
      Console.ReadLine();

        var songToRemove = songs.FirstOrDefault(s =>
            s.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
            s.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));

        if (songToRemove != null)
        {
            songs.Remove(songToRemove);
            Console.WriteLine($"'{title}' van {artist} is verwijderd uit de playlist '{Title}'.");
        }
        else
        {
            Console.WriteLine("Error: Dit nummer staat niet in de playlist.");
        }
    }

    public override string ToString()
    {
        return $"Playlist: {Title}, Owner: {owner.Name}, Public: {IsPublic}";
    }
}