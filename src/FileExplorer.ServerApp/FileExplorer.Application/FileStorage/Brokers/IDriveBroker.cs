namespace FileExplorer.Application.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<DriveInfo> GetDrives();
}