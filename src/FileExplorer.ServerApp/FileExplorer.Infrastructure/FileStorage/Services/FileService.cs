using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Settings;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.Extensions.Options;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;
    private readonly IDirectoryBroker _directoryBroker;
    private readonly FileExtensions _fileExtensions;

    public FileService(IFileBroker fileBroker, IDirectoryBroker directoryBroker, IOptionsSnapshot<FileExtensions> fileExtensions)
    {
        _fileBroker = fileBroker;
        _directoryBroker = directoryBroker;
        _fileExtensions = fileExtensions.Value;
    }

    public IEnumerable<StorageFile> GetFiles(string path)
    {
        return _directoryBroker.GetFiles(path);
    }

    public IEnumerable<StorageFile> GetFilesByFilter(StorageFileFilterModel model, string path)
    {
        var result = GetFilteredFiles(model, path);

        return result.Skip((model.PageToken - 1) * model.PageSize).Take(model.PageSize);
    }
    

    private IEnumerable<StorageFile> GetFilteredFiles(StorageFileFilterModel model, string path) 
    {
        var files = _directoryBroker.GetFiles(path);
        var selectedFiles = new List<StorageFile>();

        selectedFiles.AddRange(files.Where(file =>
           (model.IncludeDocuments && _fileExtensions.DocumentExtensions.Contains(file.Extension)) ||
           (model.IncludeImages && _fileExtensions.ImageExtensions.Contains(file.Extension)) ||
           (model.IncludeSourceCode && _fileExtensions.SourceCodeExtensions.Contains(file.Extension))));

        foreach (var directory in _directoryBroker.GetSubDirectories(path))
        {
            selectedFiles.AddRange(GetFilteredFiles(model, directory));
        }

        return selectedFiles;
    }
}