namespace spotiCLI;

public class SongS
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public int Year { get; set; }
    public Genres Genre { get; set; }

    public SongS(string title, string artist, string album, int year, Genres genre)
    {
        Title = title;
        Artist = artist;
        Album = album;
        Year = year;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist} from the album {Album} ({Year}) - Genre: {Genre}";
    }
}