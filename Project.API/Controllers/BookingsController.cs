using Project.BAL.Entities;
using Project.BAL.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.API.Controllers
{
    public class BookingsController : ApiController
    {
        readonly BookingProcessor _bprocessor;
        public BookingsController()
        {
            _bprocessor = new BookingProcessor();
        }

        public IHttpActionResult Post(BookingEntity value)
        {
            var bookingReference = _bprocessor.CreateBooking(value);
            return Ok(bookingReference);
        }

        public BookingEntity Get(string bookingRef)
        {
            return _bprocessor.GetBooking(bookingRef);
        }

        public bool Delete(string bookingRef)
        {
            return _bprocessor.DeleteBooking(bookingRef);
        }
    }
}
