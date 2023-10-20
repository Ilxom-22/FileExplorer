namespace FileExplorer.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetSubDirectories(string path);
    IEnumerable<DirectoryInfo> GetSubDirectoriesInfo(string path);  
    IEnumerable<FileInfo> GetFiles(string path);
}