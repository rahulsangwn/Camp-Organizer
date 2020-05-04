using Project.BAL.Entities;
using Project.DAL.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Project.BAL.Mapper
{
    public class BookingMapper
    {
        public BookingEntity BookingToBookingEntity(Booking booking)
        {
            var entity = new BookingEntity()
            {
                BookingReferenceNo = booking.BookingReferenceNo,
                CampId             = booking.CampId,
                BillingAddress     = booking.BillingAddress,
                State              = booking.State,
                Country            = booking.Country,
                ZipCode            = booking.ZipCode,
                CellPhone          = booking.CellPhone,
                CheckInDate        = booking.CheckedInDate,
                CheckOutDate       = booking.CheckedOutDate,
                TotalAmount        = booking.TotalAmount,
                Rating             = booking.Rating
            };

            return entity;
        }

        public Booking BookingEntityToBooking(BookingEntity entity)
        {
            var booking = new Booking()
            {
                BookingReferenceNo = entity.BookingReferenceNo,
                CampId             = entity.CampId,
                BillingAddress     = entity.BillingAddress,
                State              = entity.State,
                Country            = entity.Country,
                ZipCode            = entity.ZipCode,
                CellPhone          = entity.CellPhone,
                CheckedInDate      = entity.CheckInDate,
                CheckedOutDate     = entity.CheckOutDate,
                TotalAmount        = entity.TotalAmount,
                Rating             = entity.Rating
            };

            return booking;
        }

        public List<Booking> BookingEntityToBooking(List<BookingEntity> entity)
        {
            var results = entity.Select(obj => BookingEntityToBooking(obj)).ToList();
            return results;
        }

        public List<BookingEntity> BookingToBookingEntity(List<Booking> booking)
        {
            var results = booking.Select(obj => BookingToBookingEntity(obj)).ToList();
            return results;
        }
    }
}
