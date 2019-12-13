using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public long dni { get; set; }
        public string mail { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string cod_postal { get; set; }
        public string ciudad { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public bool habilitado { get; set; }
        public int monto { get; set; }
        public List<Tarjeta> tarjetas_asociadas { get; set; }
        public List<Cupon> cupones { get; set; }

        public Cliente(Usuario usu, string _nombre, string _apellido, long _dni, DateTime _fechaNac, string _direccion, string _cod_postal, string _mail, string _telefono,string _ciudad, bool _habilitado)
        {
            this.id = ClienteDAO.obtenerIdCliente(usu);
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.dni = _dni;
            this.mail = _mail;
            this.direccion = _direccion;
            this.telefono = _telefono;
            this.cod_postal = _cod_postal;
            this.fecha_nacimiento = _fechaNac;
            this.habilitado = _habilitado;
            this.ciudad = _ciudad;
            this.monto = 0;
        }

        public Cliente(int _id, string _nombre, string _apellido, long _dni, DateTime _fechaNac, string _direccion, string _cod_postal, string _mail, string _telefono, string _ciudad, bool _habilitado)
        {
            this.id = _id;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.dni = _dni;
            this.mail = _mail;
            this.direccion = _direccion;
            this.telefono = _telefono;
            this.cod_postal = _cod_postal;
            this.fecha_nacimiento = _fechaNac;
            this.habilitado = _habilitado;
            this.ciudad = _ciudad;
        }

        public static Cliente ClienteConId(int _id, Usuario usu, string _nombre, string _apellido, long _dni, DateTime _fechaNac, string _direccion, string _cod_postal, string _mail, string _telefono, string _ciudad, bool _habilitado)
        {
            Cliente c = new Cliente(usu, _nombre,  _apellido,  _dni,  _fechaNac,  _direccion,  _cod_postal,  _mail,  _telefono,  _ciudad,  _habilitado);
            c.id = _id;
            return c;
        }

        public Cliente (int _id, string nombre,bool habi)
        {
            
            this.nombre = nombre;
            this.id = _id;
            this.habilitado = habi;
            
        }
        
    }
}
