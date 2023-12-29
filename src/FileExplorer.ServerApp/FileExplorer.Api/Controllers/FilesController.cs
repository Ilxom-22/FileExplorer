using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FilesController : ControllerBase
{
    private readonly IFileProcessingService _fileProcessingService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FilesController(IFileProcessingService fileProcessingService, IWebHostEnvironment environment)
    {
        _fileProcessingService = fileProcessingService;
        _webHostEnvironment = environment;
    }

    [HttpGet("root/files/filter")]
    public ValueTask<IActionResult> GetFilesSummary()
    {
        var result = _fileProcessingService.GetFilterDataModelAsync(_webHostEnvironment.WebRootPath);
        return new(Ok(result));
    }

    [HttpGet("root/files/by-filter")]
    public ValueTask<IActionResult> GetFilesByFilter([FromQuery] StorageFileFilterModel filterModel)
    {
        filterModel.DirectoryPath = _webHostEnvironment.WebRootPath;
        var files = _fileProcessingService.GetByFilterAsync(filterModel);
        return files.Any() ? new(Ok(files)) : new(NotFound(files));
    }
}