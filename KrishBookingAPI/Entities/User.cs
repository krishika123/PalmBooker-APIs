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
            Payments = new HashSet<Payment>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BookingId { get; set; }
        public string? PaymentId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
