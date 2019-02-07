using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyStructured.Common.Models
{
    public class NodeByParentName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DirectParentId { get; set; }
        public string DirectParentName { get; set; }

    }
}