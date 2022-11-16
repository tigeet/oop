using System;
using Backups.Models.Repository;

namespace Backups.Models.RepositoryObject;
public class File : IRepositoryObject
{
    private FileInfo _fileInfo;

    public File(FileInfo objectInfo, IRepository repository)
    {
        _fileInfo = objectInfo;
        Repository = repository;
    }

    public FileSystemInfo ObjectInfo { get { return _fileInfo; } }
    public IRepository Repository { get; }

    public FileStream FileStream { get { return Repository.OpenFileStream(_fileInfo); } }
    public void Accept(RepositoryObjectVisitor visitor, string writeTo)
    {
        visitor.VisitFile(this, writeTo);
    }
}