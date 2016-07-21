using AccessMatrixWebAPI.Models.Oracle;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private OracleContext db = new OracleContext();
        // GET: api/Clients
        [Authorize]
        [HttpGet]
        [Route("api/Clients")]
        public IQueryable<t_clients> Get()
        {
            return db.t_clients;
        }

        // GET: api/Clients/5
        [Authorize]
        [HttpGet]
        [Route("api/Clients/{id}")]
        public IHttpActionResult Get(string id)
        {
            var clients = db.t_clients.Where(x => x.ClientID == id || x.ClientName.Contains(id) && x.Disabled == false);
            if (clients == null || clients.Count() == 0)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [Authorize]
        [HttpGet]
        [Route("api/ClientsByLocation/{id}")]
        public IHttpActionResult GetByLocation(string id)
        {
            var clients = db.Database.SqlQuery<Clients>("sp_get_clients @site_id = {0}",id);
            if (clients == null || clients.Count() == 0)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // POST: api/Clients
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
        }
    }
}
