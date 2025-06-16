namespace spotiCLI;

public class Album : SongCollection
{
    Artist artist = new Artist();
    Song song;
    private DateTime releaseDate;
    private string AlbumName;
    public List<String> AlbumsList = new List<String>();
    
    
    public string albumName
    {
        get{return AlbumName;}
        set{ AlbumName = value; }
    }
    
    public DateTime ReleaseDate { get; set; }

  
    
    
    public Album( String artistName ,String albumName, String songName, String releaseDate )
    {
        String artName;
        if (artist.artistlist.Exists(x => x == artistName))
        {
            artName = artistName;
        }
        else
        {
            Console.WriteLine("ArtistName is not found in Artists List"); 
        }
        String sonName;
        if (song.songslist.Exists(x => x == songName))
        {
            sonName = songName;
        }
        else
        {
            Console.WriteLine("SongName is not found in Songs List"); 
        }
    }

    public void ShowArtists()
    {
        //
    }
    
}