using AutoMapper;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;

namespace KrishBookingAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserDto, User>()
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => $"{src.Password}")
                )
                ;

            CreateMap<CreateUserDto, User>()
                .ReverseMap();
                ;

            CreateMap<UserDetailsDto, User>()
                .ForMember(
                    dest => dest.Contacts,
                    opt => opt.MapFrom(src => src.Contacts)
                ).ReverseMap();
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
