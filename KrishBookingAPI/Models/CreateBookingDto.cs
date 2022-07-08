namespace KrishBookingAPI.Models
{
    public class CreateBookingDto
    {
        public string UserId { get; set; }
        public string FacilityId { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string? AdditionalInfo { get; set; }
        public List<CreatePaymentDto> Payments { get; set; }

    }

    public class CreatePaymentDto
    {

        public string MethodOfPayment { get; set; } = null!;
        public string Amount { get; set; } = null!;
        public string? PaidAmount { get; set; }

    }

}
