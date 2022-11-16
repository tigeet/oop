using System;
using Backups.Models.Repository;

namespace Backups.Models.RepositoryObject;
public class Folder : IRepositoryObject
{
    public Folder(DirectoryInfo directoryInfo, IRepository repository)
    {
        ObjectInfo = directoryInfo;
        Repository = repository;
    }

    public FileSystemInfo ObjectInfo { get; }
    public IRepository Repository { get; }

    // public List<IRepositoryObject> Objects { get { return Repository.ListObjects(ObjectInfo.FullName); } }
    public Func<List<IRepositoryObject>> Objects
    {
        get { return () => Repository.ListObjects(ObjectInfo.FullName); }
    }

    public void Accept(RepositoryObjectVisitor visitor, string writeTo)
    {
        visitor.VisitFolder(this, writeTo);
    }
}