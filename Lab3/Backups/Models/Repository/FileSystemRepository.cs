using Backups.Exceptions;
namespace Backups.Models.Repository;
public class FileSystemRepository : IRepository
{
    public FileSystemRepository(string path)
        : base()
    {
        Path = path;
    }

    public string Path { get; }

    public void MakeDirectory(string path, string name)
    {
        try
        {
        Directory.CreateDirectory(path + "\\" + name + "\\");
        }
        catch
        {
            throw new MemoryException("Failed to create a file");
        }
    }

    public void MakeFile(string path, string name)
    {
        try
        {
            File.Create(path + "\\" + name);
        }
        catch
        {
            throw new MemoryException("Failed to create a file");
        }
    }

    public byte[] ReadBytes(string path)
    {
        try
        {
            return File.ReadAllBytes(path);
        }
        catch
        {
            throw new MemoryException("Failed to read bytes from a file");
        }
    }

    public void Write(string path, string content)
    {
        try
        {
            File.WriteAllText(path, content);
    }
        catch
        {
            throw new MemoryException("Failed to write to a file");
}
    }

    public void WriteBytes(string path, byte[] bytes)
    {
        try
        {
            File.WriteAllBytes(path, bytes);
    }
        catch
        {
            throw new MemoryException("Failed to write bytes to a file");
}
    }
}