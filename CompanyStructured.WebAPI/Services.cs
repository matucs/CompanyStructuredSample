using CompanyStructured.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyStructured.WebAPI
{

    public sealed class Services
    {
        static readonly CompanyHierarchy _instance = new CompanyHierarchy();
        public static CompanyHierarchy Instance
        {
            get
            {
                return _instance;
            }
        }
        Services()
        {
            
        }
    }
}