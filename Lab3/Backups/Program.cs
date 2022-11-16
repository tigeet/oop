using Backups.Models;
using Backups.Models.Archivator;
using Backups.Models.Repository;
using Backups.Models.StorageAlgorithm;
namespace Backups.Tests;
public static class Program
{
    public static void Main()
    {
        string path = "/Users/koido/Desktop/source/";
        string file2 = path + "photo2.jpg";
        string file1 = path + "photo1.jpeg";
        string folder1 = path + "folder/";

        // A(path, file1, file2, folder1);
        B(path, file1, file2, folder1);
    }

    private static void A(string path, string filepath1, string filepath2, string folder1)
    {
        string mountAt = "/Users/koido/Desktop/backup/";
        var storageAlgorithm = new SingleStorageAlgorithm();
        var repository = new FileSystemRepository();
        var archivator = new ZipArchivator();
        var backupTask = new BackupTask(mountAt, "backupname", repository, storageAlgorithm, archivator);

        var backupObj1 = backupTask.Add(filepath1);
        var backupObj2 = backupTask.Add(filepath2);
        var backupObj3 = backupTask.Add(folder1);

        backupTask.Commit();

        backupTask.Rm(backupObj1);
        backupTask.Rm(backupObj3);
        backupTask.Commit();
    }

    private static void B(string path, string filepath1, string filepath2, string folder1)
    {
        string mountAt = "/Users/koido/Desktop/backup/";
        var storageAlgorithm = new SplitStorageAlgorithm();
        var repository = new FileSystemRepository();
        var archivator = new ZipArchivator();
        var backupTask = new BackupTask(mountAt, "backupname", repository, storageAlgorithm, archivator);

        backupTask.Add(filepath1);
        backupTask.Add(filepath2);
        backupTask.Add(folder1);

        backupTask.Commit();
    }
}