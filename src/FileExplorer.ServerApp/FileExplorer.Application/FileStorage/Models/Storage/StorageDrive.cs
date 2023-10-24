namespace FileExplorer.Application.FileStorage.Models.Storage;

public class StorageDrive : IStorageEntry
{
    public required string Name { get; set; }

    public string Label { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public long TotalSpace { get; set; }

    public long FreeSpace { get; set; }

    public long UnavailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public StorageItemType ItemType { get; set; } = StorageItemType.Drive;
}