using System.IO.Compression;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;
using File = Backups.Models.RepositoryObject.File;

namespace Backups.Models.Archivator;
public interface IArchivator
{
    public string CreateArchive(string createAt, string archiveName);
    public void WriteFileToArchive(string writeTo, File fileToWrite, string relativePath, IRepository repository);
    public void WriteFolderToArchive(string writeTo, Folder folderToWrite, string relativePath, IRepository repository);

    // public void SaveArchive(IDisposable archiveToSave);
}