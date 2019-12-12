using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas.DAOs;
using FrbaOfertas._Clases;

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

        public static void cargarRolesUsuario(Usuario usuario)
        {
            usuario.roles.Clear();
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
        public static Boolean validarNuevoUsername(string username)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.fnValidarNuevoUsername", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            if ((int)ret.Value == 1)
            {
                return false;
            }
            return true;
        }

        public static Cliente cliente_from_usuario(Usuario _usuario) {
            
   
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select * from SOCORRO.Cliente c where c.clie_user_id =@id", conexion);
            command.Parameters.AddWithValue("@id",_usuario.id);

            SqlDataReader reader = command.ExecuteReader();
           reader.Read();
           Cliente c = new Cliente(_usuario, reader["clie_nombre"].ToString(), reader["clie_apellido"].ToString(),
               (long)reader["clie_dni"], Convert.ToDateTime(reader["clie_fecha_nacimiento"].ToString()),
               reader["clie_direccion"].ToString(), reader["clie_codigo_postal"].ToString(),
               reader["clie_email"].ToString(), reader["clie_telefono"].ToString(),
               reader["clie_ciudad"].ToString(), (bool)reader["clie_habilitado"]);


         
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return c;

        }

               
        public static bool tieneFuncionalidad(Rol rol, string unaFuncionalidad)
        {
            foreach (Funcionalidad f in rol.funcionalidades)
            {
                if (f.nombre == unaFuncionalidad)
                {
                    return true;
                }
            }

            return false;
        }
        public static void agregarFuncionalidad(int func_id,int rol_id)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_agregar_func", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@func_id", func_id+ 1);
            command.Parameters.AddWithValue("@rol_id", rol_id + 1);
            command.ExecuteNonQuery();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
        }
        public static void quitarFuncionalidad(int func_id, int rol_id)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_quitar_func", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@func_id", func_id + 1);
            command.Parameters.AddWithValue("@rol_id", rol_id + 1);
            command.ExecuteNonQuery();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
        }
    }
}
