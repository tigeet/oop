using Backups.Models.RepositoryObject;

namespace Backups.Models.Repository;
public interface IRepository
{
    public List<IRepositoryObject> ListObjects(string listFrom);
    public FileStream OpenFileStream(string getFrom);
    public void CloseFileStream(FileStream fileStream);
    public IRepositoryObject CreateRepositoryObject(string objectPath);

    public string CreateDirectory(string makeAt, string folderName);
}