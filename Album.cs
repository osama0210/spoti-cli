namespace spotiCLI
{
    // Klasse die een Album voorstelt, erft van SongCollection
    public class Album : SongCollection
    {
        private string albumName;
        private DateTime releaseDate;
        private Artist artist;

        // Geeft de naam van het album terug of stelt deze in
        public string AlbumName
        {
            get { return albumName; }
            set { albumName = value; }
        }

        // Geeft de releasedatum van het album terug of stelt deze in
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        // Geeft de artiest van het album terug of stelt deze in
        public Artist Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        // Geeft de lijst van songs in het album terug (komt uit SongCollection)
        public List<Song> Songs
        {
            get { return songs; }
        }

        // Constructor om een album te maken met naam, artiest, releasedatum en lijst van songs
        public Album(string albumName, Artist artist, DateTime releaseDate, List<Song> songs)
        {
            if (albumName == null) throw new ArgumentNullException(nameof(albumName));
            if (artist == null) throw new ArgumentNullException(nameof(artist));

            AlbumName = albumName;
            Artist = artist;
            ReleaseDate = releaseDate;
            Title = albumName; // Zet de Title property van SongCollection

            // Voeg songs toe aan de songs lijst van SongCollection, voorkom null referentie
            if (songs != null)
            {
                this.songs.AddRange(songs);
            }
        }

        // Controleert of een song met een bepaalde titel in het album zit
        public bool ContainsSong(string songName)
        {
            return Songs.Any(s => s.Title == songName);
        }

        // Voegt een song toe aan het album als deze nog niet bestaat
        public void AddSong(Song song)
        {
            if (!ContainsSong(song.Title))
            {
                songs.Add(song);
                Console.WriteLine($"'{song.Title}' is toegevoegd aan het album '{AlbumName}'.");
            }
        }

        // Verwijdert een song met een bepaalde titel uit het album
        public void RemoveSong(string songName)
        {
            var song = Songs.FirstOrDefault(s => s.Title == songName);
            if (song != null)
            {
                songs.Remove(song);
                Console.WriteLine($"'{songName}' is verwijderd uit het album '{AlbumName}'.");
            }
        }

        // Geeft een stringrepresentatie van het album terug met naam, artiest, releasedatum en aantal nummers
        public override string ToString()
        {
            return $"Album: {AlbumName} door {Artist?.artistName ?? "Onbekend"}, Releasedatum: {ReleaseDate.ToShortDateString()}, Aantal nummers: {Songs.Count}";
        }
    }
}
