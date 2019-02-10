using CompanyStructured.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;



namespace Client_webapi_consumer_.Controllers
{
    public class Change_Current_Parent_Controller : Controller
    {
        // GET: Change_Current_Parent_
        string baseUri = "http://CompanyStructured.WebAPI/";

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task Index(int id, int newParentId)
        {
            parentchange pc = new parentchange { id = id, newparentid = newParentId };

            using (var client = new HttpClient())
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(pc), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(
        "api/ChangeParent", content);

                if (response.IsSuccessStatusCode)
                     Response.Write($"Succeed action!" + response.StatusCode);
                else
                    response.EnsureSuccessStatusCode();
            }
        }
    }
}