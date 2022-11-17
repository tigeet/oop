using System;
using Backups.Models.Repository;

namespace Backups.Models.Storage;
public interface IStorage
{
    public List<IRepositoryObject> RepositoryObjects { get; }
    public string StorageName { get; }
    public string CreateStorage(IRepository repository, string createAt);
}