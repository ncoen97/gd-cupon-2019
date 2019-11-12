using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Canje
    {
        public Oferta oferta { get; set; }
        public DateTime fecha_consumo{ get; set; }
        public Cliente cliente { get; set; }

        public Canje (DateTime _fechaConsumo, Oferta _oferta, Cliente _cliente)
        {
            this.fecha_consumo = _fechaConsumo;
            this.oferta = _oferta;
            this.cliente = _cliente;

        }
    }
}
