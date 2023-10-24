using FileExplorer.Application.Common;

namespace FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageFileFilterModel : FilterPagination
{
    public bool IncludeImages { get; set; }

    public bool IncludeDocuments { get; set; }

    public bool IncludeSourceCode { get; set; }
}