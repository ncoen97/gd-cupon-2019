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
            command.Parameters.AddWithValue("@clie_ciudad ",cli.ciudad);
            command.Parameters.AddWithValue("@clie_habilitado ", cli.habilitado);

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

        public static void modificarCliente(Cliente cli, Usuario usu)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_modificar_cliente", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@clie_id", cli.id);
            command.Parameters.AddWithValue("@nuevo_nombre", cli.nombre);
            command.Parameters.AddWithValue("@nuevo_apellido", cli.apellido);
            command.Parameters.AddWithValue("@nuevo_dni", cli.dni);
            command.Parameters.AddWithValue("@nuevo_email ", cli.mail);
            command.Parameters.AddWithValue("@nuevo_telefono ", cli.telefono);
            command.Parameters.AddWithValue("@nuevo_direccion ", cli.direccion);
            command.Parameters.AddWithValue("@nuevo_codigo_postal ", cli.cod_postal);
            command.Parameters.AddWithValue("@nuevo_fecha_nacimiento ", cli.fecha_nacimiento);
            command.Parameters.AddWithValue("@nuevo_ciudad ", cli.ciudad);

            command.ExecuteNonQuery();

            command.Dispose();
            conexion.Close();
            conexion.Dispose();

          
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

        public static Boolean cargarTarjeta(Usuario usuario,int numeroDeTarjeta, 
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
        public static List<TipoDePago> getFormasDePago()
        {
            string query = string.Format(@"SELECT * FROM SOCORRO.getFormasDePago()");

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(query, conexion);

            SqlDataReader reader = command.ExecuteReader();
            List<TipoDePago> tiposDePago = new List<TipoDePago>();
            while (reader.Read())
            {
                int id = int.Parse(reader["tipo_de_pago_id"].ToString());
                string descripcion = reader["tipo_de_pago_descripcion"].ToString();
                TipoDePago tipo = new TipoDePago(id,descripcion);
                tiposDePago.Add(tipo);
            }
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return tiposDePago;
        }

     

        public static List<Tarjeta> getTarjetas(Usuario usuario)
        {
            string query = string.Format(@"SELECT * FROM SOCORRO.getTarjetasUsuario(@username, CONVERT(datetime, @fechaActual,121))");

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@username", usuario.username);
            command.Parameters.AddWithValue("@fechaActual", utils.obtenerFecha());

            SqlDataReader reader = command.ExecuteReader();

            List<Tarjeta> tarjetas = new List<Tarjeta>();

            while (reader.Read())
            {
                int id = int.Parse(reader["tarj_id"].ToString());
                int numero = int.Parse(reader["tarj_numero"].ToString());
                Tarjeta tarjeta = new Tarjeta(id, numero.ToString());
                tarjetas.Add(tarjeta);
            }
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return tarjetas;
        }
        public static int realizarCarga(Usuario usuario, double monto, Tarjeta tarjeta, int formaDePago)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_cargar_credito", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@fecha_operacion ", utils.obtenerFecha());
            command.Parameters.AddWithValue("@user_name ", usuario.username);
            command.Parameters.AddWithValue("@monto ", monto);
            if (tarjeta != null)
            {
                command.Parameters.AddWithValue("@tarj_id ", tarjeta.id);
            }
            else {
                command.Parameters.AddWithValue("@tarj_id ", null);
            }
            command.Parameters.AddWithValue("@tipo_de_pago ", formaDePago);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return (int)ret.Value;
        }

        public static int obtenerIdCliente(Usuario usuario)
        {
            
          SqlConnection conexion = DBConnection.getConnection();
          SqlCommand command = new SqlCommand("SOCORRO.sp_obtener_id_cliente", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userid", usuario.id);
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return (int)ret.Value;
        }

        public static Tarjeta obtenerTarjeta(Usuario usuario, int nrotarjeta)
        {
            string query = string.Format(@"SELECT * FROM SOCORRO.getTarjetaDeUsuario(@username, @nrotarjeta)");

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@username", usuario.username);
            command.Parameters.AddWithValue("@nrotarjeta", nrotarjeta);

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            int id = int.Parse(reader["tarj_id"].ToString());
            int numero = int.Parse(reader["tarj_numero"].ToString());
            Tarjeta tarjeta = new Tarjeta(id, numero.ToString());
            
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return tarjeta;

        }

    }
}
