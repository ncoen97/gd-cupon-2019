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
    }
}
