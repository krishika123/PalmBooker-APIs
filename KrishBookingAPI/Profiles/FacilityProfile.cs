using AutoMapper;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;

namespace KrishBookingAPI.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<CreateFacilityDto, Facility>()
                .ReverseMap()
                ;
            
            CreateMap<UpdateFacilityDto, Facility>()
               .ForMember(
                   dest => dest.RatePerHour,
                   opt => opt.MapFrom(src => $"{src.RatePerHour}")
               )
               ;
           
        }
    }
}