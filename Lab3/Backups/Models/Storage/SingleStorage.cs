using System;
using Backups.Models.RepositoryObject;
namespace Backups.Models.Storage;
public class SingleStorage : IStorage
{
    private List<IRepositoryObject> _repositoryObjects;
    public SingleStorage(Archive archive)
    {
        _repositoryObjects = archive.RepositoryObjects;
    }

    public List<IRepositoryObject> RepositoryObjects
    {
        get
        {
            return _repositoryObjects;
        }
    }
}
