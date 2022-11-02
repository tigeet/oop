namespace Backups.Models;
public class Storage
{
    public Storage(params BackupObject[] backupObjects)
    {
        BackupObjects = backupObjects.ToList();
        Id = Guid.NewGuid();
    }

    public Guid Id { get;  }
    public List<BackupObject> BackupObjects { get; }
}