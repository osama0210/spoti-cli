namespace spotiCLI;

public class Album : SongCollection
{
    private string albumName;
    private DateTime releaseDate;
    private Artist artist;
    public List<Song> Songs { get; set; } = new List<Song>();

    public string AlbumName
    {
        get { return albumName; }
        set { albumName = value; }
    }

    public DateTime ReleaseDate
    {
        get { return releaseDate; }
        set { releaseDate = value; }
    }

    public Artist Artist
    {
        get { return artist; }
        set { artist = value; }
    }

    public Album(string albumName, Artist artist, DateTime releaseDate, List<Song> songs)
    {
        AlbumName = albumName;
        Artist = artist;
        ReleaseDate = releaseDate;
        Songs = songs ?? new List<Song>();
        Title = albumName; // SongCollection property
        songs.ForEach(song => this.songs.Add(song)); // SongCollection lijst vullen
    }

    // Controleert of een song in het album zit op basis van titel
    public bool ContainsSong(string songName)
    {
        return Songs.Any(s => s.Title == songName);
    }

    // Voegt een song toe aan het album
    public void AddSong(Song song)
    {
        if (!ContainsSong(song.Title))
        {
            Songs.Add(song);
            songs.Add(song); // Voegt toe aan de SongCollection lijst
            Console.WriteLine($"'{song.Title}' is toegevoegd aan het album '{AlbumName}'.");
        }
    }

    // Verwijderdt een song uit het album
    public void RemoveSong(string songName)
    {
        var song = Songs.FirstOrDefault(s => s.Title == songName);
        if (song != null)
        {
            Songs.Remove(song);
            songs.Remove(song); 
            Console.WriteLine($"'{songName}' is verwijderd uit het album '{AlbumName}'.");
        }
    }

    public override string ToString()
    {
        return $"Album: {AlbumName} door {Artist?.artistName ?? "Onbekend"}, Releasedatum: {ReleaseDate.ToShortDateString()}, Aantal nummers: {Songs.Count}";
    }
}