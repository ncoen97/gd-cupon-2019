using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Proveedor
    {
        public int id { get; set; }
        public string razon_social { get; set; }
        public string mail { get; set; }
        public string direccion { get; set; }
        public string codigo_postal { get; set; }
        public string ciudad { get; set; }
        public bool habilitada { get; set; }
        //public rubro;
    }
}
