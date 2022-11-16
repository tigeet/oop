using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using Backups.Exceptions;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;

namespace Backups.Models.Archivator;
public class ZipArchivator : IArchivator
{
    public string CreateArchive(string createAt, string archiveName)
    {
        var archPath = $"{createAt}/{archiveName}.zip";  // TODO: Path.Concat

        using (var memoryStream = new MemoryStream())
        {
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
            }

            using (var fileStream = new FileStream(archPath, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
        }

        return archPath;
    }

    public void WriteFileToArchive(string writeTo, RepositoryObject.File fileToWrite, string relativePath, IRepository repository)
    {
        using (FileStream zipToOpen = new FileStream(writeTo, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                var entryPath = relativePath + "/" + fileToWrite.ObjectInfo.Name;
                ZipArchiveEntry readmeEntry = archive.CreateEntry(entryPath);  // TODO: Path.Concat
                var destSource = readmeEntry.Open();
                var sourceStream = fileToWrite.FileStream;
                byte[] buffer = new byte[2048];
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    destSource.Write(buffer, 0, bytesRead);
                sourceStream.Close();
                destSource.Close();
            }
        }
    }

    public void WriteFolderToArchive(string writeTo, Folder folderToWrite, string relativePath, IRepository repository)
    {
        using (FileStream zipToOpen = new FileStream(writeTo, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                ZipArchiveEntry readmeEntry = archive.CreateEntry(relativePath + "/" + folderToWrite.ObjectInfo.Name + "/");   // TODO: Path.Concat
            }
        }
    }
}
