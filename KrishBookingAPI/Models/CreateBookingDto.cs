namespace KrishBookingAPI.Models
{
    public class CreateBookingDto
    {
        //public Guid Id { get; set; }
        //public string UserName { get; set; }
        //public string UserEmail { get; set; }
        //public string UserPhoneNumber { get; set; }
        public Guid FacilityId { get; set; }
        public string? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? AdditionalInfo { get; set; }
    }

}
