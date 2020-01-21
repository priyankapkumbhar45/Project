using System.Linq;
using AutoMapper;
using DatingApplicationAPI.API.Dtos;
using DatingApplicationAPI.API.Models;

namespace DatingApplicationAPI.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
            .ForMember(dest => dest.PhotoUrl, 
            opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain)))
            .ForMember(dest => dest.Age, 
            op => op.MapFrom(src => src.DateOfBirth.CalculateAge()));
           
            CreateMap<User, UserForDetailedDTO>().ForMember(dest => dest.PhotoUrl, 
            opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain)))
            .ForMember(dest => dest.Age, 
            op => op.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDTO>();
        }
    }
}