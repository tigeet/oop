namespace Backups.Models;
public class RestorePoint
{
    private List<BackupObject> _backupObjects;
    public RestorePoint(BackupTask backupTask, DateTime dateCreated, params BackupObject[] backupObjects)
    {
        Id = Guid.NewGuid();
        DateCreated = dateCreated;
        BackupTask = backupTask;
        _backupObjects = new List<BackupObject>(backupObjects);
    }

    public List<BackupObject> BackupObjects { get { return _backupObjects; } }
    public Guid Id { get; }
    public DateTime DateCreated { get; }
    public BackupTask BackupTask { get; }
}