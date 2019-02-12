using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Client_webapi_consumer_
{
    public static class Share
    {
        public static string Baseurl  = WebConfigurationManager.AppSettings["Baseurl"];
    }
}