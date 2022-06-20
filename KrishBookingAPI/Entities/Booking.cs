using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            Facilities = new HashSet<Facility>();
            Payments = new HashSet<Payment>();
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string? UserId { get; set; }
        public string? FacilityId { get; set; }
        public string? PaymentId { get; set; }
        public string? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? StatusAoD { get; set; }
        public string? AdditionalInfo { get; set; }

        public virtual Facility? Facility { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
