using System;
namespace Backups.Models;
public class Archive
{
    private List<ArchiveObject> _objects;
    public Archive(FileInfo archiveInfo, List<ArchiveObject> archiveObjects)
    {
        ArchiveInfo = archiveInfo;
        _objects = new List<Models.ArchiveObject>(archiveObjects);
    }

    public FileInfo ArchiveInfo { get; }
    public List<IRepositoryObject> RepositoryObjects { get { return _objects.Select(obj => obj.RepositoryObject).ToList(); } }
    public List<ArchiveObject> ArchiveObjects { get { return _objects; } }
}