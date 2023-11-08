using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public DirectoryProcessingService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel)
    {
        var storageItems = new List<IStorageEntry>();

        if (filterModel.IncludeDirectories)
            storageItems.AddRange(_directoryService.GetSubDirectories(directoryPath, filterModel));

        if (filterModel.IncludeFiles)
            storageItems.AddRange(_fileService.GetFiles(_directoryService.GetFilesByPath(directoryPath, filterModel)));

        return new ValueTask<List<IStorageEntry>>(storageItems);
    }
}