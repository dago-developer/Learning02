// Showing Creativity and Exceeding Requirements
// I just add a new entry journal, as you can see now the user can write the place at the moment he's using this app.

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Place { get; set; }

    // Muestra la entrada
    public void DisplayEntry()
    {
        Console.WriteLine($"{Date}: {Prompt} - {Response} / {Place}");
    }
}
