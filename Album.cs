namespace spotiCLI;

public class Album : SongCollection
{
    
    private List<Artist> artistlist = new List<Artist>();
    Song song;
    private DateTime releaseDate;
    private string AlbumName;
    private List<String> AlbumsList = new List<String>();
    
    
    
    
    public List<String> albumsList
    {
        get{return AlbumsList;}
        set{AlbumsList = value;}
    }
    
    public string albumName
    {
        get{return AlbumName;}
        set{ AlbumName = value; }
    }
    
    public String ReleaseDate { get; set; }

  
    /*
     *  string? artistName ,String albumName, String songName, String releaseDate
     */


    public Album()
    {
        
    }

    public Album(String AlbumName, List <Song> SongName  ,String ReleaseDate)
    {
        Artist artName;
        this.Title = albumName;
        this.songs = SongName;
        this.ReleaseDate = ReleaseDate;
        
        /*if (artist.artistlist.Exists(x => x == artistName))
        {
            artName = artistName;
        }
        else
        {
            Console.WriteLine("ArtistName is not found in Artists List");
        }*/
        /*String sonName;
        if (song.songslist.Exists(x => x == songName))
        {
            sonName = songName;
        }
        else
        {
            Console.WriteLine("SongName is not found in Songs List");
        }*/
    }

   


    public List<String> getAlbums()
    {
        return AlbumsList;
    }
    
    public void getAlbumsList()
    {
        List<String> album = getAlbums();
    }


  
    public void ShowArtists()
    {
        //
    }
    
}