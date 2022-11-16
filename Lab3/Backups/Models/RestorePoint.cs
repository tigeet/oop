using Backups.Models.Storage;

namespace Backups.Models;
public class RestorePoint
{
    private List<BackupObject> _backupObjects;
    public RestorePoint(DateTime dateCreated, IStorage storage, List<BackupObject> backupObjects)
    {
        Id = Guid.NewGuid();
        DateCreated = dateCreated;
        Storage = storage;
        _backupObjects = new List<BackupObject>(backupObjects);
    }

    public Guid Id { get; }
    public DateTime DateCreated { get; }
    public IStorage Storage { get; }
    public List<BackupObject> BackupObjects { get { return _backupObjects; } }
}