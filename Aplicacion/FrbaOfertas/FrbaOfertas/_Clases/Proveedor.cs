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
        public string cuit { get; set; }
        public int rubro_id{ get; set; }
        public string nombre_de_contacto { get; set; }
        public bool habilitada { get; set; }
        public string telefono { get; set; }

        public Proveedor(Usuario usu, string rs, string email, string direc, string cp, string ciud, string cuitt, int rubid, string nombre, string tel, bool habilitado)
        {
            id = ProveedorDAO.obtenerIdProveedor(usu);
            razon_social = rs;
            mail = email;
            direccion = direc;
            codigo_postal = cp;
            ciudad = ciud;
            cuit = cuitt;
            rubro_id = rubid;
            nombre_de_contacto = nombre;
            telefono = tel;
            habilitada = habilitado;
        }
        public Proveedor(int _id, string rs, bool _habilitado)
        {
            id = _id;
            razon_social = rs;
            habilitada = _habilitado;
        }
        public static Proveedor ProveedorConId(int _id, Usuario usu, string rs, string email, string direc, string cp, string ciud, string cuitt, int rubid, string nombre, string tel, bool _hab)
        {
            Proveedor p = new Proveedor(usu, rs,  email,  direc,  cp,  ciud,  cuitt,  rubid,  nombre, tel, _hab);
            p.id = _id;
            return p;
        }

        public Proveedor(int _id, string rs, string email, string direc, string cp, string ciud, string cuitt, int rubid, string nombre, string tel, bool habilitado)
        {
            id = _id;
            razon_social = rs;
            mail = email;
            direccion = direc;
            codigo_postal = cp;
            ciudad = ciud;
            cuit = cuitt;
            rubro_id = rubid;
            nombre_de_contacto = nombre;
            telefono = tel;
            habilitada = habilitado;
        }
    }
}
