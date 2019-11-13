using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Funcionalidad
    {

        public int id { get; private set; }
        public string nombre { get; set; }

        public Funcionalidad(int _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }

    }
}

