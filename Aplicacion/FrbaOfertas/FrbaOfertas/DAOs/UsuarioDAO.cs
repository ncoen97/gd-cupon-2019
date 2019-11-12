using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FrbaOfertas.DAOs
{
    class UsuarioDAO
    {
        public static int logUsuario(Usuario usuario)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.validarLogin", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", usuario.username);
            command.Parameters.AddWithValue("@password", usuario.password);
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return (int)ret.Value;
        }

    }
}
