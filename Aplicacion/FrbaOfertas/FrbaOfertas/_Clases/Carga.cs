using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
   public class Carga
    {
        public Cliente cliente { get; set; }
        public int monto { get; set; }
        public DateTime fecha_carga { get; set; }
        public Tarjeta tarjeta { get; set; }

        public Carga(DateTime _fechaCarga, Tarjeta _tarjeta, Cliente _cliente,int _monto)
        {
            this.fecha_carga = _fechaCarga;
            this.monto = _monto;
            this.cliente = _cliente;
            this.tarjeta = _tarjeta;

        }
    }
}
