using AccessMatrixWebAPI.Models.AccessMatrix;
using AccessMatrixWebAPI.Models.Oracle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class PermissionsController : ApiController
    {
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/Locations
        [Authorize]
        [HttpGet]
        [Route("api/Permissions")]
        public HttpStatusCode Get()
        {
            return HttpStatusCode.NotFound;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Permissions/{ProfileID}")]
        public IHttpActionResult Get(int ProfileID)
        {
            var permissions = db.Database.SqlQuery<Permissions>("sp_get_permissions @profileid = {0}", ProfileID);
            if (permissions == null || permissions.Count() == 0)
            {
                return NotFound();
            }


            return Ok(permissions);
        }

        // POST: api/Permissions
        public HttpStatusCode Post(PermissionsViewModel model)
        {
            if (model != null)
            {
                try
                {
                    SetPermissions(model);
                    return HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            else
            {
                return HttpStatusCode.Created;
            }
        }
        //// PUT: api/Permissions/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        // PUT: api/Permissions/5
        [Authorize]
        [HttpPut]
        [Route("api/Permissions/{id}")]
        public HttpStatusCode Put(int id, PermissionsViewModel model)
        {
            if (model != null && id == model.profileid)
            {
                try {
                    SetPermissions(model);
                    return HttpStatusCode.OK;
                }
                catch(Exception ex)
                {
                    return HttpStatusCode.NotModified;
                }
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        private void SetPermissions(PermissionsViewModel model)
        {
            var permissions = db.Database.ExecuteSqlCommand("sp_set_permissions2 @profileid = {0}, @description = {1}, @domainid = {2}, @ou = {3}, @logonscript = {4}, " +
                        "@profiledrive = {5}, @profilepath = {6}, @membership = {7}, @changepw = {8}, @emaildid = {9}, @groupsmtp = {10}, @hasemailforwarding =  {11}, " +
                        "@haswebmail = {12}, @hasactivesync = {13}, @workboothid = {14}, @vpnid = {15}, @chatid = {16}, @hasfederation = {17}, @hasboxaccount = {18}, @remarks = {19}",
                                model.profileid,
                                model.description,
                                model.domainid,
                                model.ou == null || model.ou == "" ? String.Empty : model.ou,
                                model.logonscript,
                                model.profiledrive,
                                model.profilepath,
                                model.membership,
                                model.changepw,
                                model.emaildid,
                                model.groupsmtp,
                                model.hasemailforwarding,
                                model.haswebmail,
                                model.hasactivesync,
                                model.workboothid,
                                model.vpnid,
                                model.chatid,
                                model.hasfederation,
                                model.hasboxaccount,
                                model.remarks
                                );
        }

        // DELETE: api/Permissions/5
        public void Delete(int id)
        {
        }
    }
}
