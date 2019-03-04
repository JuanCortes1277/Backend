using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleRESTServer.Models
{
    public class Tag
    {
        public int id { get; set; }
        public string tipoTag { get; set; }
        public string DescripcionTag { get; set; }
    }
}