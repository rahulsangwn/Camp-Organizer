using System;

namespace Project.BAL.Entities
{
    public class FilterEntity
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Capacity { get; set; }
    }
}
