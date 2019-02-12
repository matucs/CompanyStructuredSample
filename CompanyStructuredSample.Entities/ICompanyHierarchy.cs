using System.Collections.Generic;
using CompanyStructured.Common.Models;
using CompanyStructuredSample.Repository;

namespace CompanyStructured.Logic
{
    public interface ICompanyHierarchy
    {
        bool Change_the_parent_node_of_a_given_node(parentchange pc);
        int GetHeight(Common.Models.Node n);
        Common.Models.Node Getnode(int nodeid);
        CompanyStructuredSample.Repository.Node GetParent(int id);
        Common.Models.Node GetRoot();
        IEnumerable<Common.Models.Node> Get_all_children(Common.Models.Node n);
        bool Isroot(Common.Models.Node n);
    }
}