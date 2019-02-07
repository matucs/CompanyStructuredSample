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

namespace CompanyStructured.WebAPI.Controllers
{

    public class HierarchyController : ApiController
    {
        private CompanyHierarchy _CompanyHierarchy;
       
        public HttpResponseMessage Get_all_children(int id)
        {
            _CompanyHierarchy = Services.Instance;

            Node node = _CompanyHierarchy.Getnode(id);
            IList<NodeByParentName> resultsviewmodel = new List<NodeByParentName>();
            IEnumerable<Node> resultsnodes = _CompanyHierarchy.Get_all_children(node);
            foreach (var nd in resultsnodes)
            {
                resultsviewmodel.Add(ConvertViewModelToNodeByParentName(nd.Id));
            }

            return Share.Json<NodeByParentName>(resultsviewmodel);
        }
        public NodeByParentName ConvertViewModelToNodeByParentName(int id)
        {
            return _CompanyHierarchy.GetNodeWithParentName(id);
        }
    }
}
