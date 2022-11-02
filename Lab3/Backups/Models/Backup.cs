namespace Backups.Models;
public class Backup
{
    private List<RestorePoint> _restorePoints = new List<RestorePoint>();
    public List<RestorePoint> RestorePoints { get { return _restorePoints; } }

    public RestorePoint AddRestorePoint(RestorePoint restorePoint)
    {
        _restorePoints.Add(restorePoint);
        return restorePoint;
    }
}