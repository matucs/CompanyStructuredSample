using CompanyStructured.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyStructured.WebAPI
{

    public sealed class Services
    {
        public readonly ICompanyHierarchy _instance ;
        private Services(ICompanyHierarchy companyHierarchy)
        {
            this._instance = companyHierarchy;
        }
    }
}