namespace Backups.Models;

public class BackupObject
{
    public BackupObject(FileSystemInfo file)
    {
        Id = Guid.NewGuid();
        File = file;
    }

    public Guid Id { get; }
    public FileSystemInfo File { get;  }
    public bool IsDirectory
    {
        get
        {
            return File.Extension == string.Empty;
        }
    }
}