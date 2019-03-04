using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleRESTServer.Models;
using SampleRESTServer.Persistencia;
namespace SampleRESTServer.Controllers
{
    public class IndicadorController : ApiController
    {
        // GET: api/Indicador
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Indicador/5
        public string Get(int id)
        {
            return "value";
        }
      

        // POST: api/Indicador
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Indicador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Indicador/5
        public void Delete(int id)
        {
        }
    }
}
