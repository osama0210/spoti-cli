namespace spotiCLI;

public class Artist
{
    private List<Album> albums = new List<Album>();

    private List<Artist> ArtistsList = new List<Artist>
    {
    };
    public List<Artist> artistlist
    {
        get{return ArtistsList;}
        set{ArtistsList = value;}
    }
    
    public Artist( string artistName)
    {
        this.artistName = artistName;
    }
    
    
    private string artistName;
    public string ArtistName
    {
        get{return artistName;}
        set{ artistName = value; }
    }
    
    

    /*public void AddArtist()
    {
        Console.WriteLine("Enter a new Artist Name to be added");
        ArtistName = Console.ReadLine();
        ArtistsList.Add(ArtistName);
    }

    public void RemoveArtist()
    {
        Console.WriteLine("Enter a new Artist Name to be removed");
        ArtistName = Console.ReadLine();
        ArtistsList.Remove(ArtistName.ToString());
    }*/

    public List<Artist> getArtists()
    {
        return ArtistsList;
    }
    
    /*public String findArtist(string artistName)
    {
        if (artistlist.Find(x => x == artistName) != null)
        {
            return artistName;
        }
        else
        {
            Console.WriteLine("Artist not found");
        }

        return null;
    }

    */
    public void getArtistsList()
    {
        List<Artist> artists = getArtists();
    }
}