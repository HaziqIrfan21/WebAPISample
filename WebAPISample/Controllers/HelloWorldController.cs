using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace WebAPISample.Controllers
{
    [RoutePrefix("api/Hello")]
    public class HelloWorldController : ApiController
    {
        // GET: HelloWorld
        [Route("")]
       public IEnumerable<string> Get()
        {
            IList<string> list = new List<string>();
            list.Add("This is my first");
            list.Add("API call");
            return list;
        }
        [Route("Find/{id:range(50,100)}")]
        public string Get(int id)
        {
            return "Parameterized Get method with parameters ID: "+id;
        }

        [Route("FindOpt/{name:length(3,5)?}")]
        public string Get(string name="ram")
        {
            return "Parameterized Get method with parameters NAME: " + name;
        }

        [Route("{id:int}/{name}")]
        public string Get(int id, string name)
        {
            return "Parameterized Get method with parameters ID: " + id + " NAME: "+ name;
        }

        [Route("~/v1")]
        public string Get(string id, string name)
        {
            return "Default route Get method with parameters ID: " + id + " NAME: " + name;
        }

        [Route("")]
        public void POST(string id)
        {
        }

        [Route("Find1")]
        public string POST([FromBody] int id)
        {
            return "I am inside Post(Find1) Int: " + id;
        }


        [Route("Find")]
        public Student POST()
        {
            return new Student() { ID = 1, Name = "Irfan" };
        }

        //[Route("Store")]
        //public Student POST(Student stu)
        //{
        //    return stu;
        //}

        [Route("Store1")]
        public Dictionary<int, Student> POST(Student stu, int ID)
        {
            Dictionary<int, Student> dict = new Dictionary<int, Student>();
            dict.Add(ID, stu);
            return dict;
        }

        [Route("Store2")]
        public Student POST([FromUri] Student stu)
        {
            return stu;
        }

        [Route("")]
        public HttpResponseMessage POST(int id, int id1)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            if (id == 100)
                message.StatusCode = System.Net.HttpStatusCode.OK;
            else
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;

            message.ReasonPhrase = "You are calling the post with two int args";
            return message;
        }

        [Route("")]
        public IHttpActionResult POST(int id, int id1, int id2)
        {
            if (id == 100)
                return NotFound();
            else
                return Ok();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}