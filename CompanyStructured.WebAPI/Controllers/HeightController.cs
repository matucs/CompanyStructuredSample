using CompanyStructured.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyStructured.WebAPI.Controllers
{
    public class HeightController : ApiController
    {
        private CompanyHierarchy _CompanyHierarchy;

        [HttpGet]
        public int GetHeight(int id)
        {
            _CompanyHierarchy = Services.Instance;
            Common.Models.Node n = _CompanyHierarchy.Getnode(id);
            return _CompanyHierarchy.GetHeight(n);
        }
    }
}
