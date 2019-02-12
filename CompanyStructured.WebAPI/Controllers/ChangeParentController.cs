using CompanyStructured.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using CompanyStructured.Logic;
using System.Web.Http;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace CompanyStructured.WebAPI.Controllers
{
   
    public class ChangeParentController : System.Web.Http.ApiController
    {
        private ICompanyHierarchy _CompanyHierarchy;


        [System.Web.Mvc.HttpPost]
        public bool PostChangeCurrentParent([FromBody] parentchange pc)
        {

            var container = new WindsorContainer();

            container.Register(Component.For<ICompanyHierarchy>().ImplementedBy<CompanyHierarchy>().LifestyleSingleton());

            // Resolve an object of type ICompanyHierarchy (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            _CompanyHierarchy = container.Resolve<ICompanyHierarchy>();

            bool result = _CompanyHierarchy.Change_the_parent_node_of_a_given_node(pc);

            return result;
        }
    }
}