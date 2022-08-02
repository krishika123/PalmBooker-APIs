namespace KrishBookingAPI.Models
{
    public class CreateContactDto
    {
        //public Guid? UserId { get;  set; }
        //public ContactUserDto User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? ReasonOfContact { get; set; }
        public string? Message { get; set; }

    }

    public class ContactUserDto
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }


}
