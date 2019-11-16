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

namespace FrbaOfertas
{
    public class ClienteDAO
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

        public static void filtros_clientes(DataGridView grid, string filtroNombre, string filtroApellido, int filtroDNI, string filtroemail)
        {
            
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_buscar_clientes", conn);
            comando.CommandType = CommandType.StoredProcedure;
            
            comando.Parameters.AddWithValue("@apellido", filtroApellido);
            comando.Parameters.AddWithValue("@email", filtroemail);
            comando.Parameters.AddWithValue("@dni", filtroDNI);
            comando.Parameters.AddWithValue("@nombre", filtroNombre);

            DBConnection.fill_grid(grid, comando);
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }
        public static double montoUsuario(Usuario _usuario)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_montoUsuario", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_name ", _usuario.username);
            
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();

            return Convert.ToDouble(ret.Value.ToString());
        }
        public static Boolean cargarTarjeta(Usuario usuario,string numeroDeTarjeta, 
            int mesVencimiento,int anioVencimiento,string nombreTitular)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_cargarTarjeta", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_name ", usuario.username);
            command.Parameters.AddWithValue("@numero_tarjeta ", numeroDeTarjeta);
            command.Parameters.AddWithValue("@mes_vencimiento", mesVencimiento);
            command.Parameters.AddWithValue("@anio_vencimiento", anioVencimiento);
            command.Parameters.AddWithValue("@titular ", nombreTitular);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return true;
        }
    }
}
