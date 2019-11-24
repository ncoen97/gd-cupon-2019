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

        public static void filtros_proveedores(DataGridView grid, string razonSocial, string cuit, string email)
        {

            SqlConnection conn = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SOCORRO.sp_buscar_proveedores", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@rs", razonSocial);
            comando.Parameters.AddWithValue("@cuit", cuit);
            comando.Parameters.AddWithValue("@mail", email);

            DBConnection.fill_grid(grid, comando);
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
            //command.CommandType = CommandType.Text;
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

    }
}
