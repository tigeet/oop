using System.IO.Compression;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;
using File = Backups.Models.RepositoryObject.File;

namespace Backups.Models.Archivator;
public interface IArchivator
{
    public Archive CreateArchive(string createAt);
    public void WriteFileToArchive(string writeTo, IFile fileToWrite, string relativePath, IRepository repository);
    public void WriteFolderToArchive(string writeTo, IFolder folderToWrite, string relativePath, IRepository repository);
}