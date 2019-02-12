using CompanyStructured.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompanyStructured.Common.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace CompanyStructured.WebAPI.Controllers
{

    public class HierarchyController : ApiController
    {
        private ICompanyHierarchy _CompanyHierarchy;
       
        public HttpResponseMessage Get_all_children(int id)
        {

            var container = new WindsorContainer();

            container.Register(Component.For<ICompanyHierarchy>().ImplementedBy<CompanyHierarchy>().LifestyleSingleton());

            // Resolve an object of type ICompanyHierarchy (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            _CompanyHierarchy = container.Resolve<ICompanyHierarchy>();

            Common.Models.Node node = _CompanyHierarchy.Getnode(id);

            IEnumerable<Common.Models.Node> resultsnodes =  _CompanyHierarchy.Get_all_children(node);
 

            return  Share.Json<Common.Models.Node>(resultsnodes);
        }

    }
}
