using Project.BAL.Entities;
using Project.BAL.Processor;
using System.Collections.Generic;
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
            return _cprocessor.GetCamps(filter);
        }

    }
}
