using CompanyStructured.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using CompanyStructured.Logic;
using System.Web.Http;

namespace CompanyStructured.WebAPI.Controllers
{
   
    public class ChangeParentController : System.Web.Http.ApiController
    {
        private CompanyHierarchy _CompanyHierarchy;


        [System.Web.Mvc.HttpPost]
        public bool PostChangeCurrentParent([FromBody] parentchange pc)
        {

            _CompanyHierarchy = Services.Instance;

            bool result = _CompanyHierarchy.Change_the_parent_node_of_a_given_node(pc);

            return result;
        }
    }
}