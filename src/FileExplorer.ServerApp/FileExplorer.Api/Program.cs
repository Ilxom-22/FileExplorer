using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Services;
using FileExplorer.Infrastructure.FileStorage.Brokers;
using FileExplorer.Infrastructure.FileStorage.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDirectoryProcessingService, DirectoryProcessingService>();
builder.Services.AddScoped<IDirectoryService, DirectoryService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IDirectoryBroker, DirectoryBroker>();
builder.Services.AddScoped<IFileBroker, FileBroker>();
builder.Services.AddScoped<IDriveBroker, DriveBroker>();
builder.Services.AddScoped<IDriveService, DriveService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.MapControllers();

app.Run();