using System;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;

namespace Backups.Models;
public interface IRepositoryObject
{
    public FileSystemInfo ObjectInfo { get; }
    public IRepository Repository { get; }

    public void Accept(RepositoryObjectVisitor visitor, string writeTo);
}