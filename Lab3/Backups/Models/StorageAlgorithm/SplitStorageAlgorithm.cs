using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;
namespace Backups.Models.StorageAlgorithm;
public class SplitStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Commit(IRepository repository, IArchivator archivator, string writeTo, List<BackupObject> objectsToSave)
    {
        SplitStorage storage = new SplitStorage();
        string storagePath = storage.CreateStorage(repository, createAt: writeTo);

        List<Archive> archives = objectsToSave.Select(obj =>
        {
            Archive archive = archivator.CreateArchive(createAt: storagePath);
            var archivePath = archive.PathToArchive;

            var objectsToVisit = new List<IRepositoryObject> { obj.RepositoryObject };

            var visitor = new RepositoryObjectVisitor(archivePath, archivator, repository, objectsToVisit);
            var archiveObjects = objectsToSave.Select(obj => new ArchiveObject(obj.RepositoryObject)).ToList();
            archive.Add(archiveObjects);
            return archive;
        }).ToList();

        storage.Add(archives);
        return storage;
    }
}
