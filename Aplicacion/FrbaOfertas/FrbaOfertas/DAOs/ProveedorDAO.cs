using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace FrbaOfertas.DAOs
{
    class ProveedorDAO
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
    }
}
