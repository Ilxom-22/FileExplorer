namespace FileExplorer.Application.FileStorage.Models.Storage;

public class StorageDrive : IStorageEntry
{
    public required string Name { get; set; }

    public required string Path { get; set; }

    public required string Label { get; set; }

    public required string Format { get; set; }

    public required string Type { get; set; }

    public long TotalSpace { get; set; }

    public long AvailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public StorageItemType ItemType { get; set; } = StorageItemType.Drive;
}