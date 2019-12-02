using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Oferta
    {

        public string id_oferta { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int precio_oferta { get; set; }
        public int precio_lista { get; set; }
        public int proveedorid { get; set; }
        public int cantidad_disponible { get; set; }
        public int cantidad_max_por_persona { get; set; }
      

        public Oferta(string _id, string _descripcion, DateTime _fechaPublicacion, DateTime _fechaVencimiento,int _precioOferta,int _precioLista,int _proveedorid,int _cantidadDisponible, int _maxPorPersona)
        {
            this.id_oferta = _id;
            this.descripcion = _descripcion;
            this.fecha_publicacion = _fechaPublicacion;
            this.fecha_vencimiento = _fechaVencimiento;
            this.precio_oferta = _precioOferta;
            this.precio_lista = _precioLista;
            this.proveedorid = _proveedorid;
            this.cantidad_disponible = _cantidadDisponible;
            this.cantidad_max_por_persona = _maxPorPersona;

        }

    }
}
