using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleRESTServer.Models;

namespace SampleRESTServer.Models
{
    public class Roles_Tareas
    {
        public int ID { get; set; }
        public int IDROL { get; set; }
        public int IDTarea { get; set; }
        public List<Tarea> tareasporrol = new List<Tarea>();



    }
}