using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NAudio.Wave;

namespace spotiCLI
{
    public class Client
    {
        private Person activeUser;
        private List<Album> albums;

        public Client(Person user)
        {
            activeUser = user;

            // 1. Albums aanmaken (leeg, zonder liedjes)
            albums = new List<Album>
            {
                new Album("SummerVibe", new Artist("Drake"), new DateTime(2022, 6, 1), new List<Song>()),
                new Album("WinterChill", new Artist("Noji"), new DateTime(2023, 12, 1), new List<Song>()),
                new Album("AutumnLeaves", new Artist("Bones"), new DateTime(2021, 10, 1), new List<Song>())
            };

            // 2. Liedjes aan albums koppelen
            var allSongs = Song.Songs10(); // Of jouw eigen AllSongs lijst

            // AutumnLeaves => Bones
            var autumnLeaves = albums.FirstOrDefault(a => a.Title == "AutumnLeaves");
            if (autumnLeaves != null)
                autumnLeaves.AddSong(allSongs.FirstOrDefault(s => s.SongName == "Bones"));

            // WinterChill => Noji
            var winterChill = albums.FirstOrDefault(a => a.Title == "WinterChill");
            if (winterChill != null)
                winterChill.AddSong(allSongs.FirstOrDefault(s => s.SongName == "Noji"));

            // SummerVibe => God's Plan (stel je voegt dat nummer toe in Songs10)
            var summerVibe = albums.FirstOrDefault(a => a.Title == "SummerVibe");
            if (summerVibe != null)
                summerVibe.AddSong(allSongs.FirstOrDefault(s => s.SongName == "God's Plan"));

            // Nieuwe albums kunnen altijd toegevoegd worden:
            // Bijv. Scorpion album als je God's Plan wilt splitsen
            if (!albums.Any(a => a.Title == "Scorpion"))
            {
                var scorpion = new Album("Scorpion", new Artist("Drake"), new DateTime(2018, 6, 29), new List<Song>());
                scorpion.AddSong(allSongs.FirstOrDefault(s => s.SongName == "God's Plan"));
                albums.Add(scorpion);
            }
        }

        // === AL JE BESTAANDE METHODS ZIJN HIERONDER ONGEWIJZIGD ===

        public void AddPlaylist()
        {
            Console.Write("Enter playlist name: ");
            string title = Console.ReadLine();

            Console.Write("Make playlist public? (y/n): ");
            string isPublicInput = Console.ReadLine();
            bool isPublic = (isPublicInput.ToLower() == "y");

            activeUser.Library.AddPlaylist(new Playlist(title, activeUser, isPublic));
            Console.WriteLine($"Playlist '{title}' created!");
        }

        public void RemovePlaylistByTitle()
        {
            Console.Write("Enter the name of the playlist to remove: ");
            string title = Console.ReadLine();
            activeUser.Library.RemovePlaylistByTitle(title);
        }

        public void ShowPlaylists()
        {
            activeUser.Library.ShowPlaylists();
        }

        // Albums
        public void ShowAllAlbums()
        {
            Console.WriteLine("Available albums:");
            for (int i = 0; i < albums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {albums[i].Title} ({albums[i].ReleaseDate:yyyy-MM-dd})");
            }
        }

