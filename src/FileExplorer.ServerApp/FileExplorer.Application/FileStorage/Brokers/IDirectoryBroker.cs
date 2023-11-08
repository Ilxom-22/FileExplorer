using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetSubDirectoriesPath(string path);

    IEnumerable<string> GetFilesPath(string path);

    IEnumerable<StorageDirectory> GetSubDirectoriesInfo(string path);

    StorageDirectory GetDirectoryByPath(string path);

    IEnumerable<StorageFile> GetFiles(string path);
}