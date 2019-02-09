using CompanyStructured.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Client_webapi_consumer_.Controllers
{
    public class AllChildrenController : Controller
    {
        // GET: AllChildren
        string Baseurl = "http://localhost:9907/";

        public ActionResult Index()
        {
            List<Node> nodes = new List<Node>();
            return View(nodes);
        }
        [HttpPost]
        public async Task<ActionResult> Index(string txtnodeid)
        {
      
            List<Node> nodes = new List<Node>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllchildren using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"api/Hierarchy/{txtnodeid}");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Node list  

                    nodes = new JavaScriptSerializer().Deserialize<List<Node>>(Response);
                }
                //returning the node list to view  
                return View(nodes);
            }
        }
    }
}