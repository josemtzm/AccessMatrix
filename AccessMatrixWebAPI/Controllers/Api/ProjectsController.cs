using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        // GET: api/Projects
        private OracleContext db = new OracleContext();
        // GET: api/Projects
        [Authorize]
        [HttpGet]
        [Route("api/Projects")]
        public IQueryable<t_projects> Get()
        {
            return db.t_projects.OrderBy(x => x.ProjectName).Where(x => x.Disabled == false);
        }

        // GET: api/Projects/5
        [Authorize]
        [HttpGet]
        [Route("api/Projects/{id}")]
        public IHttpActionResult Get(string id)
        {
            var projects = db.t_projects.Where(x => x.ProjectID == id || x.ProjectName.Contains(id) && x.Disabled == false).OrderBy(x => x.ProjectName);
            if (projects == null || projects.Count() == 0)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        // GET: api/Projects/5
        [Authorize]
        [HttpGet]
        [Route("api/GetProjects/{ProgramID}")]
        public IHttpActionResult GetProjects(string ProgramID)
        {
            var departments = db.Database.SqlQuery<Projects>("sp_get_projects_by_programs @programid = {0}", ProgramID);
            if (departments == null || departments.Count() == 0)
            {
                return NotFound();
            }

            return Ok(departments);
        }
        [Authorize]
        [HttpGet]
        [Route("api/Projects/{LocationID}/{ClientID}/{ProgramID}")]
        public IHttpActionResult Get(string LocationID, string ClientID, string ProgramID)
        {
            var departments = db.Database.SqlQuery<Projects>("sp_get_projects @locationid = {0}, @clientid = {1}, @programid = {2}", LocationID, ClientID, ProgramID);
            if (departments == null || departments.Count() == 0)
            {
                return NotFound();
            }

            return Ok(departments);
        }

        // POST: api/Projects
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Projects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Projects/5
        public void Delete(int id)
        {
        }
    }
}
