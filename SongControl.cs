using spotiCLI;

Artist artist = new Artist();
artist.AddArtist();
artist.AddArtist();

Console.WriteLine(artist.artistlist.Count);
foreach (var art in artist.artistlist)
{
    Console.WriteLine(art.ToString());
}

public class SongControl
{
    
}

/*client.AddPlaylist();
client.showPlaylists();
}*/