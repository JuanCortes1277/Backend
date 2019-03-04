using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleRESTServer.Models
{
    public class Relacion_tag_informe
    {

       public int ID { get; set; }
        public String Informe_Url { get; set; }
        public List<Tag> mistags = new List<Tag>() ;
        public String Tag { get; set; }
        public String Relation { get; set; }
        public String Nombre { get; set; } 
        public String Descripcion { get; set; }
        public String Tipo { get; set; }
        public String Area { get; set; }
        public String Grafica { get; set; }
        public String DescripcionTag { get; set; }
     
    }

    
}