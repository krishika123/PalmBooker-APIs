using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Contacts = new HashSet<Contact>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
