using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleRESTServer.Models
{
    public class Person
    {
        
        public String Nombre { get; set; }
        public String Username { get; set; }
        public String Contrasena { get; set; }
        public String Rol { get; set; }
        public int id { get; set; }
        public String Area { get; set; }
        public String Email { get; set; }
    }
}