        public void AddAlbumToLibrary()
        {
            ShowAllAlbums();
            Console.Write("Enter the number of the album to add to your library: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice > 0 && choice <= albums.Count)
                {
                    Album selectedAlbum = albums[choice - 1];
                    if (!activeUser.Library.Albums.Contains(selectedAlbum))
                    {
                        activeUser.Library.AddAlbum(selectedAlbum);
                        Console.WriteLine($"{selectedAlbum.Title} added to your library!");
                    }
                    else
                    {
                        Console.WriteLine("You already have this album in your library.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        public void ShowAlbums()
        {
            activeUser.Library.ShowAlbums();
        }

        // Library
        public void ShowLibrary()
        {
            Console.Clear();
            Console.WriteLine("=== Your Library ===\n");

            // Show Playlists and their songs
            if (activeUser.Library.Playlists.Count > 0)
            {
                Console.WriteLine("Playlists:");
                foreach (var playlist in activeUser.Library.Playlists)
                {
                    Console.WriteLine($"- {playlist.Title} (Public: {playlist.IsPublic})");
                    if (playlist.songs.Count > 0)
                    {
                        foreach (var song in playlist.songs)
                        {
                            Console.WriteLine($"    * {song.SongName} by {song.Artist} [{song.Album}]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    (No songs in this playlist)");
                    }
                }
            }
            else
            {
                Console.WriteLine("No playlists found.");
            }

            Console.WriteLine("\nAlbums in your Library:");
            if (activeUser.Library.Albums.Count > 0)
            {
                foreach (var album in activeUser.Library.Albums)
                {
                    Console.WriteLine($"- {album.Title} by {album.Artist.ArtistName} (Released: {album.ReleaseDate:yyyy-MM-dd})");
                    if (album.Songs != null && album.Songs.Count > 0)
                    {
                        foreach (var song in album.Songs)
                        {
                            Console.WriteLine($"    * {song.SongName} by {song.Artist}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    (No songs in this album)");
                    }
                }
            }
            else
            {
                Console.WriteLine("No albums found.");
            }

            // Extra: let the user play a song from playlist or album
            Console.WriteLine("\nWould you like to play a song from your library?");
            Console.WriteLine("1. Play a song from a playlist");
            Console.WriteLine("2. Play a song from an album");
            Console.WriteLine("3. Back to menu");
            Console.Write("Choose an option: ");
            string playChoice = Console.ReadLine();

            switch (playChoice)
            {
                case "1":
                    PlaySongFromPlaylist();
                    break;
                case "2":
                    PlaySongFromAlbum();
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
        

        public void ShowAllSongs()
        {
            Console.WriteLine("All available songs:");
            foreach (var song in activeUser.Library.AllSongs)
            {
                Console.WriteLine(song.ToString());
            }
        }

        public void SearchSong()
        {
            Console.Write("Enter song name to search: ");
            string search = Console.ReadLine()?.ToLower();

            var results = activeUser.Library.AllSongs
                .Where(s => s.SongName.ToLower().Contains(search))
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No songs found.");
            }
            else
            {
                Console.WriteLine("Results:");
                foreach (var song in results)
                    Console.WriteLine(song.ToString());
            }
        }

        public void AddSongToPlaylist()
        {
            Console.Write("Enter the name of the playlist: ");
            string playlistName = Console.ReadLine();

            var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.WriteLine("Available songs:");
            foreach (var song in activeUser.Library.AllSongs)
            {
                Console.WriteLine($"- {song.SongName}");
            }

            Console.Write("Enter the name of the song to add: ");
            string songName = Console.ReadLine();

            var songToAdd = activeUser.Library.AllSongs.FirstOrDefault(s => s.SongName == songName);
            if (songToAdd == null)
            {
                Console.WriteLine("Song not found.");
                return;
            }

            playlist.AddSong(songToAdd);
            Console.WriteLine($"'{songName}' added to playlist '{playlistName}'.");
        }

        public void RemoveSongFromPlaylist()
        {
            Console.Write("Enter the name of the playlist: ");
            string playlistName = Console.ReadLine();

            var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.Write("Enter the name of the song to remove: ");
            string songName = Console.ReadLine();

            var song = playlist.songs.FirstOrDefault(s => s.SongName == songName);
            if (song == null)
            {
                Console.WriteLine("Song not found in playlist.");
                return;
            }

            playlist.RemoveSong(song);
            Console.WriteLine($"'{songName}' removed from playlist '{playlistName}'.");
        }

        public void PlaySongFromPlaylist()
        {
            Console.Write("Enter the name of the playlist: ");
            string playlistName = Console.ReadLine();

            var playlist = activeUser.Library.Playlists.FirstOrDefault(p => p.Title == playlistName);
            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            Console.Write("Enter the title of the song to play: ");
            string songTitle = Console.ReadLine();

            var song = playlist.songs.FirstOrDefault(s => s.SongName == songTitle);
            if (song == null)
            {
                Console.WriteLine("Song not found.");
                return;
            }

            Console.WriteLine($"Now playing: '{song.SongName}' by {song.Artist}");

            // MP3 afspelen als pad bestaat
            if (!string.IsNullOrEmpty(song.Mp3Path))
            {
                PlayMp3WithControls(song.Mp3Path);
            }
            else
            {
                Console.WriteLine("No mp3 file found for this song.");
            }

            Console.Write("Do you want to view the lyrics? (y/n): ");
            string showLyrics = Console.ReadLine();
            if (showLyrics.ToLower() == "y")
            {
                PlayLyrics(song);
            }
        }

        public void PlaySongFromAlbum()
        {
            if (activeUser.Library.Albums.Count == 0)
            {
                Console.WriteLine("You have no albums in your library.");
                return;
            }

            Console.WriteLine("Your albums:");
            for (int i = 0; i < activeUser.Library.Albums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activeUser.Library.Albums[i].Title}");
            }

            Console.Write("Enter the number of the album: ");
            if (int.TryParse(Console.ReadLine(), out int albumChoice) && albumChoice > 0 && albumChoice <= activeUser.Library.Albums.Count)
            {
                Album album = activeUser.Library.Albums[albumChoice - 1];

                if (album.Songs == null || album.Songs.Count == 0)
                {
                    Console.WriteLine("This album has no songs.");
                    return;
                }

                Console.WriteLine($"Songs in '{album.Title}':");
                for (int i = 0; i < album.Songs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {album.Songs[i].SongName} by {album.Songs[i].Artist}");
                }

                Console.Write("Enter the number of the song to play: ");
                if (int.TryParse(Console.ReadLine(), out int songChoice) && songChoice > 0 && songChoice <= album.Songs.Count)
                {
                    var song = album.Songs[songChoice - 1];
                    Console.WriteLine($"Now playing: '{song.SongName}' by {song.Artist}");

                    if (!string.IsNullOrEmpty(song.Mp3Path))
                    {
                        PlayMp3WithControls(song.Mp3Path);
                    }
                    else
                    {
                        Console.WriteLine("No mp3 file found for this song.");
                    }

                    Console.Write("Do you want to view the lyrics? (y/n): ");
                    string showLyrics = Console.ReadLine();
                    if (showLyrics.ToLower() == "y")
                    {
                        PlayLyrics(song);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid song choice.");
                }
            }
            else
            {
                Console.WriteLine("Invalid album choice.");
            }
        }

        // Lyrics player
        public void PlayLyrics(Song song)
        {
            if (string.IsNullOrWhiteSpace(song.Lyrics))
            {
                Console.WriteLine("No lyrics available for this song.");
                return;
            }

            var words = song.Lyrics.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            bool playing = true;
            bool paused = false;

            Console.WriteLine($"\nPlaying lyrics for '{song.SongName}'");
            Console.WriteLine("Controls: P=Pause, R=Resume, S=Restart, Q=Quit\n");

            while (playing && index < words.Length)
            {
                if (!paused)
                {
                    Console.Write(words[index] + " ");
                    index++;
                    Thread.Sleep(1000); // 1 seconde per woord
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.P:
                            paused = true;
                            Console.WriteLine("\nPaused. Controls: R=Resume, S=Restart, Q=Quit");
                            while (paused)
                            {
                                var pauseKey = Console.ReadKey(true);
                                if (pauseKey.Key == ConsoleKey.R)
                                {
                                    paused = false;
                                    Console.WriteLine("Resuming...\n");
                                }
                                else if (pauseKey.Key == ConsoleKey.S)
                                {
                                    index = 0;
                                    paused = false;
                                    Console.WriteLine("Restarting lyrics...\n");
                                }
                                else if (pauseKey.Key == ConsoleKey.Q)
                                {
                                    playing = false;
                                    Console.WriteLine("Exiting lyrics player.\n");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Controls: R=Resume, S=Restart, Q=Quit");
                                }
                            }
                            break;
                        case ConsoleKey.S:
                            index = 0;
                            paused = false;
                            Console.WriteLine("\nRestarting lyrics...\n");
                            break;
                        case ConsoleKey.Q:
                            playing = false;
                            Console.WriteLine("\nExiting lyrics player.");
                            return;
                    }
                }
            }
            if (index >= words.Length)
                Console.WriteLine("\nLyrics ended.");
        }

        // MP3 PLAYER WITH CONTROLS
        public void PlayMp3WithControls(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("No mp3 path set for this song.");
                return;
            }

            using (var audioFile = new AudioFileReader(path))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                bool running = true;
                bool stopped = false;

                Console.WriteLine("\nPlaying mp3... Press:");
                Console.WriteLine("P = Pause | R = Resume | S = Restart | Q = Stop\n");

                Thread keyThread = new Thread(() =>
                {
                    while (running)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true).Key;
                            switch (key)
                            {
                                case ConsoleKey.P:
                                    outputDevice.Pause();
                                    Console.WriteLine("Paused. (R = Resume | S = Restart | Q = Stop)");
                                    break;
                                case ConsoleKey.R:
                                    outputDevice.Play();
                                    Console.WriteLine("Resumed.");
                                    break;
                                case ConsoleKey.S:
                                    audioFile.Position = 0;
                                    outputDevice.Play();
                                    Console.WriteLine("Restarted.");
                                    break;
                                case ConsoleKey.Q:
                                    outputDevice.Stop();
                                    stopped = true;
                                    running = false;
                                    Console.WriteLine("Stopped playback.");
                                    break;
                            }
                        }
                        Thread.Sleep(100);
                    }
                });
                keyThread.Start();

                while (outputDevice.PlaybackState != PlaybackState.Stopped && !stopped)
                {
                    Thread.Sleep(200);
                }
                running = false;
                keyThread.Join();
            }
        }
    }
}
