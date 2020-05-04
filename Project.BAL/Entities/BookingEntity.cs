using System;

namespace Project.BAL.Entities
{
    public class BookingEntity
    {
        public string BookingReferenceNo { get; set; }
        public int CampId { get; set; }
        public string BillingAddress { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string CellPhone { get; set; }
        public int TotalAmount { get; set; }
        public int Rating { get; set; }

    }
}
