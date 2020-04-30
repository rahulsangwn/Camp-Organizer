using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.BAL.Entities;
using Project.BAL.Logic;
using Project.DAL.AccessMethods;
using Project.DAL.DataAccess;

namespace Project.BAL.Processor
{
    public class BookingProcessor
    {
        readonly BookingAccess _booking;
        public BookingProcessor()
        {
            _booking = new BookingAccess();
        }

        public string CreateBooking(BookingEntity booking)
        {
            BookingReferenceGenerator refGernerator = new BookingReferenceGenerator();
            string bookingRef = refGernerator.GenerateBookingReference();
            while(_booking.IsRefPresent(bookingRef))
            {
                bookingRef = refGernerator.GenerateBookingReference();
            }

            TotalAmountCalculator amountCalculator = new TotalAmountCalculator();
            int amount = amountCalculator.CalculateAmount(booking.CheckedInDate, booking.CheckedOutDate, booking.CampId);

            Booking newBooking = new Booking()
            {
                BookingReferenceNo = bookingRef,
                CampId             = booking.CampId,
                BillingAddress     = booking.BillingAddress,
                State              = booking.State,
                Country            = booking.Country,
                ZipCode            = booking.ZipCode,
                CellPhone          = booking.CellPhone,
                CheckedInDate      = booking.CheckedInDate,
                CheckedOutDate     = booking.CheckedOutDate,
                TotalAmount        = amount
            };

            _booking.CreateBooking(newBooking);

            return bookingRef;
        }

        public BookingEntity GetBooking(string bookingRef)
        {
            var booking = _booking.Get(bookingRef);
            BookingEntity bookingDetails = new BookingEntity()
            {
                BookingReferenceNo = bookingRef,
                CampId = booking.CampId,
                BillingAddress = booking.BillingAddress,
                State = booking.State,
                Country = booking.Country,
                ZipCode = booking.ZipCode,
                CellPhone = booking.CellPhone,
                CheckedInDate = booking.CheckedInDate,
                CheckedOutDate = booking.CheckedOutDate,
                TotalAmount = booking.TotalAmount
            };

            return bookingDetails;
        }

        public bool DeleteBooking(string bookingRef)
        {
            return _booking.Delete(bookingRef);
        }
    }
}
