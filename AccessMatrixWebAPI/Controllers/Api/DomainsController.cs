using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class DomainsController : ApiController
    {
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/Domains
        [Authorize]
        [HttpGet]
        [Route("api/Domains")]
        public IQueryable<t_domains> Get()
        {
            return db.t_domains.OrderBy(x => x.DomainName);
        }

        // GET: api/Domains/5
        [Authorize]
        [HttpGet]
        [Route("api/Domains/{id}")]
        public IHttpActionResult Get(int id)
        {
            var domains = db.t_domains.Where(x => x.DomainID == id).OrderBy(x => x.DomainName);
            if (domains == null || domains.Count() == 0)
            {
                return NotFound();
            }

            return Ok(domains);
        }

        // POST: api/Domains
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Domains/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Domains/5
        public void Delete(int id)
        {
        }
    }
}
