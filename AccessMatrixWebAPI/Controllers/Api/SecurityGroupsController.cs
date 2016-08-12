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
    public class SecurityGroupsController : ApiController
    {
        // GET: api/SecurityGroups
        // GET: api/SecurityGroups
        private USVIA db = new USVIA();
        // GET: api/SecurityGroups
        [Authorize]
        [HttpGet]
        [Route("api/SecurityGroups")]
        public IQueryable<SecurityGroups> Get()
        {
            var sec = from sec_grps in db.SEC_GRPS
                      orderby sec_grps.NAME
                      join domains in db.DOMAINS on sec_grps.DOMAIN_ID equals domains.DOMAIN_ID
                      select new SecurityGroups()
                      {
                          SEC_GRP_ID = sec_grps.SEC_GRP_ID,
                          DOMAIN_ID = sec_grps.DOMAIN_ID,
                          SEC_GROUP_NAME = sec_grps.NAME,
                          SEC_GROUP_DESC = sec_grps.DESCRIPTION,
                          SEC_GROUP_DN = sec_grps.DN,
                          DOMAIN_NAME = domains.NAME,
                          DOMAIN_DESC = domains.DESCRIPTION,
                          DOMAIN_DN = domains.DN
                      };

            return sec;
        }

        // GET: api/SecurityGroups/5
        [Authorize]
        [HttpGet]
        [Route("api/SecurityGroups/{id}")]
        public IHttpActionResult Get(int id)
        {
            var sec = from sec_grps in db.SEC_GRPS
                      where sec_grps.SEC_GRP_ID == id
                      orderby sec_grps.NAME
                       join domains in db.DOMAINS on sec_grps.DOMAIN_ID equals domains.DOMAIN_ID
                       select new
                       {
                           sec_grps.SEC_GRP_ID,
                           sec_grps.DOMAIN_ID,
                           SEC_GROUP_NAME = sec_grps.NAME,
                           SEC_GROUP_DESC = sec_grps.DESCRIPTION,
                           SEC_GROUP_DN = sec_grps.DN,
                           DOMAIN_NAME = domains.NAME,
                           DOMAIN_DESC = domains.DESCRIPTION,
                           DOMAIN_DN = domains.DN
                       };
            if (sec == null || sec.Count() == 0)
            {
                return NotFound();
            }

            return Ok(sec);
        }

        // GET: api/SecurityGroups/5
        [Authorize]
        [HttpGet]
        [Route("api/SecurityGroups/{keyword}")]
        public IHttpActionResult Get(string keyword)
        {
            var sec = from sec_grps in db.SEC_GRPS
                      orderby sec_grps.NAME
                      join domains in db.DOMAINS on sec_grps.DOMAIN_ID equals domains.DOMAIN_ID
                      where sec_grps.NAME.Contains(keyword) || domains.NAME.Contains(keyword)
                      select new
                      {
                          sec_grps.SEC_GRP_ID,
                          sec_grps.DOMAIN_ID,
                          SEC_GROUP_NAME = sec_grps.NAME,
                          SEC_GROUP_DESC = sec_grps.DESCRIPTION,
                          SEC_GROUP_DN = sec_grps.DN,
                          DOMAIN_NAME = domains.NAME,
                          DOMAIN_DESC = domains.DESCRIPTION,
                          DOMAIN_DN = domains.DN
                      };
            if (sec == null || sec.Count() == 0)
            {
                return NotFound();
            }

            return Ok(sec);
        }

        // POST: api/SecurityGroups
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SecurityGroups/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SecurityGroups/5
        public void Delete(int id)
        {
        }
    }
}
