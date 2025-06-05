namespace spotiCLI;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public int Year { get; set; }
    public Genres Genre { get; set; }
    public string Lyrics { get; set; }
    public bool Favorite { get; set; }

    public Song(string title, string artist, string album, int year, Genres genre, string lyrics = "")
    {
        Title = title;
        Artist = artist;
        Album = album;
        Year = year;
        Genre = genre;
        Lyrics = lyrics;
        Favorite = false;
    }

    public void DisplayLyrics()
    {
        Console.WriteLine($"tittle van {Title}:\n{Lyrics}");
    }

    public override string ToString()
    {
        return $"{Title} gemaakt door {Artist} van de album '{Album}' ({Year}) - Genre: {Genre}";
    }
}