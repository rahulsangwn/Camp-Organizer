namespace Project.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CampContext : DbContext
    {
        public CampContext()
            : base("name=CampContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Camp> Camps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingReferenceNo)
                .IsFixedLength();

            modelBuilder.Entity<Booking>()
                .Property(e => e.BillingAddress)
                .IsFixedLength();

            modelBuilder.Entity<Booking>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<Booking>()
                .Property(e => e.Country)
                .IsFixedLength();

            modelBuilder.Entity<Camp>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Camp>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Camp)
                .WillCascadeOnDelete(false);
        }
    }
}
