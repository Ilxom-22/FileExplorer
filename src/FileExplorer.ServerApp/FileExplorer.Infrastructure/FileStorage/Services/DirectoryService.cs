using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.Common.Querying;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _directoryBroker;

    public DirectoryService(IDirectoryBroker directoryBroker)
        => _directoryBroker = directoryBroker;
    

    public IEnumerable<StorageDirectory> GetSubDirectories(string path, FilterPagination pagination)
       => _directoryBroker.GetSubDirectoriesInfo(path).ApplyPagination(pagination).ToList();
    
    public StorageDirectory? GetDirectoryByPath(string path)
        => _directoryBroker.GetDirectoryByPath(path);
    
    public IEnumerable<string> GetDirectoriesPath(string path, FilterPagination pagination)
        => _directoryBroker.GetSubDirectoriesPath(path).ApplyPagination(pagination).ToList();

    public IEnumerable<string> GetFilesByPath(string path, FilterPagination pagination)
        => _directoryBroker.GetFilesPath(path).ApplyPagination(pagination).ToList();
}