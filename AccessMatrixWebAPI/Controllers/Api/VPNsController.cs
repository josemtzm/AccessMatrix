using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class VPNsController : ApiController
    {
        // GET: api/VPNs
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/VPNs
        [Authorize]
        [HttpGet]
        [Route("api/VPNs")]
        public IQueryable<t_vpn> Get()
        {
            return db.t_vpn;
        }

        // GET: api/VPNs/5
        [Authorize]
        [HttpGet]
        [Route("api/VPNs/{id}")]
        public IHttpActionResult Get(int id)
        {
            var vpn = db.t_vpn.Where(x => x.VpnID == id);
            if (vpn == null || vpn.Count() == 0)
            {
                return NotFound();
            }

            return Ok(vpn);
        }

        // POST: api/VPNs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VPNs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VPNs/5
        public void Delete(int id)
        {
        }
    }
}
