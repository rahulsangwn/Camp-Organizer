using Project.BAL.Entities;
using Project.BAL.Processor;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.API.Controllers
{
    public class CampsController : ApiController
    {
        readonly CampProcessor _cprocessor;
        public CampsController()
        {
            _cprocessor = new CampProcessor();
        }

        // GET api/camps
        public IEnumerable<CampEntity> Get([FromUri] FilterEntity filter)
        {
            var today = DateTime.Now;
            var yestarday = today.AddDays(-1);
            if (!ModelState.IsValid || filter.CheckInDate < yestarday  || filter.CheckInDate > filter.CheckOutDate)
            {
                List<CampEntity> empty = new List<CampEntity>();
                return empty;
            }

            return _cprocessor.GetCamps(filter);
        }

        public CampEntity Get(int id)
        {
            if(ModelState.IsValid)
            {
                return _cprocessor.GetCamp(id);
            }

            return null;
        }

        public HttpResponseMessage PostRating(string bookingRef, int rating)
        {
            if (ModelState.IsValid)
            {
                _cprocessor.SetRating(bookingRef, rating);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

    }
}
