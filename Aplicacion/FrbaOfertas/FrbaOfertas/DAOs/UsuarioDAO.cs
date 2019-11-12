using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaOfertas.DAOs
{
    class UsuarioDAO
    {
        public static int logUsuario(Usuario usuario)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("", conexion);
            //aca se ejecuta una stored procedure de logear usuario y devuelve el id
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return 1;//devuelve el id de usuario
        }
    }
}
