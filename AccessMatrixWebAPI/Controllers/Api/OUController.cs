using AccessMatrixWebAPI.Models;
using AccessMatrixWebAPI.Models.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class OUController : ApiController
    {
        private USVIA db = new USVIA();
        // GET: api/OU
        [Authorize]
        [HttpGet]
        public IQueryable<OrgUnit> Get(string term)
        {
            return (
                from ou in db.OUS
                orderby ou.NAME
                join domains in db.DOMAINS on ou.DOMAIN_ID equals domains.DOMAIN_ID
                where ou.ACTV_FLG == "Y" && domains.ACTV_FLG == "Y" && (ou.DN.Contains(term) || ou.NAME.Contains(term) || domains.NAME.Contains(term))
                select new OrgUnit()
                {
                    DOMAIN_ID = ou.DOMAIN_ID,
                    OU_ID = ou.OU_ID,
                    NAME = ou.NAME,
                    DESCRIPTION = ou.DESCRIPTION,
                    DN = ou.DN
                });
        }

        [Authorize]
        [HttpGet]
        [Route("api/SecurityGroups")]
        public IQueryable<OrgUnit> Get()
        {
            return (
                from ou in db.OUS
                orderby ou.NAME
                join domains in db.DOMAINS on ou.DOMAIN_ID equals domains.DOMAIN_ID
                where ou.ACTV_FLG == "Y" && domains.ACTV_FLG == "Y"
                select new OrgUnit()
                {
                    DOMAIN_ID = ou.DOMAIN_ID,
                    OU_ID = ou.OU_ID,
                    NAME = ou.NAME,
                    DESCRIPTION = ou.DESCRIPTION,
                    DN = ou.DN
                });
        }

        // POST: api/OU
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OU/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OU/5
        public void Delete(int id)
        {
        }
    }
}
