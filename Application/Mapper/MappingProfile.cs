using AutoMapper;
using cars_api.Model;

namespace cars_api.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDTO>();
        }
    }
}
