using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class Facility
    {
        public Facility()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public string? BookingId { get; set; }
        public string? RatePerHour { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
