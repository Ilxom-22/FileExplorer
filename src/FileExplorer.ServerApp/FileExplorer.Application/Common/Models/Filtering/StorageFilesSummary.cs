using FileExplorer.Application.FileStorage.Models.Filtering;

namespace FileExplorer.Application.Common.Models.Filtering;

public class StorageFilesSummary : FilterPagination
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = default!;

    public long Count { get; set; }

    public long Size { get; set; }

    public string ImageUrl { get; set; } = default!;
}