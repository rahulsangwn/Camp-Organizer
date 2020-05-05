using Project.BAL.Entities;
using Project.BAL.Processor;
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
            if(ModelState.IsValid)
            {
                var bookingReference = _bprocessor.CreateBooking(value);
                return Ok(bookingReference);
            }

            return BadRequest();
        }

        public BookingEntity Get(string bookingRef)
        {
            if(ModelState.IsValid)
            {
                return _bprocessor.GetBooking(bookingRef);
            }

            return null;
        }

        public HttpResponseMessage Delete(string bookingRef)
        {
            if (ModelState.IsValid)
            {
                _bprocessor.DeleteBooking(bookingRef);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
