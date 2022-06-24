using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class Contact
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? ReasonOfContact { get; set; }
        public string? Message { get; set; }

        public virtual User? User { get; set; }
    }
}
