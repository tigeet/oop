using Backups.Models;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.StorageAlgorithm;
using Xunit;

namespace Backups.Tests;
public class Entrance
{
    [Theory]
    public void A(string path, string filepath1, string filepath2)
    {
        var file1 = new FileInfo(path + filepath1);
        var file2 = new FileInfo(path + filepath2);

        var backupObject1 = new BackupObject(file1);
        var backupObject2 = new BackupObject(file2);

        var repository = new FileSystemRepository(path);

        var splitStorageAlgo = new SplitStorageAlgorithm();
        var zipArchivator = new ZipArchivator();
        var backupTask = new BackupTask(path, "rep1", repository, splitStorageAlgo, zipArchivator);

        backupTask.Add(backupObject1);
        backupTask.Add(backupObject2);
        backupTask.Commit();

        backupTask.Rm(backupObject2);
        backupTask.Commit();
    }

    [Theory]
    public void B(string path, string filepath1, string filepath2)
    {
        var file1 = new FileInfo(path + filepath1);
        var file2 = new FileInfo(path + filepath2);

        var backupObject1 = new BackupObject(file1);
        var backupObject2 = new BackupObject(file2);

        var repository = new FileSystemRepository(path);

        var singleStorageAlgorithm = new SingleStorageAlgorithm();
        var zipArchivator = new ZipArchivator();
        var backupTask = new BackupTask(path, "rep2", repository, singleStorageAlgorithm, zipArchivator);

        backupTask.Add(backupObject1);
        backupTask.Add(backupObject2);
        backupTask.Commit();
    }
}