using AutoMapper;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class StorageFileProfile : Profile
{
    public StorageFileProfile()
    {
        CreateMap<FileInfo, StorageFile>()
            .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.DirectoryPath, opt => opt.MapFrom(src => src.DirectoryName))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length));
    }
}