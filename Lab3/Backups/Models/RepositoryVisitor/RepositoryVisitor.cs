using System;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.RepositoryObject;
using File = Backups.Models.RepositoryObject.File;

namespace Backups.Models;
public class RepositoryObjectVisitor
{
    public RepositoryObjectVisitor(string archPath, IArchivator archivator, IRepository repository)
    {
        ArchivePath = archPath;
        Archivator = archivator;
        Repository = repository;
    }

    private IRepository Repository { get; }
    private IArchivator Archivator { get; }
    private string ArchivePath { get; }
    public void VisitFile(File file, string writeTo)
    {
        Archivator.WriteFileToArchive(ArchivePath, file, writeTo, Repository);
    }

    public void VisitFolder(Folder folder, string writeTo)
    {
        Archivator.WriteFolderToArchive(ArchivePath, folder, writeTo, Repository);
        folder.Objects().ForEach(obj => obj.Accept(this, writeTo + "/" + folder.ObjectInfo.Name));  // TODO: Path.Concat
    }
}