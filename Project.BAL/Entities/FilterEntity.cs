using System;
using System.ComponentModel.DataAnnotations;

namespace Project.BAL.Entities
{
    public class FilterEntity
    {
        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
