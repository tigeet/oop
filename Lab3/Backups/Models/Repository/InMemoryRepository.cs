namespace Backups.Models.Repository;
public class InMemoryRepository : IRepository
{
    public void MakeDirectory(string path, string name)
    {
        throw new NotImplementedException();
    }

    public void MakeFile(string path, string name)
    {
        throw new NotImplementedException();
    }

    public byte[] ReadBytes(string path)
    {
        throw new NotImplementedException();
    }

    public void Write(string path, string content)
    {
        throw new NotImplementedException();
    }

    public void WriteBytes(string path, byte[] bytes)
    {
        throw new NotImplementedException();
    }
}
