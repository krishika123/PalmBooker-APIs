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
            //CreateMap<CreateBookingDto, Booking>()
            //    .ForMember(
            //        dest => dest.Payments,
            //        opt => opt.MapFrom(src => src.Payments)
            //    ).ReverseMap();
            //;
            //CreateMap<BookingDetailsDto, Booking>()
            //    .ForMember(
            //        dest => dest.Payments,
            //        opt => opt.MapFrom(src => src.Payments)
            //    )

            //    .ReverseMap();
            //;
            //CreateMap<CreatePaymentDto, Payment>()
            //    .ForMember(
            //        dest => dest.Name,
            //        opt => opt.MapFrom(src => src.MethodOfPayment)
            //    ).ReverseMap();
            //;
            //CreateMap<PaymentDto, Payment>()
            //    .ForMember(
            //        dest => dest.Name,
            //        opt => opt.MapFrom(src => src.MethodOfPayment)
            //    ).ReverseMap();
            //;

        }
    }
}