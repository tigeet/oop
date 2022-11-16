using Backups.Exceptions;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;
using Backups.Models.StorageAlgorithm;
namespace Backups.Models;
public class BackupTask
{
    private List<BackupObject> _trackedObjects = new List<BackupObject>();
    private List<BackupObject> _backupObjects = new List<BackupObject>();
    public BackupTask(string mountTo, string taskName, IRepository repository, IStorageAlgorithm storageAlgorithm, IArchivator archivator)
    {
        StorageAlgorithm = storageAlgorithm;
        TaskName = taskName;
        Repository = repository;
        Id = Guid.NewGuid();
        MountedAt = mountTo;
        Archivator = archivator;
        Backup = new Backup();
    }

    private IArchivator Archivator { get; }
    private string MountedAt { get; }
    private string TaskName { get; }
    private Guid Id { get; set; }
    private IRepository Repository { get; }
    private IStorageAlgorithm StorageAlgorithm { get; }
    private Backup Backup { get; }

    public BackupObject Add(string filePath)
    {
        var repositoryObject = Repository.CreateRepositoryObject(filePath);
        var backupObject = new BackupObject(repositoryObject.ObjectInfo, Repository);

        if (_trackedObjects.Contains(backupObject))
            throw new TrackedException("Object is already being tracked");

        _backupObjects.Add(backupObject);
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