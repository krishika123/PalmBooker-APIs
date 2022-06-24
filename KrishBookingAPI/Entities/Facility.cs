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

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Number { get; set; }
        public string? Description { get; set; }
        public string RatePerHour { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
