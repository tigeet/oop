using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using Backups.Exceptions;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;

namespace Backups.Models.Archivator;
public class ZipArchivator : IArchivator
{
    public Archive CreateArchive(string createAt)
    {
        string archName = $"{Utils.Utils.RandomString(8)}.zip";
        string archPath = Path.Combine(createAt, archName);
        using (var memoryStream = new MemoryStream())
        {
            using (var fileStream = new FileStream(archPath, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
        }

        return new Archive(name: archName, locatedAt: createAt);
    }

    public void WriteFileToArchive(string writeTo, RepositoryObject.IFile fileToWrite, string relativePath, IRepository repository)
    {
        using (FileStream zipToOpen = new FileStream(writeTo, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                var entryPath = Path.Combine(relativePath, fileToWrite.Name);
                ZipArchiveEntry readmeEntry = archive.CreateEntry(entryPath);
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

    public void WriteFolderToArchive(string writeTo, IFolder folderToWrite, string relativePath, IRepository repository)
    {
        using (FileStream zipToOpen = new FileStream(writeTo, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                string entryPath = Path.Combine(relativePath, folderToWrite.Name, Path.DirectorySeparatorChar.ToString());
                ZipArchiveEntry readmeEntry = archive.CreateEntry(entryPath);
            }
        }
    }
}
