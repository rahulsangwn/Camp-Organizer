using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.AccessMethods
{
    public class BookingAccess
    {
        readonly CampContext _context;
        public BookingAccess()
        {
            _context = new CampContext();
        }

        public bool IsRefPresent(string reference)
        {
            return _context.Bookings.Any(s => s.BookingReferenceNo == reference);
        }

        public void CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public List<int> CampBookedBetween(DateTime checkIn, DateTime checkOut)
        {
            return _context.Bookings
                .Where(s => (checkIn <= s.CheckedInDate && s.CheckedInDate <= checkOut) || 
                    (checkIn <= s.CheckedOutDate && s.CheckedOutDate <= checkOut))
                .Select(s => s.CampId).ToList();
        }

        public Booking Get(string bookingRef)
        {
            return _context.Bookings.FirstOrDefault(s => s.BookingReferenceNo == bookingRef);
        }

        public bool Delete(string bookingRef)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingReferenceNo == bookingRef);
            if (booking != null && booking.CheckedInDate > DateTime.Now)
            {
                _context.Bookings.Remove(booking);
                return true;
            }

            return false;
        }
    }
}
