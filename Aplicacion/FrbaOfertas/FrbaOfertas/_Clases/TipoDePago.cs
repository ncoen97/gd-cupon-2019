using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas._Clases
{
    public class TipoDePago
    {
        public int id { get; set; }
        public string descripcion{ get; set; }

        public TipoDePago (int _id,string _desc)
        {
            id = _id;
            descripcion = _desc;
        }
    }
}
