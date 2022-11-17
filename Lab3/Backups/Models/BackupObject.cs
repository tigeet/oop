using Backups.Models.Repository;

namespace Backups.Models;

public class BackupObject
{
    public BackupObject(IRepositoryObject repositoryObject)
    {
        RepositoryObject = repositoryObject;
    }

    public IRepositoryObject RepositoryObject { get; }
}