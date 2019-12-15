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
        public static Boolean insertarCliente(Cliente cli,Usuario usu, int tipoDeRegistro)
        {
            
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_registro_cliente", conexion);
            command.CommandType = CommandType.StoredProcedure;            
            command.Parameters.AddWithValue("@user_username ",usu.username);

            string pass;
            if (tipoDeRegistro == 1)
            {
                pass = "0";
            }
            else
            {
                pass = usu.password;
            }

            command.Parameters.AddWithValue("@user_pass ", pass);
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
            command.Parameters.AddWithValue("@tipo_de_registro", tipoDeRegistro);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            if ((int)ret.Value == 1 || (int)ret.Value==2)
            {
                MessageBox.Show("Hubo un error en el registro");
                return false;
            }
            MessageBox.Show("Registrado con exito");
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

        public static void filtros_clientes(DataGridView grid, string filtroNombre, string filtroApellido, int filtroDNI, string filtroemail,SqlDataAdapter adapter1,DataTable table1)
        {
            
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_buscar_clientes", conn);
            comando.CommandType = CommandType.StoredProcedure;
            
            comando.Parameters.AddWithValue("@apellido", filtroApellido);
            comando.Parameters.AddWithValue("@email", filtroemail);
            comando.Parameters.AddWithValue("@dni", filtroDNI);
            comando.Parameters.AddWithValue("@nombre", filtroNombre);

            DBConnection.fill_grid(grid, comando,adapter1,table1);
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }

        public static void darDeBajaCliente(Cliente cliente)
        {
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_deshabilitar_cliente", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@clie_id", cliente.id);
            comando.ExecuteNonQuery();
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }

        public static void darDeAltaCliente(Cliente cliente)
        {
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_rehabilitar_cliente", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@clie_id", cliente.id);
            comando.ExecuteNonQuery();
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }


        public static int asignarCliente(Usuario usu)
        {
            //si edvuelve 0 exitio y fue linkeado otra vez
            //si devuelve 1 hay que crearlo de 0
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_reasignar_cliente", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@user_id", usu.id);
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conn.Close();
            conn.Dispose();

            return (int)ret.Value;

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

        public static bool verificarMaxPermitidaPorUsuario(Cliente _cliente,Oferta _oferta)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(" Select Count(*) from SOCORRO.Cliente cl join SOCORRO.Cupon cu on cl.clie_id = cu.cupon_clie_id_compra join SOCORRO.Oferta o on o.ofer_id = cu.cupon_ofer_id where cupon_ofer_id=@cupon_id and cl.clie_id = @idcliente", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@cupon_id ", _oferta.id_oferta);
            command.Parameters.AddWithValue("@idcliente ", _cliente.id);

            int cantidad = (Int32)command.ExecuteScalar();

            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return (cantidad < _oferta.cantidad_max_por_persona);        
        }

        public static int cargarTarjeta(Usuario usuario,string numeroDeTarjeta,int mesVencimiento,int anioVencimiento,string nombreTitular)
        {
            DateTime fechaActual = utils.obtenerFecha();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_cargarTarjeta", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_name ", usuario.username);
            command.Parameters.AddWithValue("@numero_tarjeta ", numeroDeTarjeta);
            command.Parameters.AddWithValue("@mes_vencimiento", mesVencimiento);
            command.Parameters.AddWithValue("@anio_vencimiento", anioVencimiento);
            command.Parameters.AddWithValue("@titular ", nombreTitular);
            command.Parameters.AddWithValue("@fechaActual ", fechaActual);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();

            return (int)ret.Value;
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
                string numero = reader["tarj_numero"].ToString();
                Tarjeta tarjeta = new Tarjeta(id, numero);
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
            else 
            {
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




        public static Tarjeta obtenerTarjeta(Usuario usuario, string nrotarjeta)
        {
            string query = string.Format(@"SELECT * FROM SOCORRO.getTarjetaDeUsuario(@username, @nrotarjeta)");

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(query, conexion);

            command.Parameters.AddWithValue("@username", usuario.username);
            command.Parameters.AddWithValue("@nrotarjeta", nrotarjeta);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = int.Parse(reader["tarj_id"].ToString());
            string numero = reader["tarj_numero"].ToString();
            Tarjeta tarjeta = new Tarjeta(id, numero);

            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return tarjeta;

        }

        public static Cliente cliente_from_usuario(Usuario _usuario)
        {

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select * from SOCORRO.Cliente c where c.clie_user_id =@id", conexion);
            command.Parameters.AddWithValue("@id", _usuario.id);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Cliente c = new Cliente(_usuario, reader["clie_nombre"].ToString(), reader["clie_apellido"].ToString(),
                Convert.ToInt64(reader["clie_dni"]), (DateTime)reader["clie_fecha_nacimiento"],
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

        public static int cliente_id_from_nombre(string _nombre)
        {

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select * from SOCORRO.Cliente where clie_nombre = @clie_nombre", conexion);
            command.Parameters.AddWithValue("@clie_nombre", _nombre);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id_cliente = Convert.ToInt16(reader["clie_id"]);
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return id_cliente;

        }

        public static bool verificarExistenciaCliente (int idCliente)
        {

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select Count(*) cuentas  from SOCORRO.Cliente where clie_id = @clie_id", conexion);
            command.Parameters.AddWithValue("@clie_id", idCliente);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id_cliente = Convert.ToInt16(reader["cuentas"]);
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return (id_cliente==1);

        }

        public static bool esClienteHabilitado(Usuario usuario)
        {

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select top 1 * from SOCORRO.Cliente where clie_user_id = @clie_id order by clie_id desc", conexion);
            command.Parameters.AddWithValue("@clie_id", usuario.id);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id_cliente = Convert.ToInt16(reader["clie_habilitado"]);
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return (id_cliente==1);

        }
        

        public static List<Cliente> getClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Cliente", conexion);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
              
                string c = reader["clie_nombre"].ToString();
                int id = Convert.ToInt16(reader["clie_id"].ToString());
                bool habilitado =(bool)reader["clie_habilitado"];
                Cliente clie = new Cliente(id, c,habilitado);
                clientes.Add(clie);
            }

            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();

            return clientes;
        }

    }
}
