using FileExplorer.Application.FileStorage.Brokers;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    public IEnumerable<string> GetSubDirectories(string path) => Directory.GetDirectories(path);

    public IEnumerable<DirectoryInfo> GetSubDirectoriesInfo(string path) => new DirectoryInfo(path).EnumerateDirectories();

    public IEnumerable<FileInfo> GetFiles(string path) => new DirectoryInfo(path).EnumerateFiles();
}