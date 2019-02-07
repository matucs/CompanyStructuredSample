using CompanyStructured.Common.Models;
using CompanyStructuredSample.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructured.Logic
{
    public class CompanyHierarchy
    {
        private List<CompanyStructured.Common.Models.Node> nodes;

        public bool Isroot(CompanyStructured.Common.Models.Node n)
        {
            bool result = false;
            using (var ctx = new CompanyStructuredContext())
            {
                result = n.Equals(ctx.Node.Where(r => r.ParentId.Equals(0)).First())
                         ? true : false;
            }
            return result;
        }
        public CompanyStructured.Common.Models.Node GetRoot()
        {
            using (var ctx = new CompanyStructuredContext())
            {
                CompanyStructuredSample.Repository.Node node = ctx.Node.Where(r => r.ParentId == null ).FirstOrDefault();
                CompanyStructured.Common.Models.Node comnode = new CompanyStructured.Common.Models.Node
                {
                    Id = node.Id,
                    name = node.Name,
                    parentId= node.ParentId
                };
                return comnode;
            }
        }
        public int GetHeight(CompanyStructured.Common.Models.Node n)
        {
            int height = 0;
            CompanyStructuredSample.Repository.Node rnode = new CompanyStructuredSample.Repository.Node
            {
                Id = n.Id,
                Name =n.name,
                ParentId = n.parentId
            };

            using (var ctx = new CompanyStructuredContext())
            {   
                while(rnode.ParentId !=null)
                {
                   Common.Models.Node node = Getnode(n.Id);
                   rnode = GetParent(rnode.Id);
                   height++;
                }
                return height;
            }
        }
        public CompanyStructuredSample.Repository.Node GetParent(int id)
        {
            CompanyStructured.Common.Models.Node n = Getnode(id);
            CompanyStructured.Common.Models.Node parent;
            if (n.parentId is  null)
                parent = GetRoot();
            else
            {
                int index = (int)n.parentId;
                parent = Getnode(index);
            }
            CompanyStructuredSample.Repository.Node rparent = new CompanyStructuredSample.Repository.Node
            {
                Id = parent.Id,
                Name = parent.name,
                ParentId = parent.parentId               
            };
            return rparent;
        }
        public NodeByParentName GetNodeWithParentName(int id)
        {
           CompanyStructured.Common.Models.Node n = Getnode(id);
            NodeByParentName nodebyparentname = new NodeByParentName
            {
                Id = n.Id,
                Name = n.name,
                DirectParentId = n.parentId,
                DirectParentName = nodes.Where(r => r.Id == n.parentId).Select(nn => nn.name).FirstOrDefault()
            };
            return nodebyparentname;
        }
        public CompanyStructured.Common.Models.Node Getnode(int nodeid)
        {
            nodes = new List<Common.Models.Node>();
            using (var ctx = new CompanyStructuredContext())
            {
                CompanyStructuredSample.Repository.Node findednode = ctx.Node.Where(r => r.Id == nodeid).Single();
                CompanyStructured.Common.Models.Node n = new CompanyStructured.Common.Models.Node
                {
                    Id = findednode.Id,
                    name = findednode.Name,
                    parentId = findednode.ParentId
                };
                if (n.parentId is null)
                    return GetRoot();
                return n;
            }
        }
        public IEnumerable<CompanyStructured.Common.Models.Node> Get_all_children(CompanyStructured.Common.Models.Node n)
        {
            using (var ctx = new CompanyStructuredContext())
            {
                IQueryable<CompanyStructuredSample.Repository.Node> ns = ctx.Node.Where(child => child.ParentId == n.Id);
                foreach (var node in ns)
                {
                    CompanyStructured.Common.Models.Node nodmodel = new Common.Models.Node
                    {
                        Id = node.Id,
                        name = node.Name,
                        parentId = node.ParentId
                    };
                    nodes.Add(nodmodel);
                    Get_all_children(nodmodel);
                }
                return nodes;
            }
        }
        //It's supposed if changed the parentid of given node the parent of their children dont changed
        public bool Change_the_parent_node_of_a_given_node(parentchange pc)
        {
            using (var ctx = new CompanyStructuredContext())
            {
                CompanyStructuredSample.Repository.Node given_node =  ctx.Node.SingleOrDefault(nc => nc.Id == pc.id);
                given_node.ParentId = pc.newparentid;
                ctx.Node.Attach(given_node);
                ctx.Entry(given_node).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            //IEnumerable<CompanyStructured.Common.Models.Node> nodes = Get_all_children(n);
            ////it's needed to change parent of the given node either
            //nodes.ToList().Add(n);
            //nodes.ToList().ForEach(x => x.parentId = newparent.Id);

            //using (var ctx = new CompanyStructuredContext())
            //{
            //    foreach (var item in nodes)
            //    {
            //        CompanyStructuredSample.Repository.Node itemmap = new CompanyStructuredSample.Repository.Node
            //        {
            //            Id = n.Id,
            //            Name = n.name,
            //            ParentId = n.parentId
            //        };
            //        ctx.Node.Attach(itemmap);
            //        ctx.Entry(itemmap).State = System.Data.Entity.EntityState.Modified;
            //    }
            //    try
            //    {
            //        ctx.SaveChanges();
            //        return true;
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}
        }
    }
}
