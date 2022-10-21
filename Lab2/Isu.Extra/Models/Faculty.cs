namespace Isu.Extra.Models;

public class Faculty
{
    public Faculty(char letter)
    {
        Letter = letter;
        Name = "map letter to faculty"; // map
    }

    public string Name { get; }
    public char Letter { get; }
}
