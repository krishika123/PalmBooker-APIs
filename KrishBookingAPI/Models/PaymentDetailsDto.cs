
namespace KrishBookingAPI.Models
{
    public class PaymentDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Amount { get; set; } = null!;
        public string? PaidAmount { get; set; }
        public string? DueDate { get; set; }
        public Guid? BookingId { get; set; }

    }
}
