using System;
using System.IO;
using Backups.Exceptions;
using Backups.Models.RepositoryObject;
using File = Backups.Models.RepositoryObject.File;

namespace Backups.Models.Repository;
public class FileSystemRepository : IRepository
{
    public Guid Id { get; }
    public IRepositoryObject CreateRepositoryObject(string objectPath)
    {
        FileAttributes attr = System.IO.File.GetAttributes(objectPath);

        if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            return new Folder(new DirectoryInfo(objectPath), this);

        return new File(new FileInfo(objectPath), this);
    }

    public FileStream OpenFileStream(string getFrom)
    {
        var fileinfo = new FileInfo(getFrom);
        return System.IO.File.OpenRead(fileinfo.FullName);
    }

    public void CloseFileStream(FileStream fileStream)
    {
        fileStream.Close();
    }

    public List<IRepositoryObject> ListObjects(string listFrom)
    {
        var filePathes = Directory.GetDirectories(listFrom, "*", SearchOption.TopDirectoryOnly);
        var folderPathes = Directory.GetFiles(listFrom, "*", SearchOption.TopDirectoryOnly);
        var combinedPathes = filePathes.Concat(folderPathes);
        return combinedPathes.Select(path => CreateRepositoryObject(path)).ToList();
    }

    public string CreateDirectory(string makeAt, string folderName)
    {
        var dirPath = Path.Combine(makeAt, folderName);
        Directory.CreateDirectory(dirPath);
        return dirPath;
    }
}