using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _directoryBroker;

    public DirectoryService(IDirectoryBroker directoryBroker)
    {
        _directoryBroker = directoryBroker;
    }

    public IEnumerable<StorageDirectory> GetSubDirectories(string path)
    {
       return _directoryBroker.GetSubDirectoriesInfo(path).ToList();
    }

    public StorageDirectory GetDirectoryByPath(string path)
    {
        return new StorageDirectory { Path = path};
    }
}