using CompanyStructured.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace CompanyStructured.WebAPI.Controllers
{
    public class RootController : ApiController
    {
        private ICompanyHierarchy _CompanyHierarchy;


        public Common.Models.Node GetRoot()
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ICompanyHierarchy>().ImplementedBy<CompanyHierarchy>().LifestyleSingleton());

            // Resolve an object of type ICompanyHierarchy (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            _CompanyHierarchy = container.Resolve<ICompanyHierarchy>();
      
            return _CompanyHierarchy.GetRoot();
        }
    }
}
