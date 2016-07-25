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
        public async Task <ActionResult> Index()
        {
            var model = new LocationsViewModel();
            HttpResponseMessage response = new HttpResponseMessage();
            string UrlWebAPI = WebConfigurationManager.AppSettings["UrlWebAPI"];
            using (var handler = new HttpClientHandler { UseDefaultCredentials = true })
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(UrlWebAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync("api/Locations/");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<t_locations>>();
                    if (result != null)
                        model.Locations = result;
                }

                //response = await client.GetAsync("api/Clients/");
                //if (response.IsSuccessStatusCode)
                //{
                //    var result = await response.Content.ReadAsAsync<IEnumerable<t_locations>>();
                //    if (result != null)
                //        model.Locations = result;
                //}
            }

            return View(model);
        }
    }
}
