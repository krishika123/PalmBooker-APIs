using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? FacilityId { get; set; }
        public string? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? StatusAoD { get; set; }
        public string? AdditionalInfo { get; set; }

        public virtual Facility? Facility { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
