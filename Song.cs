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

    public static List<Song> Songs10()
    {
        return new List<Song>
      {
        new Song("Starlit Avenue", "Nova Lane", "Midnight Drive", 2022, Genres.Pop),
        new Song("Echoes of Tomorrow", "The Wanderers", "Future Sounds", 2021, Genres.Electronic),
        new Song("Crimson Skies", "Scarlet Road", "Red Horizon", 2020, Genres.Rock),
        new Song("Silent Whispers", "Luna Grey", "Moonlit Tales", 2023, Genres.Jazz),
        new Song("Golden Leaves", "Autumn Breeze", "Seasons", 2019, Genres.Classical),
        new Song("Neon Dreams", "Pulse City", "Electric Nights", 2024, Genres.HipHop),
        new Song("Shadow Dance", "Velvet Mist", "Hidden Steps", 2022, Genres.RnB),
        new Song("Frozen Time", "Arctic Flow", "Winter Chill", 2020, Genres.Metal),
        new Song("Paper Boats", "River Song", "Drift Away", 2021, Genres.Country),
        new Song("Sunrise Parade", "Morning Glow", "New Dawn", 2023, Genres.Pop)
      };
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

    