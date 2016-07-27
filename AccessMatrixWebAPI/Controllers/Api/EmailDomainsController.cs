using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class EmailDomainsController : ApiController
    {
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/EmailDomains
        [Authorize]
        [HttpGet]
        [Route("api/EmailDomains")]
        public IQueryable<t_emaildomains> Get()
        {
            return db.t_emaildomains;
        }

        // GET: api/EmailDomains/5
        [Authorize]
        [HttpGet]
        [Route("api/EmailDomains/{id}")]
        public IHttpActionResult Get(int id)
        {
            var emaildomains = db.t_emaildomains.Where(x => x.EmailID == id);
            if (emaildomains == null || emaildomains.Count() == 0)
            {
                return NotFound();
            }

            return Ok(emaildomains);
        }

        // POST: api/EmailDomains
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EmailDomains/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmailDomains/5
        public void Delete(int id)
        {
        }
    }
}
