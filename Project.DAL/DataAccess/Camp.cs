namespace Project.DAL.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
