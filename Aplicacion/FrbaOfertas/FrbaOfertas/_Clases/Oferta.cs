using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Oferta
    {
        
       
        public string descripcion { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int precio_oferta { get; set; }
        public int precio_lista { get; set; }
        public Proveedor proveedor { get; set; }
        public int cantidad_disponible { get; set; }
      

        public Oferta(string _descripcion, DateTime _fechaPublicacion, DateTime _fechaVencimiento,int _precioOferta,int _precioLista,Proveedor _proveedor,int _cantidadDisponible)
        { 
            this.descripcion = _descripcion;
            this.fecha_publicacion = _fechaPublicacion;
            this.fecha_vencimiento = _fechaVencimiento;
            this.precio_oferta = _precioOferta;
            this.precio_lista = _precioLista;
            this.proveedor = _proveedor;
            this.cantidad_disponible = _cantidadDisponible;

        }

    }
}
