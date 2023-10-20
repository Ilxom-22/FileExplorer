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
        var paths = _directoryBroker.GetSubDirectoriesInfo(path).ToList();

        var directories = paths.Select(path => new StorageDirectory()
        {
            Name = path.Name,
            Path = path.FullName,
            ItemsCount = path.GetFileSystemInfos().Count()
        });

        return directories;
    }

    public IEnumerable<StorageFile> GetFiles(string path)
    {
        var paths = _directoryBroker.GetFiles(path);

        return paths.Select(path => new StorageFile()
        {
            Name = path.Name,
            Path = path.FullName,
            DirectoryPath = path.DirectoryName,
            Extension = path.Extension,
            Size = path.Length / 1024
        });
    }

    public StorageDirectory GetDirectoryByPath(string path)
    {
        return new StorageDirectory { Path = path};
    }
}