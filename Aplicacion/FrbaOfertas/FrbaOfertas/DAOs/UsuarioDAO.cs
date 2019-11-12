using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FrbaOfertas.DAOs
{
    class UsuarioDAO
    {
        public static int logUsuario(Usuario usuario)
        {
            SqlConnection conexion = DBConnection.getConnection();
            //aca se ejecuta una stored procedure de logear usuario y devuelve el id
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
            return 1;//devuelve el id de usuario
        }
        public static void cargarRolesUsuario(Usuario usuario)
        {
            string query = string.Format(@"SELECT * FROM SOCORRO.getRolesUsuario(@username)");

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@username", usuario.username);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["rol_id"].ToString());
                string nombre = reader["rol_nombre"].ToString();
                bool habilitado = Convert.ToBoolean(reader["rol_habilitado"]);

                Rol rol = new Rol(id, nombre, habilitado);
                usuario.roles.Add(rol);
            }
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
        }
    }
}
