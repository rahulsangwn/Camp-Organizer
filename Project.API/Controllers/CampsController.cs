using Project.BAL.Entities;
using Project.BAL.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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
        [AllowAnonymous]
        public IEnumerable<CampEntity> Get([FromUri] FilterEntity filter)
        {
            return _cprocessor.GetAllCamps(filter);
        }

        // GET api/camps/5
        public CampEntity Get(int id)
        {
            return _cprocessor.GetCamp(id);
        }

        // POST api/camps
        //[Authorize]
        public IHttpActionResult Post(CampEntity value)
        {
            _cprocessor.CreateCamp(value);
            return Ok("Camp Created!");
        }

        // PUT api/camps/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/camps/5
        public void Delete(int id)
        {
            _cprocessor.DeleteCamp(id);
        }
    }
}
