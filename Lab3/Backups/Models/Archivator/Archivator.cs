using Backups.Models.Repository;

namespace Backups.Models.Archivator;
public interface IArchivator
{
    public void Write(string path, List<Storage> storages, IRepository repository);
    public string CreateArchive(string path, string name);
}