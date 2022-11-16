using System;
using System.IO.Compression;
using Backups.Models.RepositoryObject;

namespace Backups.Models;
public class ArchiveObject
{
    public ArchiveObject(IRepositoryObject repositoryObject)
    {
        RepositoryObject = repositoryObject;
        Name = repositoryObject.ObjectInfo.Name;
    }

    public IRepositoryObject RepositoryObject { get; }
    public string Name { get; }
}