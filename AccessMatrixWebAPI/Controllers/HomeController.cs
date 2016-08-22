using AccessMatrixWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AccessMatrixWebAPI.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.ErrorMsg = "User not authenticated.";

            if (User.Identity.IsAuthenticated)
                return View();
            else
            {
                return View("Error");
            }

        }
    }
}
