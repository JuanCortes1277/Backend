using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleRESTServer.Models
{
    public class Indicador
    {

        public String Nombre { get; set; }
        public String Unidad_Medida { get; set; }
        public float peso { get; set; }
        public String frecuencia { get; set; }
        public float Limite_Inferior { get; set; }
        public float Li { get; set; }
        public float Meta { get; set; }
        public float Ls { get; set; }
        public float Limite_Superior { get; set; }


       
    }
}