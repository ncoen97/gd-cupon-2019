using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FrbaOfertas.DAOs
{
    class ClienteDAO
    {
        public static Boolean insertarCliente(Cliente cli,Usuario usu)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_registro_cliente", conexion);
            command.CommandType = CommandType.StoredProcedure;            
            command.Parameters.AddWithValue("@user_username ",usu.username);
            command.Parameters.AddWithValue("@user_pass ",usu.password);
            command.Parameters.AddWithValue("@clie_nombre",cli.nombre);
            command.Parameters.AddWithValue("@clie_apellido",cli.apellido);
            command.Parameters.AddWithValue("@clie_dni",cli.dni);
            command.Parameters.AddWithValue("@clie_email ",cli.mail);
            command.Parameters.AddWithValue("@clie_telefono ",cli.telefono);
            command.Parameters.AddWithValue("@clie_direccion ",cli.direccion);
            command.Parameters.AddWithValue("@clie_codigo_postal ",cli.cod_postal);
            command.Parameters.AddWithValue("@clie_fecha_nacimiento ",cli.fecha_nacimiento);
            command.Parameters.AddWithValue("@clie_ciudad ",cli.habilitado);

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
    }
}
