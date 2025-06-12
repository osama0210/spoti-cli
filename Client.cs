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
        activeUser.Library.AddPlaylist(new Playlist("eerste playlist", activeUser, true));
        activeUser.Library.AddPlaylist(new Playlist("eerste playlist", activeUser, true));

    }

    public void showPlaylists()
    {
        activeUser.Library.ShowPlaylists();
    }
}