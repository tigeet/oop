using System;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;
using File = Backups.Models.RepositoryObject.File;

namespace Backups.Models;
public class RepositoryObjectVisitor
{
    public RepositoryObjectVisitor(string archPath, IArchivator archivator, IRepository repository, List<IRepositoryObject> objectsToVisit)
    {
        ArchivePath = archPath;
        Archivator = archivator;
        Repository = repository;
        objectsToVisit.ForEach(obj => obj.Accept(this, string.Empty));
    }

    private IRepository Repository { get; }
    private IArchivator Archivator { get; }
    private string ArchivePath { get; }

    public void VisitFile(IFile file, string writeTo)
    {
        Archivator.WriteFileToArchive(ArchivePath, file, writeTo, Repository);
    }

    public void VisitFolder(IFolder folder, string writeTo)
    {
        Archivator.WriteFolderToArchive(ArchivePath, folder, writeTo, Repository);
        folder.Objects().ForEach(obj =>
        {
            string pathToObj = Path.Combine(writeTo, folder.Name);
            obj.Accept(this, pathToObj);
        });
    }
}