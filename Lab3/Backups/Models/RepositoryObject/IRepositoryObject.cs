using System;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;

namespace Backups.Models;
public interface IRepositoryObject
{
    public string OriginalPath { get;  }
    public string Name { get; }
    public IRepository Repository { get; }

    public void Accept(RepositoryObjectVisitor visitor, string writeTo);
}