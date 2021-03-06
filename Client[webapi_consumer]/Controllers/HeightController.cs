﻿using CompanyStructured.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Client_webapi_consumer_.Controllers
{
    public class HeightController : Controller
    {
        // GET: Height
   
        int height = 0;

        public ActionResult Index()
        {
            ViewBag.Baseurl = Share.Baseurl;
            return View();
        }
        public async Task<int> getheight(int id)
        {
           
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Share.Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
                HttpResponseMessage Res = await client.GetAsync($"api/Height/{id}");
 
                if (Res.IsSuccessStatusCode)
                {
                     
                    var Response = Res.Content.ReadAsStringAsync().Result;
 

                    height = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<int>(Response);
                }
                //returning the node list to view  
                return height;
            }
        }
 
    }
}