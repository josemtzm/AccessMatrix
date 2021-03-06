﻿using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class ProgramsController : ApiController
    {
        private OracleContext db = new OracleContext();
        // GET: api/Clients
        [Authorize]
        [HttpGet]
        [Route("api/Programs")]
        public IQueryable<t_programs> Get()
        {
            return db.t_programs.OrderBy(x => x.ProgramName);
        }

        // GET: api/Clients/5
        [Authorize]
        [HttpGet]
        [Route("api/Programs/{id}")]
        public IHttpActionResult Get(string id)
        {
            var programs = db.t_programs.Where(x => x.ProgramID == id || x.ProgramName.Contains(id) && x.Disabled == false).OrderBy(x => x.ProgramName);
            if (programs == null || programs.Count() == 0)
            {
                return NotFound();
            }

            return Ok(programs);
        }

        [Authorize]
        [HttpGet]
        [Route("api/Programs/{LocationID}/{ClientID}")]
        public IHttpActionResult Get(string LocationID, string ClientID)
        {
            var programs = db.Database.SqlQuery<Programs>("sp_get_programs @locationid = {0}, @clientid = {1}", LocationID, ClientID);
            if (programs == null || programs.Count() == 0)
            {
                return NotFound();
            }

            return Ok(programs);
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetPrograms/{ClientID}")]
        public IHttpActionResult GetPrograms(string ClientID)
        {
            var programs = db.Database.SqlQuery<Programs>("sp_get_programs_of_client @clientid = {0}", ClientID);
            if (programs == null || programs.Count() == 0)
            {
                return NotFound();
            }

            return Ok(programs);
        }

        // POST: api/Programs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Programs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Programs/5
        public void Delete(int id)
        {
        }
    }
}
