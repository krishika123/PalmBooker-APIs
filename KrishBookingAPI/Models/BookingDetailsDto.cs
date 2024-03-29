﻿namespace KrishBookingAPI.Models
{
    public class BookingDetailsDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        //public string UserName { get; set; }
        //public string UserEmail { get; set; }
        //public string UserPhoneNumber { get; set; }
        public string FacilityName { get; set; }
        public string? FacilityDesc { get; set; }
        public string? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? AdditionalInfo { get; set; }
        public List<PaymentDto> Payments { get; set; }

    }
    public class BookingUpdateDto
    {
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public string? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? AdditionalInfo { get; set; }

    }

    public class UserDto
    {

        public string Name { get; set; }
        public string Email { get; set; }

    }
    public class PaymentDto
    {

        public string MethodOfPayment { get; set; } = null!;
        public string Amount { get; set; } = null!;
        public string? PaidAmount { get; set; }

    }
}
