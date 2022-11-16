using Backups.Exceptions;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;

namespace Backups.Models.StorageAlgorithm;
public interface IStorageAlgorithm
{
    public IStorage Commit(IRepository repository, IArchivator archivator, string writeTo, List<BackupObject> objectsToSave);
}