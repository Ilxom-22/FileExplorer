using AutoMapper;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class StorageDirectoryProfile : Profile
{
    public StorageDirectoryProfile()
    {
        CreateMap<DirectoryInfo, StorageDirectory>()
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.GetFileSystemInfos().Count()))
            .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName));
    }
}