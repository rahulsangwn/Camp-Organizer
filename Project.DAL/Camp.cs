namespace Project.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Camp
    {
        public Camp()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CampId { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public int Price { get; set; }

        public int Capacity { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Photo { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
