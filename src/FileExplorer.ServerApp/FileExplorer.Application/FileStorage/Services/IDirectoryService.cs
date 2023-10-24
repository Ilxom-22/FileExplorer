﻿using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    IEnumerable<StorageDirectory> GetSubDirectories(string path);
    StorageDirectory GetDirectoryByPath(string path);
}