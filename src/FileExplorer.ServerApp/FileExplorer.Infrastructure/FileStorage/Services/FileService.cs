using FileExplorer.Application.Common.Models.Filtering;
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
    private readonly FileStorageSettings _fileStorageSettings;
    private readonly FileFilterSettings _fileFilterSettings;

    public FileService(IFileBroker fileBroker, IOptionsSnapshot<FileStorageSettings> fileStorageSettins, IOptionsSnapshot<FileFilterSettings> fileFilterSettings)
    {
        _fileBroker = fileBroker;
        _fileStorageSettings = fileStorageSettins.Value;
        _fileFilterSettings = fileFilterSettings.Value;
    }

    public IEnumerable<StorageFile> GetFiles(IEnumerable<string> filesPath)
        => filesPath.Select(_fileBroker.GetFileByPath);

    public StorageFile GetFileByPath(string filePath)
        => _fileBroker.GetFileByPath(filePath);

    public IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files)
    {
        var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));

        return filesType
            .GroupBy(file => file.Type)
            .Select(files => new StorageFilesSummary
            {
                FileType = files.Key,
                DisplayName = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == files.Key)?.DisplayName ?? "Other files",
                Count = files.Count(),
                Size = files.Sum(file => file.File.Size),
                ImageUrl = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == files.Key)?.ImageUrl ?? _fileStorageSettings.FileImageUrl
            });
    }

    public StorageFileType GetFileType(string filePath)
    {
        var fileExtension = Path.GetExtension(filePath).TrimStart('.');

        var matchedFileType = _fileFilterSettings.FileExtensions.FirstOrDefault(extensionSettings => extensionSettings.Extensions.Contains(fileExtension));

        return matchedFileType?.FileType ?? StorageFileType.Other;
    }
}