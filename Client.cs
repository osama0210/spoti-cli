namespace spotiCLI;

public class Client
{
    private Person activeUser;

    public Client(Person user)
    {
        activeUser = user;
    }
    
    public void AddPlaylist()
    {
        Console.WriteLine("Enter playlist name: ");
        String title = Console.ReadLine();
        
        Console.WriteLine("Make playlist public? (y/n):");
        string isPublicInput = Console.ReadLine();
        bool isPublic;
        if (isPublicInput == "y")
        {
            isPublic = true;
        }
        else
        {
            isPublic = false;
        }
        activeUser.Library.AddPlaylist(new Playlist(title, activeUser, isPublic));
    }

    public void RemovePlaylistByTitle()
    {
        Console.WriteLine("Type playlist name to remove");
        string title = Console.ReadLine();
        activeUser.Library.RemovePlaylistByTitle(title);
    }

    public void ShowLibrary()
    {
        activeUser.Library.ShowLibrary();
    }

    public void ShowPlaylists()
    {
        activeUser.Library.ShowPlaylists();
    }
    
    public void ShowLibraryMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== My Library ===");
            Console.WriteLine("1. Show all playlists");
            Console.WriteLine("2. Manage a playlist");
            Console.WriteLine("3. Show all albums");
            Console.WriteLine("4. Add new playlist");
            Console.WriteLine("5. Delete a playlist");
            Console.WriteLine("6. Delete an album");
            Console.WriteLine("7. share playlistt");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    activeUser.Library.ShowPlaylists();
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "6":
                    break;

                case "7":
                    Console.WriteLine("Share playlist not implemented yet");
                    break;

                case "8":
                    isRunning = false;
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

        }
    }
}