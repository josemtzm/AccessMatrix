using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class DepartmentsController : ApiController
    {
        private OracleContext db = new OracleContext();
        // GET: api/Departments
        [Authorize]
        [HttpGet]
        [Route("api/Departments")]
        public IQueryable<t_departments> Get()
        {
            return db.t_departments.OrderBy(x => x.DepartmentName).Where(x => x.Disabled == false);
        }

        // GET: api/Departments/5
        [Authorize]
        [HttpGet]
        [Route("api/Departments/{id}")]
        public IHttpActionResult Get(string id)
        {
            var departments = db.t_departments.Where(x => x.DepartmentID == id || x.DepartmentName.Contains(id) && x.Disabled == false).OrderBy(x => x.DepartmentName);
            if (departments == null || departments.Count() == 0)
            {
                return NotFound();
            }

            return Ok(departments);
        }

        [Authorize]
        [HttpGet]
        [Route("api/Departments/{LocationID}/{ClientID}/{ProgramID}")]
        public IHttpActionResult Get(string LocationID, string ClientID, string ProgramID)
        {
            var departments = db.Database.SqlQuery<Departments>("sp_get_departments2 @locationid = {0}, @clientid = {1}, @programid = {2}", LocationID, ClientID, ProgramID);
            if (departments == null || departments.Count() == 0)
            {
                return NotFound();
            }

            return Ok(departments);
        }

        // POST: api/Departments
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Departments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Departments/5
        public void Delete(int id)
        {
        }
    }
}
