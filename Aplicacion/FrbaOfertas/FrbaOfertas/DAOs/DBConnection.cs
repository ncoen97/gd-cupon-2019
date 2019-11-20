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
    }
}
