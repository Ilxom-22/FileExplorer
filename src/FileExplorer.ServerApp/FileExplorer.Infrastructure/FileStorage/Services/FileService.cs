using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;
    private readonly IDirectoryBroker _directoryBroker;

    public FileService(IFileBroker fileBroker, IDirectoryBroker directoryBroker)
    {
        _fileBroker = fileBroker;
        _directoryBroker = directoryBroker;
    }

    public IEnumerable<StorageFile> GetFiles(string path)
    {
        return _directoryBroker.GetFiles(path);
    }

    public IEnumerable<StorageFile> GetFilesByFilter(StorageFileFilterModel model, string path)
    {
        throw new NotImplementedException();
    }
}