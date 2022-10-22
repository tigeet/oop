namespace Isu.Services;
public class StudentIdFactory
{
    private static int startId = 100000;
    private int nextId;
    public StudentIdFactory()
    {
        nextId = startId;
    }

    public int GetNewId()
    {
        return nextId++;
    }
}
