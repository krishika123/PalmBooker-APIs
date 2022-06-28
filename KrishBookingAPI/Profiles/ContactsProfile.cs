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
                .ReverseMap()
                ;

        }
    }
}