namespace spotiCLI;

public class Song
{
    public string SongName { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public int Year { get; set; }
    public Genres Genre { get; set; }
    public string Lyrics { get; set; }
    public bool Favorite { get; set; }
    public int Duration { get; set; } // Duur van het nummer in seconden

    public Song(string songName, string artist, string album, int year, Genres genre, int duration = 0, string lyrics = "")
    {
        SongName = songName;
        Artist = artist;
        Album = album;
        Year = year;
        Genre = genre;
        Duration = duration;
        Lyrics = lyrics;
        Favorite = false;
    }

    public static List<Song> Songs10()
    {
        return new List<Song>
      {
        new Song("Starlit Avenue", "Nova Lane", "Midnight Drive", 2022, Genres.Pop, 210),
        new Song("Echoes of Tomorrow", "The Wanderers", "Future Sounds", 2021, Genres.Electronic, 195),
        new Song("Crimson Skies", "Scarlet Road", "Red Horizon", 2020, Genres.Rock, 230),
        new Song("Silent Whispers", "Luna Grey", "Moonlit Tales", 2023, Genres.Jazz, 180),
        new Song("Golden Leaves", "Autumn Breeze", "Seasons", 2019, Genres.Classical, 240),
        new Song("Neon Dreams", "Pulse City", "Electric Nights", 2024, Genres.HipHop, 200),
        new Song("Shadow Dance", "Velvet Mist", "Hidden Steps", 2022, Genres.RnB, 215),
        new Song("Frozen Time", "Arctic Flow", "Winter Chill", 2020, Genres.Metal, 250),
        new Song("Paper Boats", "River Song", "Drift Away", 2021, Genres.Country, 190),
        new Song("Sunrise Parade", "Morning Glow", "New Dawn", 2023, Genres.Pop, 205)
      };
    }

    public void DisplayLyrics()
    {
        Console.WriteLine($"Lyrics van {SongName}:\n{Lyrics}");
    }

    public override string ToString()
    {
        return $"{SongName} gemaakt door {Artist} van het album '{Album}' ({Year}) - Genre: {Genre} - Duur: {Duration} sec";
    }
}
