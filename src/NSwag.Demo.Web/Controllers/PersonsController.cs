using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NSwag.Annotations;
using NSwag.Demo.Web.Models;
using NSwag.SwaggerGeneration.WebApi;

namespace Witivio
{
    public class RouteAttribute : Attribute
    {
        public string Template { get; set; }
        public RouteAttribute(string template)
        {
            this.Template = template;
        }
    }
}



namespace NSwag.Demo.Web.Controllers
{
  
    public class Function1
    {
        [NSwag.Annotations.SwaggerResponse(HttpStatusCode.OK, typeof(MyClass))]
        [NSwag.Annotations.SwaggerOperation("MicroService1_GetAll")]
        [Witivio.Route("/api/service1/all")]
        public static async Task<HttpResponseMessage> Get(HttpRequestMessage req, TraceWriter log)
        {
            //var response = await req.Content.ReadAsAsync<ProActiveMessageResponse>();
            string jwt = req.Headers.Authorization.Parameter;



            return req.CreateResponse(HttpStatusCode.OK);
        }
    }

    public class Function2
    {
        [NSwag.Annotations.SwaggerResponse(HttpStatusCode.OK, typeof(MyClass))]
        [NSwag.Annotations.SwaggerOperation("MicroService1_GetById")]
        [Witivio.Route("/api/service1/{id:alpha}")]
        public static async Task<HttpResponseMessage> Get(HttpRequestMessage req, string id, TraceWriter log)
        {
            //var response = await req.Content.ReadAsAsync<ProActiveMessageResponse>();
            string jwt = req.Headers.Authorization.Parameter;



            return req.CreateResponse(HttpStatusCode.OK);
        }
    }

    public class Function3
    {
        [NSwag.Annotations.SwaggerResponse(HttpStatusCode.OK, typeof(void))]
        [NSwag.Annotations.SwaggerOperation("MicroService1_Save")]
        [NSwag.Annotations.SwaggerOperationBody(typeof(MyClassParameter))]
        [Witivio.Route("/api/service1/{id}/save")]
        public static async Task<HttpResponseMessage> Post(HttpRequestMessage req, string id, TraceWriter log)
        {
            //var response = await req.Content.ReadAsAsync<ProActiveMessageResponse>();
            string jwt = req.Headers.Authorization.Parameter;



            return req.CreateResponse(HttpStatusCode.OK);
        }
    }

    public class TraceWriter
    {
    }

    public class MyClass
    {
        public string Foo { get; set; }
    }

    public class MyClassParameter
    {
        public string Foo { get; set; }
    }

    [RoutePrefix("api/Person")]
    public class PersonsController : ApiController
    {
        [HttpPut]
        [Route("xyz/{data}")]
        public string Xyz(MyClass data)
        {
            return "abc";
        }

        // GET: api/Person
        [Obsolete]
        public IEnumerable<Person> Get()
        {
            return new Person[]
            {
                new Person { FirstName = "Foo", LastName = "Bar"},
                new Person { FirstName = "Rico", LastName = "Suter"},
            };
        }

        // GET: api/Person/5
        /// <summary>Gets a person.</summary>
        /// <param name="id">The ID of 
        /// the person.</param>
        /// <returns>The person.</returns>
        [ResponseType(typeof(Person))]
        [ResponseType("500", typeof(PersonNotFoundException))]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new Person { FirstName = "Rico", LastName = "Suter" });
        }

        // POST: api/Person
        /// <summary>Creates a new person.</summary>
        /// <param name="value">The person.</param>
        [HttpPost, Route("")]
        public void Post([FromBody]Person value)
        {
        }

        // PUT: api/Person/5
        /// <summary>Updates the existing person.</summary>
        /// <param name="id">The ID.</param>
        /// <param name="value">The person.</param>
        public void Put(int id, [FromBody]Person value)
        {
        }

        // DELETE: api/Person/5
        [Route("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("Calculate/{a}/{b}")]
        [Description("Calculates the sum of a, b and c.")]
        public int Calculate(int a, int b, [Required]int c)
        {
            return a + b + c;
        }

        [HttpGet]
        [SwaggerIgnore]
        public async Task<HttpResponseMessage> Swagger()
        {
            var generator = new WebApiToSwaggerGenerator(new WebApiAssemblyToSwaggerGeneratorSettings
            {
                DefaultUrlTemplate = Configuration.Routes.First(r => !string.IsNullOrEmpty(r.RouteTemplate)).RouteTemplate
            });
            var document = await generator.GenerateForControllerAsync(GetType());
            return new HttpResponseMessage { Content = new StringContent(document.ToJson(), Encoding.UTF8) };
        }
    }

    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException()
        {
        }

        public int PersonId { get; set; }
    }
}
