using Backups.Models.RepositoryObject;

namespace Backups.Models.Repository;
public interface IRepository
{
    public List<IRepositoryObject> ListObjects(string listFrom);
    public FileStream OpenFileStream(FileInfo getFrom);
    public void CloseFileStream(FileStream fileStream);
    public IRepositoryObject CreateRepositoryObject(string objectPath);
}