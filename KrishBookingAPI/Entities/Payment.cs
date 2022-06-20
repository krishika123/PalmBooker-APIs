using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Bookings = new HashSet<Booking>();
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Amount { get; set; }
        public string? PaidAmount { get; set; }
        public string? DueDate { get; set; }
        public string? BookingId { get; set; }
        public string? UserId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
