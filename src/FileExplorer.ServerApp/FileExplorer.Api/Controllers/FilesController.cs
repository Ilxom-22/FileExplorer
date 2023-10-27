using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FilesController(IFileService fileService, IWebHostEnvironment environment)
    {
        _fileService = fileService;
        _webHostEnvironment = environment;
    }

    [HttpPost]
    public ValueTask<IActionResult> GetFilesByFilter([FromQuery] StorageFileFilterModel filter)
    {
        return new ValueTask<IActionResult>(Ok(_fileService.GetFilesByFilter(filter, @"C:\Users\asus\OneDrive\Pictures")));
    }

    [HttpGet("root/entries/files")]
    public ValueTask<IActionResult> GetRootFiles()
    {
        return new ValueTask<IActionResult>(Ok(_fileService.GetFiles(_webHostEnvironment.WebRootPath)));
    }
}