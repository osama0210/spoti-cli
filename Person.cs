namespace spotiCLI;

public class Person
{
    private string name;
    private string email;
    private Library library;
    private List<Friend> friends = new List<Friend>();

    public Person()
    {
        Library = new Library();
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public Library Library { get; set; }
    public Friend Friends { get; set; }
}