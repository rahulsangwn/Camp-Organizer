namespace Project.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [Key]
        [StringLength(8)]
        public string BookingReferenceNo { get; set; }

        public int CampId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckedInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckedOutDate { get; set; }

        public int TotalAmount { get; set; }

        [Required]
        [StringLength(100)]
        public string BillingAddress { get; set; }

        [Required]
        [StringLength(40)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public int ZipCode { get; set; }

        public virtual Camp Camp { get; set; }
    }
}
