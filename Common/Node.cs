using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace CompanyStructured.Common.Models
{
    public class Node
    {
        public int Id { get; set; }
        [DisplayName("Name")] 
        public string name { get; set; }
        [DisplayName("Parent")]
        public Nullable<int> parentId { get; set; }
    }
}