namespace KrishBookingAPI.Models
{
    public class UpdateBookingDto
    {

        public Guid Id { get; set; }
        public string? FacilityId { get; set; }
        public string? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? AddInfo { get; set; }
    }
}
