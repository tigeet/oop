using System;
namespace Backups.Models;
public class Archive
{
    private List<ArchiveObject> _objects = new List<ArchiveObject>();
    public Archive(string name, string locatedAt)
    {
        Name = name;
        LocatedAt = locatedAt;
        PathToArchive = Path.Combine(locatedAt, name);
    }

    public string LocatedAt { get; }
    public string PathToArchive { get; }
    public string Name { get; }
    public List<IRepositoryObject> RepositoryObjects { get { return _objects.Select(obj => obj.RepositoryObject).ToList(); } }
    public List<ArchiveObject> ArchiveObjects { get { return new List<ArchiveObject>(_objects); } }
    public void Add(List<ArchiveObject> objectsToAdd)
    {
        _objects.AddRange(objectsToAdd);
    }
}