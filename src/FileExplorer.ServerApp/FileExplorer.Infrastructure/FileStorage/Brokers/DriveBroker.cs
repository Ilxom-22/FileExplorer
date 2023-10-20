using FileExplorer.Application.FileStorage.Brokers;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    public IEnumerable<DriveInfo> GetDrives() => DriveInfo.GetDrives();
    
}