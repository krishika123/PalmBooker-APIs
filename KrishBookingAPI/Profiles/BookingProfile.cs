﻿using AutoMapper;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;

namespace KrishBookingAPI.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<UpdateBookingDto, Booking>()
                .ForMember(
                    dest => dest.AdditionalInfo,
                    opt => opt.MapFrom(src => $"{src.AddInfo}")
                )
                ;
            CreateMap<CreateBookingDto, Booking>()
                .ForMember(
                    dest => dest.Payments,
                    opt => opt.MapFrom(src =>  src.Payments)
                ).ReverseMap();
            ;
            CreateMap<BookingDetailsDto, Booking>()
                .ForMember(
                    dest => dest.Payments,
                    opt => opt.MapFrom(src =>  src.Payments)
                )
                //.ForMember(
                //    dest => dest.User.Name,
                //    opt => opt.MapFrom(src =>  src.UserName)
                //)
                //.ForMember(
                //    dest => dest.User.Email,
                //    opt => opt.MapFrom(src =>  src.UserEmail)
                //)
                //.ForMember(
                //    dest => dest.Facility.Name,
                //    opt => opt.MapFrom(src =>  src.FacilityName)
                //)
                //.ForMember(
                //    dest => dest.Facility.Description,
                //    opt => opt.MapFrom(src =>  src.FacilityDesc)
                //)
                .ReverseMap();
            ;
            CreateMap<CreatePaymentDto, Payment>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src =>  src.MethodOfPayment)
                ).ReverseMap();
            ;
            CreateMap<PaymentDto, Payment>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src =>  src.MethodOfPayment)
                ).ReverseMap();
            ;

        }
    }
}