using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
   public class Cupon
    {
        public DateTime fecha_compra { get; set; }
        public Oferta oferta_referencia { get; set; }
        public Cliente cliente { get; set; }

        public Cupon(DateTime _fechaCompra, Oferta _ofertaReferida, Cliente _cliente)
        {
            this.fecha_compra = _fechaCompra;
            this.oferta_referencia = _ofertaReferida;
            this.cliente = _cliente;        

        }

    }
}
