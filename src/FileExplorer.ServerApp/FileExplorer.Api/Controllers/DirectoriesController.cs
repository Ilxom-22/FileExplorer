using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;
    private readonly IDirectoryService _directoryService;

    public DirectoriesController(IDirectoryProcessingService directoryProcessingService, IDirectoryService directoryService)
    {
        _directoryProcessingService = directoryProcessingService;
        _directoryService = directoryService;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync([FromServices] IWebHostEnvironment environment)
    {
        return Ok(await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath));
    }

    [HttpGet("root/entries/directories")]
    public ValueTask<IActionResult> GetRootDirectories([FromServices] IWebHostEnvironment environment)
    {
        return new ValueTask<IActionResult>(Ok(_directoryService.GetSubDirectories(environment.WebRootPath)));
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetDirectoryEntriesByPathAsync(string directoryPath)
    {
        return Ok(await _directoryProcessingService.GetEntriesAsync(directoryPath));
    }
}