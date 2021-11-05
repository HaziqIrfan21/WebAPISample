using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPISample.Controllers
{
    public class HelloWorldWithAttributeController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> FindValues()
        {
            IList<string> list = new List<string>();
            list.Add("This is my first");
            list.Add("API call from Hello World Attribute");
            return list;
        }

        [HttpGet]
        public string FindValuesWithParam(int id)
        {
            return "I am calling this from parameterized Get method from HelloController With attribute with parameter: " + id;
        }
    }
}
