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
    public class ProveedorDAO
    {
        public static Boolean insertarProveedor(Proveedor prov, Usuario usu)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_registro_proveedor", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_username", usu.username);
            command.Parameters.AddWithValue("@user_pass", usu.password);
            command.Parameters.AddWithValue("@prov_rs", prov.razon_social);
            command.Parameters.AddWithValue("@prov_email", prov.mail);
            command.Parameters.AddWithValue("@prov_dom", prov.direccion);
            command.Parameters.AddWithValue("@prov_cp", prov.codigo_postal);
            command.Parameters.AddWithValue("@prov_ciudad", prov.ciudad);
            command.Parameters.AddWithValue("@prov_telefono", prov.telefono);
            command.Parameters.AddWithValue("@prov_cuit", prov.cuit);
            command.Parameters.AddWithValue("@prov_rubro_id ", prov.rubro_id);
            command.Parameters.AddWithValue("@prov_nombre_contacto ", prov.nombre_de_contacto);
            command.Parameters.AddWithValue("@prov_habilitado", 1);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            if ((int)ret.Value == 1)
            {
                MessageBox.Show("Hubo un error en el registro");
                return false;
            }
            MessageBox.Show("Registrado con exito");
            return true;
        }

        public static void filtros_proveedores(DataGridView grid, string razonSocial, string cuit, string email,SqlDataAdapter adapter1,DataTable table1)
        {

            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_buscar_proveedores", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@rs", razonSocial);
            comando.Parameters.AddWithValue("@cuit", cuit);
            comando.Parameters.AddWithValue("@mail", email);

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();
            DBConnection.fill_grid(grid, comando,adapter1,table1);
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }

        public static int obtenerIdProveedor(Usuario usuario)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_obtener_id_proveedor", conexion);
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

        public static Proveedor obtenerProveedorConId(int id)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select * from SOCORRO.Proveedor where prov_id = @id", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Proveedor prov = new Proveedor(Convert.ToInt16(reader["prov_user_id"].ToString()), reader["prov_razon_social"].ToString(),
                reader["prov_email"].ToString(), reader["prov_direccion"].ToString(),reader["prov_codigo_postal"].ToString(),reader["prov_ciudad"].ToString(),
                reader["prov_cuit"].ToString(), Convert.ToInt16(reader["prov_rubro_id"].ToString()), reader["prov_nombre_contacto"].ToString(),
                reader["prov_telefono"].ToString(), (bool)reader["prov_habilitado"]);


            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return prov;
       
        }

        public static int obtenerProveedorIdConNombre(string prov_nom)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select * from SOCORRO.Proveedor where prov_razon_social = @id", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", prov_nom);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int i =(int)reader["prov_id"];

            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return i;

        }

        public static void modificarProveedor(Proveedor prov, Usuario usu)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_modificar_proveedor", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@prov_id", prov.id);
            command.Parameters.AddWithValue("@nuevo_rs", prov.razon_social);
            command.Parameters.AddWithValue("@nuevo_email", prov.mail);
            command.Parameters.AddWithValue("@nuevo_dom", prov.direccion);
            command.Parameters.AddWithValue("@nuevo_cp ", prov.codigo_postal);
            command.Parameters.AddWithValue("@nuevo_ciudad ", prov.ciudad);
            command.Parameters.AddWithValue("@nuevo_telefono ", prov.telefono);
            command.Parameters.AddWithValue("@nuevo_cuit ", prov.cuit);
            command.Parameters.AddWithValue("@nuevo_rubro_id ", prov.rubro_id);
            command.Parameters.AddWithValue("@nuevo_nombre_contacto ", prov.nombre_de_contacto);
            command.ExecuteNonQuery();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();

        }

        public static List<Rubro> getRubros()
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Rubro", conexion);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            List<Rubro> rubros = new List<Rubro>();
            while (reader.Read())
            {
                int id = int.Parse(reader["rubro_id"].ToString());
                string descripcion = reader["rubro_descripcion"].ToString();
                Rubro r = new Rubro  (id, descripcion);
                rubros.Add(r);
            }

            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return rubros;
        }

        public static string getRubro(int id_rubro)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rubro_descripcion from SOCORRO.Rubro r where r.rubro_id=@id", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", id_rubro);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string descripcion = reader["rubro_descripcion"].ToString();
            
            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return descripcion;
            
        }


        public static void darDeBajaProveedor(Proveedor proveedor)
        {
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_deshabilitar_proveedor", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@prov_id", proveedor.id);
            comando.ExecuteNonQuery();
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }

        public static void darDeAltaProveedor(Proveedor proveedor)
        {
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_rehabilitar_proveedor", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@prov_id", proveedor.id);
            comando.ExecuteNonQuery();
            comando.Dispose();
            conn.Close();
            conn.Dispose();

        }
        public static Boolean publicarOferta(int provId, string descripcion, DateTime fechaVencimiento,DateTime fechaPublicacion, double precioOferta, double precioLista, int cantidad, int maxPorUsuario)
        {

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_publicar_oferta", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@prov_id", provId);
            command.Parameters.AddWithValue("@fecha_publicacion", fechaPublicacion);
            command.Parameters.AddWithValue("@fecha_vencimiento", fechaVencimiento);
            command.Parameters.AddWithValue("@precio_rebajado", precioOferta);
            command.Parameters.AddWithValue("@precio_original", precioLista);
            command.Parameters.AddWithValue("@stock_disponible ", cantidad);
            command.Parameters.AddWithValue("@max_cantidad_compra_por_cliente ", maxPorUsuario);
            command.Parameters.AddWithValue("@descripcion ", descripcion);

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
        public static Boolean esProveedorHabilitado(Usuario usuario)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select prov_habilitado from SOCORRO.Proveedor p join SOCORRO.RolxUsuario rxu on p.prov_user_id=rxu.user_id where user_id = @user_id", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@user_id", usuario.id);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                bool habilitado = (bool)reader["prov_habilitado"];
                reader.Close();
                reader.Dispose();
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
                return habilitado;
            }
            catch {
                reader.Close();
                reader.Dispose();
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
                return false;
            }
            
         
        }


        public static List<Proveedor> getProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Proveedor order by prov_razon_social desc", conexion);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["prov_id"].ToString());
                string rs = reader["prov_razon_social"].ToString();
                Proveedor prov = new Proveedor(id, rs);
                proveedores.Add(prov);
            }

            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();

            return proveedores;
        }
    }
}
