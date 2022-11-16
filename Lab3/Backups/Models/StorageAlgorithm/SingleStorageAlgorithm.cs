using Backups.Exceptions;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;

namespace Backups.Models.StorageAlgorithm;
public class SingleStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Commit(IRepository repository, IArchivator archivator, string writeTo, List<BackupObject> objectsToSave)
    {
        var archiveName = Utils.Utils.RandomString(8);
        var archivePath = archivator.CreateArchive(writeTo, archiveName);

        var visitor = new RepositoryObjectVisitor(archivePath, archivator, repository);
        objectsToSave.ForEach(obj => obj.RepositoryObject.Accept(visitor, string.Empty));

        var archiveObjects = objectsToSave.Select(obj => new ArchiveObject(obj.RepositoryObject)).ToList();
        Archive archive = new Archive(new FileInfo(archivePath), archiveObjects);

        return new SingleStorage(archive);
    }
}
