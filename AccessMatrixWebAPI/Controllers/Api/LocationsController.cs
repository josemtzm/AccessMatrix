﻿using AccessMatrixWebAPI;
using System.Linq;
using System.Web.Http;

namespace AccessMatrix.Controllers.Api
{
    public class LocationsController : ApiController
    {
        private OracleContext db = new OracleContext();
        // GET: api/Locations
        [Authorize]
        [HttpGet]
        [Route("api/Locations")]
        public IQueryable<t_locations> Get()
        {   
            return db.t_locations;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Locations/{id}")]
        public IHttpActionResult Get(string id)
        {
            var locations = db.t_locations
                                .Where(x => x.LocationID == id || x.LocationName.Contains(id) && x.Disabled == false)
                                .OrderByDescending(x => x.LocationName);
            if (locations == null || locations.Count() == 0)
            {
                return NotFound();
            }

            return Ok(locations);
        }

        // POST: api/Locations
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Locations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Locations/5
        public void Delete(int id)
        {
        }
    }
}
