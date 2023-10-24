using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetSubDirectories(string path);
    IEnumerable<StorageDirectory> GetSubDirectoriesInfo(string path);  
    IEnumerable<StorageFile> GetFiles(string path);
}