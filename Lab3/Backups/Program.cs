using Backups.Models;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.StorageAlgorithm;
namespace Backups.Tests;
public static class Program
{
    public static void Main()
    {
        string path = "D:\\Desktop\\test1\\\\";
        string file1 = "2a9ace3e4304589aa94bf90d85408004.jpg";
        string file2 = "ce4f153d074ab0b301a45e121a8e2ef3.jpg";

        A(path, file1, file2);
        B(path, file1, file2);
    }

    public static void A(string path, string filepath1, string filepath2)
    {
        var file1 = new FileInfo(path + filepath1);
        var file2 = new FileInfo(path + filepath2);

        var backupObject1 = new BackupObject(file1);
        var backupObject2 = new BackupObject(file2);

        var repository = new FileSystemRepository();

        var splitStorageAlgo = new SplitStorageAlgorithm();
        var zipArchivator = new ZipArchivator();
        var backupTask = new BackupTask(path, "rep1", repository, splitStorageAlgo, zipArchivator);

        backupTask.Add(backupObject1);
        backupTask.Add(backupObject2);
        backupTask.Commit();

        backupTask.Rm(backupObject2);
        backupTask.Commit();
    }

    public static void B(string path, string filepath1, string filepath2)
    {
        var file1 = new FileInfo(path + filepath1);
        var file2 = new FileInfo(path + filepath2);

        var backupObject1 = new BackupObject(file1);
        var backupObject2 = new BackupObject(file2);

        var repository = new FileSystemRepository();

        var singleStorageAlgorithm = new SingleStorageAlgorithm();
        var zipArchivator = new ZipArchivator();
        var backupTask = new BackupTask(path, "rep2", repository, singleStorageAlgorithm, zipArchivator);

        backupTask.Add(backupObject1);
        backupTask.Add(backupObject2);
        backupTask.Commit();
    }
}