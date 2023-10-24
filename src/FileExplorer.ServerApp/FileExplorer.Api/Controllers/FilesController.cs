using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public ValueTask<IActionResult> GetFilesByFilter()
    {
        throw new NotImplementedException();
    }

    [HttpGet("root/entries/files")]
    public ValueTask<IActionResult> GetRootFiles([FromServices] IWebHostEnvironment environment)
    {
        return new ValueTask<IActionResult>(Ok(_fileService.GetFiles(environment.WebRootPath)));
    }
}