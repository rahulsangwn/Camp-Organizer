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
    public class ValuesController : ApiController
    {
        readonly CampProcessor _cprocessor;
        public ValuesController()
        {
            _cprocessor = new CampProcessor();
        }

        // GET api/values
        [AllowAnonymous]
        public IEnumerable<CampEntity> Get()
        {
            return _cprocessor.GetAllCamps();
        }

        // GET api/values/5
        //public CampEntity Get(int id)
        //{
        //    return _cprocessor.GetCamp(id);
        //}
        [Authorize]
        public string Get(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return "Hello" + identity.Name;
        }

        // POST api/values
        public IHttpActionResult Post(CampEntity value)
        {
            _cprocessor.CreateCamp(value);
            return Ok("Camp Created!");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
