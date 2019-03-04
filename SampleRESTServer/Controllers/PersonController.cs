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
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<string> Get()
        {

            return new string[] { "Person1", "Person2" };
        }




       /* public Person Get(String Username)
        {


            List<Relacion_tag_informe> milista = new List<Relacion_tag_informe>();
            //PersistenciaTag mipersistencia = new PersistenciaTag();
         //   milista = mipersistencia.RetornoRelacionados(relacion);
           // Relacion_tag_informe[] myarray = milista.ToArray();
        //    return milista;
        }*/
        // GET: api/Person/5
        public Person Get(int id)
        {

            return null;
        }
        public Person Get(string value)
        {
            PersistenciaUser PU = new PersistenciaUser();
            Person mipersona = new Person();
            mipersona=PU.RetornoUsuario(value);
            return mipersona;
        }

        // POST: api/Person
        [HttpPost]
        [ActionName("AddPersona")]
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersistenciaUser persona = new PersistenciaUser();
            Boolean id;
            id = persona.GuardarPersona(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Person/{0}", id));
            return response;

        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]Person value)
        {
           
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
