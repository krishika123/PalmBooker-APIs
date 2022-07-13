using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class User
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
