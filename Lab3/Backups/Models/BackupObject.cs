using Backups.Models.Repository;

namespace Backups.Models;

public class BackupObject
{
    public BackupObject(FileSystemInfo file, IRepository repository)
    {
        Id = Guid.NewGuid();
        File = file;
        Repository = repository;
        RepositoryObject = Repository.CreateRepositoryObject(file.FullName);
    }

    public Guid Id { get; }
    public FileSystemInfo File { get; }
    public IRepositoryObject RepositoryObject { get; }
    public IRepository Repository { get; }
}