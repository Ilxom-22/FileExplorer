using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectoriesPath(string path, FilterPagination pagination);

    IEnumerable<string> GetFilesByPath(string path, FilterPagination pagination);

    IEnumerable<StorageDirectory> GetSubDirectories(string path, FilterPagination pagination);

    StorageDirectory? GetDirectoryByPath(string path);
}