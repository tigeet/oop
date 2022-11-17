using System;
using Backups.Models.Repository;

namespace Backups.Models.RepositoryObject;
public class File : IFile
{
    private FileInfo _fileInfo;

    public File(FileInfo objectInfo, IRepository repository)
    {
        _fileInfo = objectInfo;
        Name = objectInfo.Name;
        Repository = repository;
        OriginalPath = objectInfo.FullName;
    }

    public IRepository Repository { get; }

    public FileStream FileStream { get { return Repository.OpenFileStream(_fileInfo.FullName); } }

    public string Name { get; }

    public string OriginalPath { get; }

    public void Accept(RepositoryObjectVisitor visitor, string writeTo)
    {
        visitor.VisitFile(this, writeTo);
    }
}