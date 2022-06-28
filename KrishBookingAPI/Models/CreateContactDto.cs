namespace KrishBookingAPI.Models
{
    public class CreateContactDto
    {
        public Guid? UserId { get; set; }
        public string? ReasonOfContact { get; set; }
        public string? Message { get; set; }

    }
}
