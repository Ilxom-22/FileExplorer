using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IFileService
{
    IEnumerable<StorageFile> GetFiles(IEnumerable<string> filesPath);

    StorageFileType GetFileType(string filePath);

    IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files);
}