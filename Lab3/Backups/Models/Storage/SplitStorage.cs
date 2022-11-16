using System;

namespace Backups.Models.Storage;
public class SplitStorage : IStorage
{
    private List<Archive> _archives;
    public SplitStorage(List<Archive> archives)
    {
        _archives = archives;
    }

    public List<Archive> Archives { get { return _archives; } }

    public List<IRepositoryObject> RepositoryObjects
    {
        get
        {
            return _archives.SelectMany(archive => archive.RepositoryObjects).ToList();
        }
    }
}