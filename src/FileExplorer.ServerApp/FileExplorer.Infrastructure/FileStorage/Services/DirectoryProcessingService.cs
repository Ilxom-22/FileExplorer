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

    public ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath)
    {
        var storageItems = new List<IStorageEntry>();

        storageItems.AddRange(_directoryService.GetSubDirectories(directoryPath));
        storageItems.AddRange(_directoryService.GetFiles(directoryPath));

        return new ValueTask<List<IStorageEntry>>(storageItems);
    }
}