namespace Backups.Models.Repository;
public interface IRepository
{
    public byte[] ReadBytes(string path);
    public void MakeDirectory(string path, string name);
    public void WriteBytes(string path, byte[] bytes);
    public void Write(string path, string content);
    public void MakeFile(string path, string name);
}