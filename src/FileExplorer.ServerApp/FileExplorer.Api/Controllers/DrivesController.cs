using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DrivesController : ControllerBase
{
    private readonly IDriveService _driveService;

    public DrivesController(IDriveService driveService)
    {
        _driveService = driveService;
    }

    [HttpGet]
    public ValueTask<IActionResult> GetDrivesAsync()
    {
        return new ValueTask<IActionResult>(Ok(_driveService.GetDrives()));
    }
}