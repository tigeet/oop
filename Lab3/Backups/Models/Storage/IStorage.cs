using System;
namespace Backups.Models.Storage;
public interface IStorage
{
    public List<IRepositoryObject> RepositoryObjects { get; }
}