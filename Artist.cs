namespace spotiCLI;

public class Artist
{
    private List<String> ArtistsList = new List<String>();
    public List<String> artistlist
    {
        get{return ArtistsList;}
        set{ArtistsList = value;}
    }
    
    
    private string ArtistName;
    public string artistName
    {
        get{return ArtistName;}
        set{ ArtistName = value; }
    }
    
    

    public void AddArtist()
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
    }

    public List<String> getArtists()
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
        List<String> artists = getArtists();
    }
}

