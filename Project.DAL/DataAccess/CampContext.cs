namespace Project.DAL.DataAccess
{
    using System.Data.Entity;

    public partial class CampContext : DbContext
    {
        public CampContext()
            : base("name=CampContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Camp> Camps { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingReferenceNo)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

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
