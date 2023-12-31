using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Settings;
using FileExplorer.Application.FileStorage.Services;
using FileExplorer.Infrastructure.FileStorage.Brokers;
using FileExplorer.Infrastructure.FileStorage.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

var assemblies = Assembly
    .GetExecutingAssembly() 
    .GetReferencedAssemblies() 
    .Select(Assembly.Load)
    .ToList();

assemblies.Add(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(assemblies);

builder.Services.AddScoped<IDirectoryProcessingService, DirectoryProcessingService>();
builder.Services.AddScoped<IDirectoryService, DirectoryService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileProcessingService, FileProcessingService>();
builder.Services.AddScoped<IDirectoryBroker, DirectoryBroker>();
builder.Services.AddScoped<IFileBroker, FileBroker>();
builder.Services.AddScoped<IDriveBroker, DriveBroker>();
builder.Services.AddScoped<IDriveService, DriveService>();

builder.Services.Configure<FileExtensionSettings>(builder.Configuration.GetSection(nameof(FileExtensionSettings)));
builder.Services.Configure<FileFilterSettings>(builder.Configuration.GetSection(nameof(FileFilterSettings)));
builder.Services.Configure<FileStorageSettings>(builder.Configuration.GetSection(nameof(FileStorageSettings)));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.MapControllers();

app.Run();