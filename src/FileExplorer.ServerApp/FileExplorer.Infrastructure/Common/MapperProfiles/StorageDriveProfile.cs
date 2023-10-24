using AutoMapper;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class StorageDriveProfile : Profile
{
    public StorageDriveProfile()
    {
        CreateMap<DriveInfo, StorageDrive>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.VolumeLabel))
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name.Substring(0, src.Name.IndexOf(':'))))
            .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FreeSpace, opt => opt.MapFrom(src => src.AvailableFreeSpace))
            .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.DriveFormat))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.DriveType))
            .ForMember(dest => dest.TotalSpace, opt => opt.MapFrom(src => src.TotalSize))
            .ForMember(src => src.UnavailableSpace, opt => opt.MapFrom(dest => dest.TotalFreeSpace - dest.AvailableFreeSpace))
            .ForMember(src => src.UsedSpace, opt => opt.MapFrom(dest => dest.TotalSize - dest.TotalFreeSpace));
    }
}