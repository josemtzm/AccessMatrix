using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class WorkBoothsController : ApiController
    {
        // GET: api/WorkBooths
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/WorkBooths
        [Authorize]
        [HttpGet]
        [Route("api/WorkBooths")]
        public IQueryable<t_workbooth> Get()
        {
            return db.t_workbooth;
        }

        // GET: api/WorkBooths/5
        [Authorize]
        [HttpGet]
        [Route("api/WorkBooths/{id}")]
        public IHttpActionResult Get(int id)
        {
            var workbooth = db.t_workbooth.Where(x => x.WorkboothID == id);
            if (workbooth == null || workbooth.Count() == 0)
            {
                return NotFound();
            }

            return Ok(workbooth);
        }

        // POST: api/WorkBooths
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WorkBooths/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WorkBooths/5
        public void Delete(int id)
        {
        }
    }
}
