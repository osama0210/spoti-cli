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

    public void ShowLibrary()
    {
        activeUser.Library.ShowLibrary();
    }

    public void ShowPlaylists()
    {
        activeUser.Library.ShowPlaylists();
    }
}