using AutoMapper;
using KrishBookingAPI.Data;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KrishBookingAPI.Entities
{
    public partial class Payment
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Amount { get; set; } = null!;
        public string? PaidAmount { get; set; }
        public string? DueDate { get; set; }
        public Guid? BookingId { get; set; }

        public virtual Booking? Booking { get; set; }
    }
}
