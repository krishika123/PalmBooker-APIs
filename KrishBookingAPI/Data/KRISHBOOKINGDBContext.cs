using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KrishBookingAPI.Entities;

namespace KrishBookingAPI.Data
{
    public partial class KRISHBOOKINGDBContext : DbContext
    {
        public KRISHBOOKINGDBContext()
        {
        }

        public KRISHBOOKINGDBContext(DbContextOptions<KRISHBOOKINGDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Facility> Facilities { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=psl-dbserver-vm3\\development2017;Database=KRISHBOOKINGDB;User ID=sa;Password=Persol@123;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EventTime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FacilityID");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.StatusAoD)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_Bookings_To_Facility");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Bookings_To_Payment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Bookings_To_Users");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonOfContact)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Contacts_To_Users");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BookingID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RatePerHour)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Facility_To_Bookings");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BookingID");

                entity.Property(e => e.DueDate)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PaidAmount)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Payment_To_Bookings");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Payment_To_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BookingID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Users_To_Bookings");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Users_To_Payment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
