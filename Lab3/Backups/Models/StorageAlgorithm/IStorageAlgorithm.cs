namespace Backups.Models.StorageAlgorithm;
public interface IStorageAlgorithm
{
    public List<Storage> MapObjectsToStorages(List<BackupObject> objects);
    public List<BackupObject> MapStoragesToObjects(List<Storage> storages);
}