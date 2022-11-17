using System;
using Backups.Models.Repository;

namespace Backups.Models.RepositoryObject;
public class Folder : IFolder
{
    private DirectoryInfo _objectInfo;
    public Folder(DirectoryInfo directoryInfo, IRepository repository)
    {
        _objectInfo = directoryInfo;
        Repository = repository;
        Name = directoryInfo.Name;
        OriginalPath = directoryInfo.FullName;
    }

    public IRepository Repository { get; }
    public Func<List<IRepositoryObject>> Objects
    {
        get { return () => Repository.ListObjects(_objectInfo.FullName); }
    }

    public string Name { get; }

    public string OriginalPath { get; }

    public void Accept(RepositoryObjectVisitor visitor, string writeTo)
    {
        visitor.VisitFolder(this, writeTo);
    }
}