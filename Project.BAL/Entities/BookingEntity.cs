using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Entities
{
    public class BookingEntity
    {
        public string BookingReferenceNo { get; set; }
        public int CampId { get; set; }
        public string BillingAddress { get; set; }
        public DateTime CheckedInDate { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string CellPhone { get; set; }
        public int TotalAmount { get; set; }

    }
}
