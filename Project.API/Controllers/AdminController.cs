using Project.BAL.Entities;
using Project.BAL.Processor;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.API.Controllers
{
    [Authorize]
    public class AdminController : ApiController
    {
        CampProcessor _cprocessor;
        public AdminController()
        {
            _cprocessor = new CampProcessor();
        }

        // GET: api/Admin
        public IEnumerable<CampEntity> Get()
        {
            return _cprocessor.GetAllCamps();
        }


        // POST api/admin
        public IHttpActionResult Post(CampEntity value)
        {
            if (ModelState.IsValid)
            {
                _cprocessor.CreateCamp(value);
                return Ok("Camp Created");
            }

            return BadRequest();
        }

        // PUT api/admin
        public HttpResponseMessage Put([FromBody]CampEntity camp)
        {
            if(ModelState.IsValid)
            {
                _cprocessor.UpdateCamp(camp);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/admin/5
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _cprocessor.DeleteCamp(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
