namespace FileExplorer.Application.FileStorage.Models.Storage;

public interface IStorageEntry
{
    string Name { get; set; }

    string Path { get; set; }

    StorageEntryType EntryType { get; set; }
}