using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _driveBroker;

    public DriveService(IDriveBroker driveBroker)
    {
        _driveBroker = driveBroker;
    }

    public IEnumerable<StorageDrive> GetDrives()
    {
        var drives = _driveBroker.GetDrives();

        return drives;
    }
}