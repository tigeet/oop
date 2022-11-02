using System.Diagnostics;
using System.IO.Compression;
using Backups.Exceptions;
using Backups.Models.Repository;
namespace Backups.Models.Archivator;
public class ZipArchivator : IArchivator
{
    public string CreateArchive(string path, string name)
    {
        var memoryStream = new MemoryStream();
        var fileStream = new FileStream(path + "\\" + name + ".zip", FileMode.Create);
        memoryStream.Seek(0, SeekOrigin.Begin);
        memoryStream.CopyTo(fileStream);

        fileStream.Close();
        memoryStream.Close();
        return path + "\\" + name + ".zip";
    }

    public void Write(string path, List<Storage> storages, IRepository repository)
    {
        storages.ForEach(storage =>
        {
            string archivePath = CreateArchive(path, storage.Id.ToString());
            Write(archivePath, storage, repository);
        });
    }

    public void Write(string path, Storage storage, IRepository repository)
    {
        storage.BackupObjects.ForEach(backupObject => Write(path, backupObject, repository));
    }

    private void Write(string archivePath, BackupObject backupObject, IRepository repository)
    {
       try
        {
            using (var zipToOpen = new FileStream(archivePath, FileMode.Open))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    string filename = backupObject.File.Name + (backupObject.IsDirectory ? "/" : string.Empty);
                    ZipArchiveEntry readmeEntry = archive.CreateEntry(filename);

                    if (backupObject.IsDirectory)
                        return;

                    using (var writer = new BinaryWriter(readmeEntry.Open()))
                    {
                        byte[] content = repository.ReadBytes(backupObject.File.FullName);
                        writer.Write(content);
                    }
                }
            }
        }
        catch
        {
            throw new MemoryException("Failed to write to zip archive");
        }
    }
}
