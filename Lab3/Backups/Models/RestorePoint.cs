using Backups.Models.Storage;

namespace Backups.Models;
public class RestorePoint
{
    private List<BackupObject> _backupObjects;
    public RestorePoint(DateTime dateCreated, IStorage storage, List<BackupObject> backupObjects)
    {
        DateCreated = dateCreated;
        Storage = storage;
        _backupObjects = new List<BackupObject>(backupObjects);
    }

    public DateTime DateCreated { get; }
    public IStorage Storage { get; }
    public List<BackupObject> BackupObjects { get { return new List<BackupObject>(_backupObjects); } }
}