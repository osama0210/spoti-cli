namespace spotiCLI;

public class Playlist : SongCollection
{
    
    public Person owner;
    private bool isPublic = true;
    public List<Playlist> listplaylist = new List<Playlist>();

    public bool IsPublic { get; set; }

    public Playlist(string title, Person owner, bool isPublic)
    {
        this.Title = title;
        this.owner = owner;
        this.IsPublic = isPublic;
        //song or songs
    }

// Met deze methode voeg ik een Song-object toe aan de collectie.
// Dit gebruik ik later om nieuwe liedjes aan het programma toe te voegen.
    public void AddPlaylist(Playlist playlist)
    {
        listplaylist.Add(playlist);
    }

    public void RemovePlaylist(Playlist playlist)
    {
        listplaylist.Remove(playlist);
    }
}

