using Backups.Exceptions;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;

namespace Backups.Models.StorageAlgorithm;
public class SingleStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Commit(IRepository repository, IArchivator archivator, string writeTo, List<BackupObject> objectsToSave)
    {
        SingleStorage storage = new SingleStorage();
        var storagePath = storage.CreateStorage(repository, writeTo);

        Archive archive = archivator.CreateArchive(createAt: storagePath);
        var archivePath = archive.PathToArchive;

        var objectsToVisit = objectsToSave.Select(obj => obj.RepositoryObject).ToList();
        var visitor = new RepositoryObjectVisitor(archivePath, archivator, repository, objectsToVisit);

        var archiveObjects = objectsToSave.Select(obj => new ArchiveObject(obj.RepositoryObject)).ToList();
        archive.Add(archiveObjects);
        storage.Archive = archive;
        return storage;
    }
}
