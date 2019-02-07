using CompanyStructured.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client_webapi_consumer_.Controllers
{
    public class HeightController : Controller
    {
        // GET: Height
        string Baseurl = "http://localhost:9907/";
        public async Task<ActionResult> Index(int id)
        {
            int height = 0;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllchildren using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"api/Height/{id}");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Node list  

                    height = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<int>(Response);
                }
                //returning the node list to view  
                ViewBag.height = height;
                return View();
            }
        }
    }
}