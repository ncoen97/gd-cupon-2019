using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Factura
    {
        public Proveedor proveedor { get; set; }
        public int monto_total { get; set; }
        public List<Cupon> cupones_vendidos { get; set; }
        public DateTime fecha_factura { get; set; }

        public Factura(DateTime _fechaFacturacion, Proveedor _proveedor, int _monto_total,List<Cupon> _cuponesVendidos)
        {
            this.proveedor = _proveedor;
            this.monto_total = _monto_total;
            this.fecha_factura = _fechaFacturacion;
            this.cupones_vendidos = _cuponesVendidos;

        }
    }
}
