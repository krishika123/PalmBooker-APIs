namespace KrishBookingAPI.Models
{
    public class UpdateFacilityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public string? RatePerHour { get; set; }
    }
}
