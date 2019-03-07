using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleRESTServer.Models;

namespace SampleRESTServer.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string NombreROl { get; set; }
        public string DescripcionRol { get; set; }
        public List<int> tareas = new List<int>();


    }
}