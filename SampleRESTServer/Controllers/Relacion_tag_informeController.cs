using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

using System.Text;
using System.Web.Http;
using SampleRESTServer.Persistencia; 
using SampleRESTServer.Models;
using System.Net.Http;

//importante rest get request: http://localhost:65510/api/Relacion_tag_informe?relacion=Aguas

namespace SampleRESTServer.Controllers
{
    public class Relacion_tag_informeController : ApiController
    {
        // GET: api/Relacion_tag_informe
        /* public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }*/
        /* public List<Relacion_tag_informe> Get(string relacion)
         {
             List<Relacion_tag_informe> milista = new List<Relacion_tag_informe>();
             milista = RetornoRelacionados(relacion);
             return milista;



         }*/
        /// <summary>
        /// get a specific tag by relacion
        /// </summary>
        /// <param name="relacion"></param>
        /// <returns></returns>
        /// GET:api/Relacion_tag_informe?relacion=Aguas
        /// [HttpPost]
        [HttpGet]
        [ActionName("Relacionados")]
         public List<Relacion_tag_informe> ObtenerRelacionados(String relacion)
        //public  List<Relacion_tag_informe> Get(String relacion)
        {

           
            List<Relacion_tag_informe> milista = new List<Relacion_tag_informe>();
            PersistenciaTagReport  mipersistencia = new PersistenciaTagReport();
            milista = mipersistencia.RetornoRelacionados(relacion);
            Relacion_tag_informe[] myarray = milista.ToArray();
            return milista; 
        }

        // GET: api/Relacion_tag_informe/5
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// 
        /// GET:api/Relacion_tag_informe?rela
        // POST: api/Relacion_tag_informe?value.id=
        [HttpPost]
        [ActionName("IngresarInforme")]
        public void Post([FromBody]Relacion_tag_informe value)
        {
      
        
            PersistenciaTagReport tag = new PersistenciaTagReport();
            Boolean id;
            id = tag.GuardarReporte(value);
          //  HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
           // response.Headers.Location = new Uri(Request.RequestUri, String.Format("Relacion_tag_informe/{0}",id));
           // return response;
        }

      /*  public HttpResponseMessage Post([FromBody]string url, string tag, string relacion, string nombre)
        {
            PersistenciaTag tag1 = new PersistenciaTag();
            Relacion_tag_informe mitag = new Relacion_tag_informe();
            mitag.Nombre = nombre;
            mitag.Relation = relacion;
            mitag.Informe_Url = url;
            mitag.Tag = tag;
            Boolean id;
            id = tag1.GuardarTag(mitag);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Relacion_tag_informe/{0}", id));
            return response;
        }*/
    

        // PUT: api/Relacion_tag_informe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Relacion_tag_informe/5
        public void Delete(int id)
        {
        }



    }
}