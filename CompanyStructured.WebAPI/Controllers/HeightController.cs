using Castle.MicroKernel.Registration;
using Castle.Windsor;
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
        private ICompanyHierarchy _CompanyHierarchy;

        [HttpGet]
        public int GetHeight(int id)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ICompanyHierarchy>().ImplementedBy<CompanyHierarchy>().LifestyleSingleton());

            // Resolve an object of type ICompanyHierarchy (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            _CompanyHierarchy = container.Resolve<ICompanyHierarchy>();
            Common.Models.Node n = _CompanyHierarchy.Getnode(id);
            return _CompanyHierarchy.GetHeight(n);
        }
    }
}
