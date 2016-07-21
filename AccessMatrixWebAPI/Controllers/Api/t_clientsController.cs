using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AccessMatrixWebAPI;

namespace AccessMatrixWebAPI.Controllers.Api
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AccessMatrixWebAPI;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<t_clients>("t_clients");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class t_clientsController : ODataController
    {
        private OracleContext db = new OracleContext();

        // GET: odata/t_clients
        [EnableQuery]
        public IQueryable<t_clients> Gett_clients()
        {
            return db.t_clients;
        }

        // GET: odata/t_clients(5)
        [EnableQuery]
        public SingleResult<t_clients> Gett_clients([FromODataUri] string key)
        {
            return SingleResult.Create(db.t_clients.Where(t_clients => t_clients.ClientID == key));
        }

        // PUT: odata/t_clients(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<t_clients> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_clients t_clients = db.t_clients.Find(key);
            if (t_clients == null)
            {
                return NotFound();
            }

            patch.Put(t_clients);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_clientsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_clients);
        }

        // POST: odata/t_clients
        public IHttpActionResult Post(t_clients t_clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_clients.Add(t_clients);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_clientsExists(t_clients.ClientID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_clients);
        }

        // PATCH: odata/t_clients(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<t_clients> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_clients t_clients = db.t_clients.Find(key);
            if (t_clients == null)
            {
                return NotFound();
            }

            patch.Patch(t_clients);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_clientsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_clients);
        }

        // DELETE: odata/t_clients(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            t_clients t_clients = db.t_clients.Find(key);
            if (t_clients == null)
            {
                return NotFound();
            }

            db.t_clients.Remove(t_clients);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_clientsExists(string key)
        {
            return db.t_clients.Count(e => e.ClientID == key) > 0;
        }
    }
}
