namespace Backups.Models.StorageAlgorithm;
public class SplitStorageAlgorithm : IStorageAlgorithm
{
    public List<Storage> MapObjectsToStorages(List<BackupObject> objects)
    {
        return objects.Select(obj => new Storage(obj)).ToList();
    }

    public List<BackupObject> MapStoragesToObjects(List<Storage> storages)
    {
        return storages.Select(storage => storage.BackupObjects.First()).ToList();
    }
}
