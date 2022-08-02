using AutoMapper;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;

namespace KrishBookingAPI.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<CreateContactDto, Contact>()
                //.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap()
                ;
            CreateMap<ContactDetailsDto, Contact>()
                //.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap()
                ;


            CreateMap<AspNetUser, ContactUserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AspNetUserClaims.FirstOrDefault(c => c.ClaimType == "name").ClaimValue))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AspNetUserClaims.FirstOrDefault(c => c.ClaimType == "email").ClaimValue))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            ;
        }
    }
}