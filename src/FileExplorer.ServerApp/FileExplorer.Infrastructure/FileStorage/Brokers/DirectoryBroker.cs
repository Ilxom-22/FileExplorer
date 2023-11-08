using AutoMapper;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    private readonly IMapper _mapper;

    public DirectoryBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<string> GetSubDirectoriesPath(string path) => Directory.EnumerateDirectories(path);

    public IEnumerable<string> GetFilesPath(string path) => Directory.EnumerateFiles(path);

    public IEnumerable<StorageDirectory> GetSubDirectoriesInfo(string path) 
        => new DirectoryInfo(path)
            .EnumerateDirectories()
            .Select(_mapper.Map<StorageDirectory>);

    public StorageDirectory GetDirectoryByPath(string path) => _mapper.Map<StorageDirectory>(new DirectoryInfo(path));

    public IEnumerable<StorageFile> GetFiles(string path) => new DirectoryInfo(path).EnumerateFiles().Select(_mapper.Map<StorageFile>);
}