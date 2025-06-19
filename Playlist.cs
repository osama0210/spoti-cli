namespace spotiCLI;

public class Playlist : SongCollection
{
    public Person owner;
    private bool isPublic = true;
    
    public bool IsPublic { get; set; }

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
    
    public override string ToString()
    {
        return $"Playlist: {Title}, Owner: {owner.Name}, Public: {IsPublic}";
    }
}