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
    public class Roles_TareasController : ApiController
    {
        // GET: api/Roles_Tareas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        [ActionName("InsertarTareaROl")]
        public void insertarTareaRol(Roles_Tareas mitarea)
        {
            PersistenciaRol_Tarea PRT = new PersistenciaRol_Tarea();
            PRT.isertarRol_Tarea(mitarea);
        }
        [HttpPost]
        [ActionName("InsertarTarea")]
        public void insertarTarea(Tarea mitarea)
        {
            string tareaDescripcion = mitarea.DescipcionTarea;
            string NombreTarea = mitarea.NombreTarea;
            PersistenciaTarea PRT = new PersistenciaTarea();
            PRT.guardarTarea(NombreTarea,tareaDescripcion);
        }
        [HttpPost]
        [ActionName("InsertarRolConTareas")]
        public void insertarRolConTareas(Rol mirol)
        {
            PersisteneciaRol PR = new PersisteneciaRol();

            PR.GuardarRolConTareas(mirol);


        }

        // GET: api/Roles_Tareas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Roles_Tareas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Roles_Tareas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Roles_Tareas/5
        public void Delete(int id)
        {
        }
    }
}
