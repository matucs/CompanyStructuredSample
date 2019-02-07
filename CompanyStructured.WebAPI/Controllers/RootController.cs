using CompanyStructured.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyStructured.WebAPI.Controllers
{
    public class RootController : ApiController
    {
        private CompanyHierarchy _CompanyHierarchy;


        public Common.Models.Node GetRoot()
        {
            _CompanyHierarchy = Services.Instance;
            return _CompanyHierarchy.GetRoot();
        }
    }
}
