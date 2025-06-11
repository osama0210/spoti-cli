namespace spotiCLI;

public class Playlist : SongCollection
{
    public Person owner;
    private bool isPublic = true;
    
    public bool IsPublic { get; set; }
    
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
}