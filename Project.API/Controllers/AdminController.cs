using Project.BAL.Entities;
using Project.BAL.Processor;
using System.Collections.Generic;
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


        // GET api/admin/5
        public CampEntity Get(int id)
        {
            return _cprocessor.GetCamp(id);
        }

        // POST api/admin
        public IHttpActionResult Post(CampEntity value)
        {
            _cprocessor.CreateCamp(value);
            return Ok("Camp Created!");
        }

        // PUT api/admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/admin/5
        public bool Delete(int id)
        {
            _cprocessor.DeleteCamp(id);
            return true;
        }
    }
}
