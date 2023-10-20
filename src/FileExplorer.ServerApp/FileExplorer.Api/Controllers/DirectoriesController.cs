using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;
    private readonly IDirectoryService _directoryService;
    private readonly IDriveService _driveService;

    public DirectoriesController(IDirectoryProcessingService directoryProcessingService, IDirectoryService directoryService, IDriveService driveService)
    {
        _directoryProcessingService = directoryProcessingService;
        _directoryService = directoryService;
        _driveService = driveService;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync([FromServices] IWebHostEnvironment environment)
    {
        return Ok(await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath));
    }

    [HttpGet("root/entries/files")]
    public async ValueTask<IActionResult> GetRootFiles([FromServices] IWebHostEnvironment environment)
    {
        return Ok(_directoryService.GetFiles(environment.WebRootPath));
    }

    [HttpGet("root/entries/directories")]
    public async ValueTask<IActionResult> GetRootDirectories([FromServices] IWebHostEnvironment environment)
    {
        return Ok(_directoryService.GetSubDirectories(environment.WebRootPath));
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetDirectoryEntriesByPathAsync(string directoryPath)
    {
        return Ok(await _directoryProcessingService.GetEntriesAsync(directoryPath));
    }

    [HttpGet("drives")]
    public async ValueTask<IActionResult> GetDrivesAsync()
    {
        return Ok(_driveService.GetDrives());
    }
}