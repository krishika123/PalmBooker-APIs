using AutoMapper;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;

namespace KrishBookingAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserDto, AspNetUser>()
                //.ForMember(
                //    dest => dest.Password,
                //    opt => opt.MapFrom(src => $"{src.Password}")
                //)
                ;

            CreateMap<CreateUserDto, AspNetUser>()
                .ReverseMap();
                ;

            CreateMap<AspNetUser, UserDetailsDto>()
                .ForMember(src => src.Name, dst => dst.MapFrom(d => d.AspNetUserClaims.Where(x => x.ClaimType == "name").FirstOrDefault().ClaimValue))
                .ForMember(src => src.Email, dst => dst.MapFrom(d => d.AspNetUserClaims.Where(x => x.ClaimType == "email").FirstOrDefault().ClaimValue))
                //.ForMember(dest => dest.AspNetUserClaims.Where(x=>x.ClaimType=="name").FirstOrDefault().ClaimValue, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.AspNetUserClaims.Where(x => x.ClaimType == "email").FirstOrDefault().ClaimValue, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
                ;

            CreateMap<BookingDto, Booking>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.BookingId)
                ).ReverseMap();
                ;

            CreateMap<ContactDto, Contact>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.ContactId)
                ).ReverseMap();
            ;

        }
    }
}
