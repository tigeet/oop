namespace Backups.Models.StorageAlgorithm;
public class SingleStorageAlgorithm : IStorageAlgorithm
{
    public List<Storage> MapObjectsToStorages(List<BackupObject> objects)
    {
        var storage = new Storage(objects.ToArray());
        return new List<Storage> { storage };
    }

    public List<BackupObject> MapStoragesToObjects(List<Storage> storages)
    {
        return storages.SelectMany(storage => storage.BackupObjects).ToList();
    }
}
