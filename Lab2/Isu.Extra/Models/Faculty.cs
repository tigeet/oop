namespace Isu.Extra.Models;

public class Faculty
{
    public Faculty(char letter)
    {
        Letter = letter;
        Name = letter.ToString();
    }

    public string Name { get; }
    public char Letter { get; }
}
