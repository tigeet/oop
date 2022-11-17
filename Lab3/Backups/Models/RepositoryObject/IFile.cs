using System;
using Backups.Models.Repository;

namespace Backups.Models.RepositoryObject
{
    public interface IFile : IRepositoryObject
    {
        public FileStream FileStream { get; }
    }
}