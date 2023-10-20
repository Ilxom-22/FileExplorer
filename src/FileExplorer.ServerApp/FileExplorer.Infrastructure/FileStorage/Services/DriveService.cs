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

        var storagDrives = drives.Select(drive => new StorageDrive
        {
            Name = drive.VolumeLabel,
            Path = drive.RootDirectory.FullName,
            AvailableSpace = drive.AvailableFreeSpace / 1024 / 1024 / 1024,
            Format = drive.DriveFormat,
            Label = drive.Name,
            Type = drive.DriveType.ToString(),
            TotalSpace = drive.TotalSize / 1024 / 1024 / 1024,
            UsedSpace = (drive.TotalSize - drive.TotalFreeSpace) / 1024 / 1024 / 1024
        });

        return storagDrives;
    }
}