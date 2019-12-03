using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FrbaOfertas.DAOs;

namespace FrbaOfertas
{
    public static class DBConnection
    {
        private static string servidor = ConfigurationSettings.AppSettings["server"].ToString();
        private static string user = ConfigurationSettings.AppSettings["user"].ToString();
        private static string password = ConfigurationSettings.AppSettings["password"].ToString();


        public static SqlConnection getConnection()
        {
            SqlConnection conexion = new SqlConnection("server="+servidor+"\\SQLSERVER2012;database=GD2C2019;uid="+user+";password="+password+"");
            conexion.Open();
            return conexion;
        }

        public static void fill_grid(DataGridView dataGrid, SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            BindingSource source = new BindingSource();

            source.DataSource = table;
            dataGrid.DataSource = source;
            adapter.Update(table);

            command.Dispose();
            adapter.Dispose();
        }

        public static bool isAdmin(Rol Rol)
        {
            return Rol.nombre == "Administrador";
        }
        public static bool isCliente(Rol Rol)
        {
            return Rol.nombre == "Cliente";
        }
        public static bool isProveedor(Rol Rol)
        {
            return Rol.nombre == "Proveedor";
        }

        public static int cantidad_roles()
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            // //Select Count(rol_id) from SOCORRO.Rol
            SqlCommand command = new SqlCommand("Select Count(rol_id) from SOCORRO.Rol", conexion);
            command.CommandType = CommandType.Text;
            int cantidad = (Int32)command.ExecuteScalar();
          
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return cantidad;        
        }
             

        public static void registrar_Rol(Rol r)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("INSERT INTO SOCORRO.Rol VALUES (@rol_id,@rol_nombre,0);", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@rol_nombre", r.nombre);
            command.Parameters.AddWithValue("@rol_id", r.id);
       
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            if ((int)ret.Value == 1)
            {
                MessageBox.Show("Hubo un error en el registro del rol");
              
            }
            MessageBox.Show("Rol registrado con exito");
        
            
        }

        public static bool deshabilitar_rol(Rol r)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_deshabilitar_rol", conexion);
            command.CommandType = CommandType.StoredProcedure;
          
            command.Parameters.AddWithValue("@rol_id", r.id);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            if ((int)ret.Value == 1)
            {
                MessageBox.Show("Hubo un error");
                return false;
            }
            MessageBox.Show("Rol inhabilitado con exito");
            return true;

        }

        public static bool rehabilitar_rol(Rol r)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_rehabilitar_rol", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@rol_id", r.id);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            if ((int)ret.Value == 1)
            {
                MessageBox.Show("Hubo un error");
                return false;
            }
            MessageBox.Show("Rol habilitado con exito");
            return true;

        }


        public static void asociar_roles_x_funciones(Rol r)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select rol_nombre,f.func_id,func_descripcion from SOCORRO.Rol r join(SOCORRO.FuncionalidadxRol fxr join SOCORRO.Funcionalidad f on fxr.func_id = f.func_id) on r.rol_id = fxr.rol_id", conexion);
            command.CommandType = CommandType.Text;
            
            SqlDataAdapter sqla = new SqlDataAdapter(command);
            sqla.Fill(dt);
           
            foreach (DataRow dr in dt.Rows)
            {
                if(dr["rol_nombre"].ToString() == r.nombre)
                {
                    Funcionalidad f = new Funcionalidad((int)dr["func_id"], dr["func_descripcion"].ToString());
                    r.funcionalidades.Add(f);
                }
                
            }          
        
        }


        public static void agregar_cupon(Cupon _cupon)
        {
            //Insert into Cupon values (@cupon_id,@cupon_fecha_compra,@cupon_oferta_id,@cupon_clie_id_compra,
		    // @cupon_fecha_consumo,@cupon_clie_id_consumo)
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO SOCORRO.Cupon VALUES (@fecha_compra,@cupon_ofer_id,@cupon_clie_id_compra,null,null);", conn);
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@cupon_id", );
            cmd.Parameters.AddWithValue("@fecha_compra", DateTime.Today);
            cmd.Parameters.AddWithValue("@cupon_ofer_id", _cupon.oferta_referencia.id_oferta);
            cmd.Parameters.AddWithValue("@cupon_clie_id_compra", _cupon.cliente.id );
              
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(ret);
            cmd.ExecuteReader();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            
                
        }

        public static bool encontrar_cupon_para_canjear(string _idcupon)
        {
            //Insert into Cupon values (@cupon_id,@cupon_fecha_compra,@cupon_oferta_id,@cupon_clie_id_compra,
            // @cupon_fecha_consumo,@cupon_clie_id_consumo)
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("Select Count(*) cuentas from SOCORRO.Cupon cu join Socorro.Oferta o on cu.cupon_ofer_id = o.ofer_id  where cu.cupon_ofer_id = @cupon_id and cu.cupon_fecha_consumo is NULL and cupon_clie_id_consumo is null and o.ofer_fecha_vencimiento>GETDATE()", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cupon_id", _idcupon);
            
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int cuponesParaCanjear = Convert.ToInt16(reader["cuentas"]);
            reader.Close();
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return (cuponesParaCanjear >= 1);
        }

        public static void canjear_cupon(string _idcupon, int idclie,DateTime fechaConsumo)
        {
            //Insert into Cupon values (@cupon_id,@cupon_fecha_compra,@cupon_oferta_id,@cupon_clie_id_compra,
            // @cupon_fecha_consumo,@cupon_clie_id_consumo)
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("UPdate top(1) SOCORRO.Cupon SET cupon_clie_id_consumo = @idClie, cupon_fecha_consumo=@fechaConsumo where cupon_ofer_id = @cupon_id", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cupon_id", _idcupon);
            cmd.Parameters.AddWithValue("@idClie", idclie);
            cmd.Parameters.AddWithValue("@fechaConsumo", fechaConsumo);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            
        }

        public static Oferta oferta_por_id(string id_oferta, Proveedor prov)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand(" Select * from SOCORRO.Oferta o where o.ofer_id = @id", conexion);
            command.Parameters.AddWithValue("@id", id_oferta);
           
            //rompe algo de tipos
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
         
            Oferta ofer = new Oferta(id_oferta,
                reader["ofer_descripcion"].ToString(),
                (DateTime)reader["ofer_fecha_publicacion"],
                (DateTime)reader["ofer_fecha_vencimiento"],
               Convert.ToInt16(reader["ofer_precio_oferta"]),
               Convert.ToInt16(reader["ofer_precio_lista"]),
                prov.id,
               Convert.ToInt16(reader["ofer_stock"]),
               Convert.ToInt16(reader["ofer_max_cupon_por_usuario"])
                );

            reader.Close();
            reader.Dispose();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            return ofer;
        }
        public static int comprarOferta(Usuario usuario, string idOferta)
        {
            DateTime fechaActual = utils.obtenerFecha();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_consumirOferta", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_id", usuario.id);
            command.Parameters.AddWithValue("@ofer_id", idOferta);
            command.Parameters.AddWithValue("@fechaActual", fechaActual);
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
