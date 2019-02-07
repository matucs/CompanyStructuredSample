using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CompanyStructured.Common.Models;
using CompanyStructured.Logic;
namespace CompanyStructured.LogicTests
{
    [TestClass()]
    public class HierarchyControllerTests
    {
        [TestMethod()]
        public void Get_all_childrenTest()
        {
            Node node = new Node
            {
                Id = 1,
                name = "CEO",
                parentId = 0
            };
            CompanyHierarchy  companyhierarchytestobj = new CompanyHierarchy();
            IEnumerable <Node> children = companyhierarchytestobj.Get_all_children(node);

        }

        [TestMethod()]
        public void  Change_the_parent_node_of_a_given_node()
        {
            parentchange pc = new parentchange
            {
                id = 2,
                newparentid =4
            };
            CompanyHierarchy companyhierarchytestobj = new CompanyHierarchy();
            bool result = companyhierarchytestobj.Change_the_parent_node_of_a_given_node(pc);

        }
    }
}