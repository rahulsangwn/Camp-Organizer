namespace Project.DAL.DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Camp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Camp()
        {
            Bookings = new HashSet<Booking>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CampId { get; set; }
        public int Rating { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public int Price { get; set; }

        public int Capacity { get; set; }

        [Required]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
