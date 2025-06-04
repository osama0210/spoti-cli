namespace spotiCLI;


// Deze klasse stelt één liedje voor in de applicatie.
// Elk liedje heeft een titel, artiest en album — opgeslagen als private velden.
// Met de bijbehorende properties (get/set) kan ik deze waardes veilig instellen of ophalen vanuit andere klassen.
// Dit wordt later gebruikt om een collectie van liedjes op te bouwen en ermee te werken in het programma.
public class Song
{


    // Hiermee geef ik toegang tot de artiest van het liedje.
    // Ik kan deze waarde ophalen (get) om te laten zien wie het heeft gemaakt,
    // en instellen (set) als ik een nieuwe artiest wil toewijzen aan dit nummer.
    private String Artist;

    public String artist
    {
        get { return Artist; }
        set { Artist = value; }
    }




    // Hiermee geef ik toegang tot het album van het liedje.
    // Met get kan ik zien van welk album het liedje komt,
    // en met set kan ik dat aanpassen als het moet veranderen.

    private String Album;

    public String album
    {
        get { return Album; }
        set { Album = value; }

    }





    // Hiermee geef ik toegang tot de titel van het liedje.
    // Met get kan ik deze titel ophalen om weer te geven in het programma (zoals in lijsten of tijdens afspelen).
    // Met set kan ik de titel instellen wanneer ik een nieuw Song-object aanmaak of de titel wil aanpassen.

    private string Title;

    public string title // property
    {
        get { return Title; } // get method
        set { Title = value; } // set method
    }


    
    // Hiermee geef ik toegang tot de songtekst (lyrics) van het liedje.
    // Met get kan ik de volledige tekst van het liedje ophalen en bijvoorbeeld weergeven tijdens het afspelen.
    // Met set kan ik handmatig lyrics toevoegen of aanpassen als die veranderen of later worden ingevuld.
        
    private string Lyrics;

    public string lyrics
    {
        get{return Lyrics;}
        set{ Lyrics = value; }
    }
    
}