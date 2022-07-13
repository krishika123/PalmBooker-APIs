using System;
using System.Collections.Generic;

namespace KrishBookingAPI.Entities
{
    public partial class DeviceCode
    {
        public string UserCode { get; set; } = null!;
        public string DeviceCode1 { get; set; } = null!;
        public string? SubjectId { get; set; }
        public string ClientId { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public DateTime Expiration { get; set; }
        public string Data { get; set; } = null!;
    }
}
