using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class Contact
    {
        public Guid Id { get; set; }
        public string? ReasonOfContact { get; set; }
        public string? Message { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
