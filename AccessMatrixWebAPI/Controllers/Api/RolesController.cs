using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class RolesController : ApiController
    {
        private OracleContext db = new OracleContext();
        // GET: api/Roles
        [Authorize]
        [HttpGet]
        [Route("api/Roles")]
        public IQueryable<t_roles> Get()
        {
            return db.t_roles;
        }

        // GET: api/Roles/5
        [Authorize]
        [HttpGet]
        [Route("api/Roles/{id}")]
        public IHttpActionResult Get(string id)
        {
            var roles = db.t_roles.Where(x => x.RoleID == id || x.RoleName.Contains(id) && x.Disabled == false);
            if (roles == null || roles.Count() == 0)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [Authorize]
        [HttpGet]
        [Route("api/Roles/{LocationID}/{ClientID}/{ProgramID}/{DeptID}")]
        public IHttpActionResult Get(string LocationID, string ClientID, string ProgramID, string DeptID)
        {
            var roles = db.Database.SqlQuery<Roles>("sp_get_roles2 @locationid = {0}, @clientid = {1}, @programid = {2}, @deptid = {3}", LocationID, ClientID, ProgramID, DeptID);
            if (roles == null || roles.Count() == 0)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // POST: api/Roles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Roles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Roles/5
        public void Delete(int id)
        {
        }
    }
}
