using AutoMapper;
using AracKiralamaPortali.API.Dtos;
using AracKiralamaPortali.API.Models;
using AracKiralamaPortali.Dtos;
using AracKiralamaPortali.Models;

namespace AracKiralamaPortali.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Cars, CarsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
