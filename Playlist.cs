namespace spotiCLI;

public class Playlist : SongCollection
{
    public Person owner;
    private bool isPublic = true;
    
    public bool IsPublic { get; set; }

    private Song? currentSong = null;
    private bool isPaused = false;

    public Playlist(string title, Person owner, bool isPublic)
    {
        this.Title = title;
        this.owner = owner;
        this.IsPublic = isPublic;
    }
    
    // Met deze methode voeg ik een Song-object toe aan de collectie.
    // Dit gebruik ik later om nieuwe liedjes aan het programma toe te voegen.
    public void AddSong(Song song)
    {
        this.songs.Add(song);
    }

    public void RemoveSong(Song song)
    {
        this.songs.Remove(song);
    }

    // Methode om een specifiek nummer af te spelen vanuit de playlist
    public void PlaySong(string songTitle)
    {
        var song = songs.FirstOrDefault(s => s.SongName == songTitle);
        if (song != null)
        {
            currentSong = song;
            isPaused = false;
            Console.WriteLine($"Afspelen: '{song.SongName}'");
        }
        else
        {
            Console.WriteLine("Error: This song is not in your playlist.");
        }
    }

    // Methode om het huidige nummer te pauzeren
    public void PauseSong()
    {
        if (currentSong != null && !isPaused)
        {
            isPaused = true;
            Console.WriteLine($"Pauze: '{currentSong.SongName}'");
        }
        else if (currentSong == null)
        {
            Console.WriteLine("Er wordt momenteel geen nummer afgespeeld.");
        }
        else
        {
            Console.WriteLine("Het nummer is al gepauzeerd.");
        }
    }

    // Methode om het huidige nummer te hervatten
    public void ResumeSong()
    {
        if (currentSong != null && isPaused)
        {
            isPaused = false;
            Console.WriteLine($"Hervat: '{currentSong.SongName}'");
        }
        else if (currentSong == null)
        {
            Console.WriteLine("Er wordt momenteel geen nummer afgespeeld.");
        }
        else
        {
            Console.WriteLine("Het nummer wordt al afgespeeld.");
        }
    }
    
    public override string ToString()
    {
        return $"Playlist: {Title}, Owner: {owner.Name}, Public: {IsPublic}";
    }
}
