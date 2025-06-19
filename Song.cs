namespace spotiCLI;

public class Song
{
    Artist artist = new Artist();
    
    private List<String> SongsList = new List<String>();
    public List<String> songslist
    {
        get{return SongsList;}
        set{SongsList = value;}
    }
    
    
    private String SongName;
    public String songName
    {
        set{SongName = value;}
        get{return SongName;}
    }
    

    private int SongDuration;
    public int SongLength
    {
        set{SongDuration = value;}
        get{return SongDuration;}
    }
    
    
    private String SongGenre;
    public String songGenre
    {
        set{SongGenre = value;}
        get{return SongGenre;}
    }

    public Song( Artist artistName ,String songName, int songDuration, String songGenre )
    {
        Artist artName;
        if (artist.artistlist.Exists(x => x == artistName))
        {
            artName = artistName;
        }
        else
        {
            Console.WriteLine("ArtistName is not found in Artist List"); 
        }
    }
}