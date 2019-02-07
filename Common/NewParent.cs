using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructured.Common.Models
{
    public class NewParent
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("New ParentID")]
        public int newParentId { get; set; }
    }
}
