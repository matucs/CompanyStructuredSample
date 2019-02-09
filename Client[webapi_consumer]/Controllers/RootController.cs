using CompanyStructured.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Client_webapi_consumer_.Controllers
{
    public class RootController : Controller
    {
        // GET: Root
        string Baseurl = "http://CompanyStructured.WebAPI/";
        public async Task<ActionResult> Index()
        {
            Node root = new Node();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllchildren using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"api/Root");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Node list  

                     root = new JavaScriptSerializer().Deserialize<Node>(Response);
                }
                //returning the node list to view  
                return View(root);
            }

        }
    }
}