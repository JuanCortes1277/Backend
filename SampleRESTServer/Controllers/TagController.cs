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
    public class TagController : ApiController
    {
        // GET: api/Tag
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [ActionName("ObtenerTag")]
        public Tag obtenerTag(string nombre)
        { Tag Tagretornado = new Tag();
            PersistenciaTag miTag = new PersistenciaTag();
           Tagretornado= miTag.retornoTag(nombre);
            return Tagretornado;
        }
        [HttpGet]
        [ActionName("GuardarTag")]
        public void GuardarTag(Tag mitag)
        {
            PersistenciaTag PT = new PersistenciaTag();
           // PT.ingresarTag(mitag);
        }
        /*  public Tag retornotag()
          {

          }*/

        // GET: api/Tag/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tag
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
        }
    }
}
