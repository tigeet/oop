using System;
using Backups.Models.Repository;

namespace Backups.Models.RepositoryObject
{
    public interface IFolder : IRepositoryObject
    {
        public Func<List<IRepositoryObject>> Objects { get; }
    }
}