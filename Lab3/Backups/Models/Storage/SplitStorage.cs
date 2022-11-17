using System;
using Backups.Models.Repository;

namespace Backups.Models.Storage;
public class SplitStorage : IStorage
{
    private List<Archive> _archives = new List<Archive>();
    public SplitStorage()
    {
        StorageName = Utils.Utils.RandomString(8);
    }

    public string StorageName { get; }
    public List<Archive> Archives { get { return new List<Archive>(_archives); } }

    public List<IRepositoryObject> RepositoryObjects
    {
        get
        {
            return _archives.SelectMany(archive => archive.RepositoryObjects).ToList();
        }
    }

    public void Add(List<Archive> archives)
    {
        _archives.AddRange(archives);
    }

    public string CreateStorage(IRepository repository, string createAt)
    {
        return repository.CreateDirectory(createAt, StorageName);
    }
}