using System;
using System.ComponentModel.DataAnnotations;

namespace Project.BAL.Entities
{
    public class BookingEntity
    {
        [StringLength(8)]
        public string BookingReferenceNo { get; set; }

        [Required]
        public int CampId { get; set; }

        [Required]
        public string BillingAddress { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string CellPhone { get; set; }

        [Required]
        public int TotalAmount { get; set; }
        public int Rating { get; set; }

    }
}
