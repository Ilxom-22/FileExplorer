﻿using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    public IEnumerable<StorageDrive> GetDrives();
}