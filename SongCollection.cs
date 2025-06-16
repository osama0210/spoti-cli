namespace spotiCLI;

// Deze klasse beheert een verzameling van liedjes (Song-objecten).
// Hierin ga ik later functies toevoegen om liedjes toe te voegen, op te halen of te verwijderen.
public abstract class SongCollection
{
    // Deze lijst slaat alle Song-objecten op.
    // Deze is private zodat alleen deze klasse de directe toegang heeft tot de collectie.
    private String title;
    public List<Song> songs = new List<Song>();

    public String Title
    {
        get { return title;}
        set { title = value; }
    }
    
    public void PlayAll()
    {
        
    }

    public void Shuffle()
    {
        
    }

    // Deze methode laat alle opgeslagen liedjes zien via de console.
    // Wordt gebruikt om de collectie zichtbaar te maken voor de gebruiker.
    public void ShowSongs()
    {
        foreach (Song song in this.songs)
        {
            Console.WriteLine(song.title);
            Console.WriteLine(song.lyrics);
            Console.WriteLine(song.album);
            Console.WriteLine(song.artist);
        }
    }
}