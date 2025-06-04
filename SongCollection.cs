namespace spotiCLI;


// Deze klasse beheert een verzameling van liedjes (Song-objecten).
// Hierin ga ik later functies toevoegen om liedjes toe te voegen, op te halen of te verwijderen.
public class SongCollection
{
    
    // Deze lijst slaat alle Song-objecten op.
    // Deze is private zodat alleen deze klasse de directe toegang heeft tot de collectie.
    private List<Song> songs = new List<Song>();

    
    // Met deze methode voeg ik een Song-object toe aan de collectie.
    // Dit gebruik ik later om nieuwe liedjes aan het programma toe te voegen.
    public void AddSong(Song Song)
    {
        this.songs.Add(Song);
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