using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccessMatrixWebAPI.Controllers.Api
{
    public class ChatsController : ApiController
    {
        // GET: api/Chats
        private AccessMatrixContext db = new AccessMatrixContext();
        // GET: api/Chats
        [Authorize]
        [HttpGet]
        [Route("api/Chats")]
        public IQueryable<t_chat> Get()
        {
            return db.t_chat.OrderBy(x=>x.ChatName);
        }

        // GET: api/Chats/5
        [Authorize]
        [HttpGet]
        [Route("api/Chats/{id}")]
        public IHttpActionResult Get(int id)
        {
            var chat = db.t_chat.Where(x => x.ChatID == id).OrderBy(x => x.ChatName);
            if (chat == null || chat.Count() == 0)
            {
                return NotFound();
            }

            return Ok(chat);
        }

        // POST: api/Chats
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Chats/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chats/5
        public void Delete(int id)
        {
        }
    }
}
