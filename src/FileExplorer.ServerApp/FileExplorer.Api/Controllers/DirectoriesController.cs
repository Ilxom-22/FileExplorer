using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;

    public DirectoriesController(IDirectoryProcessingService directoryProcessingService)
    {
        _directoryProcessingService = directoryProcessingService;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync([FromQuery] StorageDirectoryEntryFilterModel filterModel, [FromServices] IWebHostEnvironment environment)
    {
        var result = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetDirectoryEntriesByPathAsync([FromRoute] string directoryPath, [FromQuery] StorageDirectoryEntryFilterModel filterModel)
    {
        var result = await _directoryProcessingService.GetEntriesAsync(directoryPath, filterModel);

        return result.Any() ? Ok(result) : NoContent();
    }
}