using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IFileProcessingService
{
    StorageFileFilterDataModel GetFilterDataModelAsync(string directoryPath);

    IList<StorageFile> GetByFilterAsync(StorageFileFilterModel filterModel);
}