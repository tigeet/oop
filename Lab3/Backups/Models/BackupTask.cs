using Backups.Exceptions;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.StorageAlgorithm;

namespace Backups.Models;
public class BackupTask
{
    private List<BackupObject> _trackedObjects = new List<BackupObject>();
    private List<RestorePoint> _restorePoints = new List<RestorePoint>();
    private List<BackupObject> _backupObjects = new List<BackupObject>();
    public BackupTask(string path, string name, IRepository repository, IStorageAlgorithm storageAlgorithm, IArchivator archivator)
    {
        StorageAlgorithm = storageAlgorithm;
        Name = name;
        Repository = repository;
        Id = Guid.NewGuid();
        Path = path;
        Archivator = archivator;
        Repository.MakeDirectory(Path, Id.ToString());
    }

    public IArchivator Archivator { get; }
    public string Path { get; }
    public string Name { get; }
    public Guid Id { get; set; }
    public IRepository Repository { get; }
    public IStorageAlgorithm StorageAlgorithm { get; }
    public List<BackupObject> Tracked { get { return _trackedObjects; } }
    public List<RestorePoint> RestorePoints { get { return _restorePoints; } }
    public List<BackupObject> BackupObjects { get { return _backupObjects; } }
    public void Add(BackupObject backupObject)
    {
        if (_trackedObjects.Contains(backupObject))
            throw new TrackedException("Object is already being tracked");

        _backupObjects.Add(backupObject);
        _trackedObjects.Add(backupObject);
    }

    public void Rm(BackupObject backupObject)
    {
        if (!_trackedObjects.Contains(backupObject))
            throw new TrackedException("Object is not being tracked");
        _trackedObjects.Remove(backupObject);
    }

    public string Commit()
    {
        var restorePoint = new RestorePoint(this, DateTime.Now, _trackedObjects.ToArray());
        Repository.MakeDirectory(Path + Id, restorePoint.Id.ToString());
        _restorePoints.Add(restorePoint);

        string restorePointPath = Path + Id + "\\" + restorePoint.Id.ToString() + "\\";
        List<Storage> storages = StorageAlgorithm.MapObjectsToStorages(Tracked);
        Archivator.Write(restorePointPath, storages, Repository);
        return restorePointPath;
    }
}