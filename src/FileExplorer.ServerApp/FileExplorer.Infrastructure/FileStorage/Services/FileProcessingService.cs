using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileProcessingService : IFileProcessingService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public FileProcessingService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public IList<StorageFile> GetByFilterAsync(StorageFileFilterModel filterModel)
    {
        var filteredFilesPath = _directoryService.GetFilesByPath(filterModel.DirectoryPath, filterModel).Where(filePath => filterModel.FilesType.Contains(_fileService.GetFileType(filePath)));

        return _fileService.GetFiles(filteredFilesPath).ToList();
    }

    public StorageFileFilterDataModel GetFilterDataModelAsync(string directoryPath)
    {
        var pagination = new FilterPagination
        {
            PageSize = int.MaxValue,
            PageToken = 1
        };

        var filePath = _directoryService.GetFilesByPath(directoryPath, pagination);
        var files = _fileService.GetFiles(filePath);

        var filesSummary = _fileService.GetFilesSummary(files);

        var filterDataModel = new StorageFileFilterDataModel
        {
            FilterData = filesSummary.ToList()
        };

        return filterDataModel;
    }
}