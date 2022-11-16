using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.Storage;
namespace Backups.Models.StorageAlgorithm;
public class SplitStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Commit(IRepository repository, IArchivator archivator, string writeTo, List<BackupObject> objectsToSave)
    {
        List<Archive> archives = objectsToSave.Select(obj =>
        {
            var archiveName = Utils.Utils.RandomString(8);
            var archivePath = archivator.CreateArchive(writeTo, archiveName);

            var visitor = new RepositoryObjectVisitor(archivePath, archivator, repository);
            obj.RepositoryObject.Accept(visitor, string.Empty);

            var archiveObjects = objectsToSave.Select(obj => new ArchiveObject(obj.RepositoryObject)).ToList();
            Archive archive = new Archive(new FileInfo(archivePath), archiveObjects);
            return archive;
        }).ToList();

        SplitStorage storage = new SplitStorage(archives);
        return storage;
    }
}
