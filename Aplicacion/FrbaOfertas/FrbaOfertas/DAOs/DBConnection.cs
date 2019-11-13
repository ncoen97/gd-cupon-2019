using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaOfertas.DAOs
{
    class DBConnection
    {
        public static SqlConnection getConnection()
        {
            SqlConnection conexion = new SqlConnection("server=localhost\\SQLSERVER2012;database=GD2C2019;uid=gdCupon2019;password=gd2019");
            conexion.Open();
            return conexion;
        }
    }
}
