using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleRESTServer.Models
{
    public class Tarea
    {
        public int id { get; set; }
        public String NombreTarea { get; set; }
        public String DescipcionTarea { get; set; }
    }
}