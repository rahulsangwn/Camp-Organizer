using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteBooking(int id)
        {
            while(_context.Bookings.Any(s => s.CampId == id))
            {
                var booking = _context.Bookings.First(s => s.CampId == id);
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }

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
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        
        public int[] SetAndGetRatings(string bookingRef, int rating)
        {
            var obj = _context.Bookings.FirstOrDefault(s => s.BookingReferenceNo == bookingRef);
            obj.Rating = rating;

            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return _context.Bookings.Where(s => s.Rating != 0 && s.CampId == obj.CampId).Select(s => s.Rating).ToArray();
        }
    }
}
