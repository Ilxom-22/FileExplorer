using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IFileService
{
    IEnumerable<StorageFile> GetFiles(string path);

    IEnumerable<StorageFile> GetFilesByFilter(StorageFileFilterModel model, string path);
}