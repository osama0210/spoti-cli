using System;

namespace spotiCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Person newUser = new Person();
            Client client = new Client(newUser);
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== SpotiCLI Main Menu ===");
                Console.WriteLine("1. Songs menu");
                Console.WriteLine("2. Playlists menu");
                Console.WriteLine("3. Albums menu");
                Console.WriteLine("4. My library");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SongsMenu(client);
                        break;
                    case "2":
                        PlaylistsMenu(client);
                        break;
                    case "3":
                        AlbumsMenu(client);
                        break;
                    case "4":
                        client.ShowLibrary();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // SONGS MENU
        static void SongsMenu(Client client)
        {
            bool inSongsMenu = true;
            while (inSongsMenu)
            {
                Console.Clear();
                Console.WriteLine("=== Songs Menu ===");
                Console.WriteLine("1. Show all songs");
                Console.WriteLine("2. Add song to playlist");
                Console.WriteLine("3. Search for a song");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        client.ShowAllSongs();
                        break;
                    case "2":
                        client.AddSongToPlaylist();
                        break;
                    case "3":
                        client.SearchSong();
                        break;
                    case "4":
                        inSongsMenu = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                if (inSongsMenu)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // PLAYLISTS MENU
        static void PlaylistsMenu(Client client)
        {
            bool inPlaylistsMenu = true;
            while (inPlaylistsMenu)
            {
                Console.Clear();
                Console.WriteLine("=== Playlists Menu ===");
                Console.WriteLine("1. Create new playlist");
                Console.WriteLine("2. Show my playlists");
                Console.WriteLine("3. Delete a playlist");
                Console.WriteLine("4. Play a song from playlist");
                Console.WriteLine("5. Remove song from playlist");
                Console.WriteLine("6. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        client.AddPlaylist();
                        break;
                    case "2":
                        client.ShowPlaylists();
                        break;
                    case "3":
                        client.RemovePlaylistByTitle();
                        break;
                    case "4":
                        client.PlaySongFromPlaylist();
                        break;
                    case "5":
                        client.RemoveSongFromPlaylist();
                        break;
                    case "6":
                        inPlaylistsMenu = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                if (inPlaylistsMenu)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // ALBUMS MENU
        static void AlbumsMenu(Client client)
        {
            bool inAlbumsMenu = true;
            while (inAlbumsMenu)
            {
                Console.Clear();
                Console.WriteLine("=== Albums Menu ===");
                Console.WriteLine("1. Show all albums");
                Console.WriteLine("2. Show my albums");
                Console.WriteLine("3. Add album to my library");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        client.ShowAllAlbums();
                        break;
                    case "2":
                        client.ShowAlbums();
                        break;
                    case "3":
                        client.AddAlbumToLibrary();
                        break;
                    case "4":
                        inAlbumsMenu = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                if (inAlbumsMenu)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
