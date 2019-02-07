using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace CompanyStructured.WebAPI
{
    public  static class Share
    {
        public static HttpResponseMessage Json<T>(IEnumerable<T> tenum)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(tenum), Encoding.UTF8, "application/json")
            };
        }
        public static IEnumerable<T> JsonDeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}