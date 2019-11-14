using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FrbaOfertas.DAOs
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
    }
}
