using FileExplorer.Application.FileStorage.Models.Filtering;

namespace FileExplorer.Application.FileStorage.Models.Settings;

public class FileExtensionSettings
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public ICollection<string> Extensions { get; set; } = default!;
}