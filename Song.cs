using NAudio.Wave;


namespace spotiCLI
{
    public class Song
    {
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public Genres Genre { get; set; }
        public string Lyrics { get; set; }
        public bool Favorite { get; set; }
        public int Duration { get; set; } // Duration in seconds
        public string Mp3Path { get; set; } // Path to mp3 file

        public Song(string songName, string artist, string album, int year, Genres genre, int duration = 0, string lyrics = "", string mp3Path = "")
        {
            SongName = songName;
            Artist = artist;
            Album = album;
            Year = year;
            Genre = genre;
            Duration = duration;
            Lyrics = lyrics;
            Mp3Path = mp3Path;
            Favorite = false;
        }

        // Sample song list with mp3 paths
        public static List<Song> Songs10()
{
    return new List<Song>
    {
        new Song(
            "Neon Dreams",
            "Greenut-godzillaz",
            "Neon Dreams",
            2024,
            Genres.HipHop,
            200,
            "This is the chorus of Neon Dreams shining bright tonight",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\NeonDreams.mp3"
        ),
        new Song(
            "Crimson Skies",
            "Black Veil Brides",
            "Crimson Skies",
            2020,
            Genres.Rock,
            230,
            "Flying through the crimson skies, nothing left behind",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\CrimsonSkies.mp3"
        ),
        new Song(
            "Echoes of Tomorrow",
            "Celestial Keys",
            "Echoes of Tomorrow",
            2021,
            Genres.Electronic,
            195,
            "Echoes of tomorrow ring in my mind",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Echoes of tomorrow.mp3"
        ),
        new Song(
            "Frozen in time",
            "Tewez; Mally",
            "Phantom",
            2020,
            Genres.Metal,
            250,
            "Frozen in time, we cannot rewind",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\FrozenInTime.mp3"
        ),
        new Song(
            "Golden Leaves (feat. Benjamin)",
            "Bear McCreary; Benjamin",
            "Golden Leaves (feat. Benjamin)",
            2019,
            Genres.Classical,
            240,
            "Golden leaves are falling down",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\GoldenLeaves.mp3"
        ),
        new Song(
            "Paper Boat Dreams - with Lyrics",
            "Liam Starling; Relaxing Jazz",
            "Paper Boat Dreams",
            2021,
            Genres.Country,
            190,
            "We are floating, paper boat dreams",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\PaperBoatDream.mp3"
        ),
        new Song(
            "Paradise - Vocals Only - No Instruments",
            "Maher Zain",
            "Forgive Me (Vocals Only)",
            2022,
            Genres.Pop,
            210,
            "Oh paradise, waiting for me",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Paradise.mp3"
        ),
        new Song(
            "SHADOW DANCE",
            "SHADXWBXRN",
            "SHADOW DANCE",
            2022,
            Genres.RnB,
            215,
            "Dancing with shadows in the night",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\ShadowDance.mp3"
        ),
        new Song(
            "Silent Whispers",
            "Crow's Flight",
            "Silent Whispers",
            2023,
            Genres.Jazz,
            180,
            "Silent whispers, call my name",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Silent.mp3"
        ),
        new Song(
            "Starlit Avenue",
            "Mindtone",
            "Cozy Jazz, Vol. 1",
            2022,
            Genres.Pop,
            205,
            "Walking down the starlit avenue",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Starlit.mp3"
        ),
        
        //liedjes voor het album:
        new Song(
            "Bones",
            "BONES",
            "CRACKER",
            2023,
            Genres.Rock, // of een passend genre
            210,
            "Put hier de lyrics als je wilt",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Bones.mp3"
        ),
        new Song(
            "Noji",
            "Noji",
            "Winter Chill",
            2023,
            Genres.Jazz, // of ander genre
            200,
            "Hier kun je de lyrics zetten",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Noji.mp3"
        ),
        new Song(
            "God's Plan",
            "Drake",
            "Scorpion",
            2018,
            Genres.HipHop,
            210,
            "Put hier de lyrics als je wilt",
            @"C:\OOP-SpotiCLI\spoti-cli\mp3\Drake.mp3"
        ),

    };
    
  
}

        public void DisplayLyrics()
        {
            Console.WriteLine($"Lyrics of {SongName}:\n{Lyrics}");
        }

        public override string ToString()
        {
            return $"{SongName} by {Artist} from album '{Album}' ({Year}) - Genre: {Genre} - Duration: {Duration} sec";
        }
    }
}
