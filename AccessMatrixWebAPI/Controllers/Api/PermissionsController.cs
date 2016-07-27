using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class PermissionsController : ApiController
    {
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/Locations
        [Authorize]
        [HttpGet]
        [Route("api/Permissions")]
        public HttpStatusCode Get()
        {
            return HttpStatusCode.NotFound;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Permissions/{ProfileID}")]
        public IHttpActionResult Get(int ProfileID)
        {
            var permissions = db.Database.SqlQuery<Permissions>("sp_get_permissions @profileid = {0}", ProfileID);
            if (permissions == null || permissions.Count() == 0)
            {
                return NotFound();
            }

            return Ok(permissions);
        }

        // POST: api/Permissions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Permissions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Permissions/5
        public void Delete(int id)
        {
        }
    }
}
