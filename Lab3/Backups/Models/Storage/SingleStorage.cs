using System;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;
namespace Backups.Models.Storage;
public class SingleStorage : IStorage
{
    public SingleStorage()
    {
        StorageName = Utils.Utils.RandomString(8);
    }

    public Archive? Archive { get; set; }

    public List<IRepositoryObject> RepositoryObjects
    {
        get
        {
            return Archive != null ? Archive.RepositoryObjects : new List<IRepositoryObject>();
        }
    }

    public string StorageName { get; }

    public string CreateStorage(IRepository repository, string createAt)
    {
        return repository.CreateDirectory(createAt, StorageName);
    }
}
