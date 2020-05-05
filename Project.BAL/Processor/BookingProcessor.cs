using Project.BAL.Entities;
using Project.BAL.Logic;
using Project.BAL.Mapper;
using Project.DAL.AccessMethods;
using Project.DAL.DataAccess;

namespace Project.BAL.Processor
{
    public class BookingProcessor
    {
        readonly BookingAccess _booking;
        readonly BookingMapper _bmapper;
        public BookingProcessor()
        {
            _booking = new BookingAccess();
            _bmapper = new BookingMapper();
        }

        public string CreateBooking(BookingEntity booking)
        {
            BookingReferenceGenerator refGernerator = new BookingReferenceGenerator();
            string bookingRef = refGernerator.GenerateBookingReference();
            while(_booking.IsRefPresent(bookingRef))
            {
                bookingRef = refGernerator.GenerateBookingReference();
            }

            var newBooking = _bmapper.BookingEntityToBooking(booking);
            newBooking.BookingReferenceNo = bookingRef;

            _booking.CreateBooking(newBooking);

            return bookingRef;
        }

        public BookingEntity GetBooking(string bookingRef)
        {
            var booking = _booking.Get(bookingRef);
            if (booking == null)
            {
                return null;
            }

            var bookingDetails = _bmapper.BookingToBookingEntity(booking);

            return bookingDetails;
        }

        public bool DeleteBooking(string bookingRef)
        {
            return _booking.Delete(bookingRef);
        }
    }
}
