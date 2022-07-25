namespace KrishBookingAPI.Models
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Password { get; set; }
        public List<BookingDto> Bookings { get; set; }
        public List<ContactDto> Contacts { get; set; }

    }

    public class BookingDto
    {

        public string BookingId { get; set; } = null!;

    }
    public class ContactDto
    {

        public string ContactId { get; set; } = null!;

    }
}
