using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.DAOs;
using FrbaOfertas._Clases;

namespace FrbaOfertas
{
    public class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int intentos_login { get; set; }
        public bool habilitado { get; set; }
        public List<Rol> roles { get; set; }

        public Usuario(/*int _id, */string _username, string _password)
        {
          //  this.id = UsuarioDAO.obtenerId(username);
            this.username = _username;
            this.password = _password;
            this.intentos_login = 0;
            this.roles = new List<Rol>();
        }
        public Usuario()
        {

        }
    }
}
