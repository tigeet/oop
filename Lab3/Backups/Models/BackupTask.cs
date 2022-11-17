using Backups.Exceptions;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;
using Backups.Models.StorageAlgorithm;
namespace Backups.Models;
public class BackupTask
{
    private List<BackupObject> _trackedObjects = new List<BackupObject>();

    public BackupTask(string mountTo, string taskName, IRepository repository, IStorageAlgorithm storageAlgorithm, IArchivator archivator)
    {
        TaskName = taskName;
        MountedAt = mountTo;

        StorageAlgorithm = storageAlgorithm;
        Repository = repository;
        Archivator = archivator;
        Backup = new Backup(this);
    }

    public string MountedAt { get; }
    public string TaskName { get; }
    public Backup Backup { get; }

    private IArchivator Archivator { get; }
    private IRepository Repository { get; }
    private IStorageAlgorithm StorageAlgorithm { get; }

    public BackupObject Add(string filePath)
    {
        var repositoryObject = Repository.CreateRepositoryObject(filePath);
        var backupObject = new BackupObject(repositoryObject);

        if (_trackedObjects.Contains(backupObject))
            throw new TrackedException("Object is already being tracked");

        _trackedObjects.Add(backupObject);

        return backupObject;
    }

    public void Rm(BackupObject backupObject)
    {
        if (!_trackedObjects.Contains(backupObject))
            throw new TrackedException("Object is not being tracked");
        _trackedObjects.Remove(backupObject);
    }

    public void Commit()
    {
        IStorage storage = StorageAlgorithm.Commit(Repository, Archivator, writeTo: MountedAt, _trackedObjects);
        var restorePoint = new RestorePoint(DateTime.Now, storage, _trackedObjects);
        Backup.AddRestorePoint(restorePoint);
    }
}