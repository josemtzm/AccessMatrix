﻿using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class ProfilesController : ApiController
    {
        private OracleContext db = new OracleContext();
        // GET: api/Profiles
        [Authorize]
        [HttpGet]
        [Route("api/Profiles")]
        public HttpStatusCode Get()
        {
            return HttpStatusCode.NoContent;
        }

        // GET: api/Profiles/5
        [Authorize]
        [HttpGet]
        [Route("api/Profiles/{id}")]
        public HttpStatusCode Get(string id)
        {
            return HttpStatusCode.NoContent;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Profiles/{LocationID}/{ClientID}/{ProgramID}/{ProjectID}/{DeptID}/{RoleID}")]
        public IHttpActionResult Get(string LocationID, string ClientID, string ProgramID, string ProjectID, string DeptID, string RoleID)
        {
            var profiles = db.Database.SqlQuery<Profiles>("sp_get_profiles @locationid = {0}, @clientid = {1}, @programid = {2}, @projectid = {3}, @deptid = {4}, @roleid = {5}", LocationID, ClientID, ProgramID, ProjectID, DeptID, RoleID);
            if (profiles == null || profiles.Count() == 0)
            {
                return NotFound();
            }

            return Ok(profiles);
        }

        // POST: api/Profiles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profiles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profiles/5
        public void Delete(int id)
        {
        }
    }
}
