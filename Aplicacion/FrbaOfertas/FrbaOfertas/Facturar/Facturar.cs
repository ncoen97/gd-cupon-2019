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
    public partial class Facturar : Form
    {
        Usuario usuario;
        public Facturar(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            List<Proveedor> proveedores = ProveedorDAO.getProveedores();
           
            foreach (Proveedor p in proveedores)
            {
                comboBox1.Items.Add(p.razon_social);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_facturar_proveedor", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@usuario_id", usuario.id);
            int prov_id = ProveedorDAO.obtenerProveedorIdConNombre(comboBox1.SelectedItem.ToString());

            command.Parameters.AddWithValue("@prov_id",prov_id);
            command.Parameters.AddWithValue("@fecha_desde",dateTimePicker1.Value);
            command.Parameters.AddWithValue("@fecha_hasta",dateTimePicker2.Value);
            SqlParameter total_facturado = new SqlParameter("@total_facturado", SqlDbType.Int) { Direction = ParameterDirection.Output };
            command.Parameters.Add(total_facturado);
            SqlParameter id_nueva_factura = new SqlParameter("@id_nueva_factura", SqlDbType.Int) { Direction = ParameterDirection.Output };
            command.Parameters.Add(id_nueva_factura);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            switch ((int)ret.Value)
            {
                case -1:
                    MessageBox.Show("no se encontro el admin");
                    break;
                case -2:
                    MessageBox.Show("no se encontro el proveedor");
                    break;
                case -3:
                    MessageBox.Show("las fechas no son coherentes");
                    break;
                case 0:
                        label5.Text = "Nro factura: "+id_nueva_factura.Value.ToString()+ "  Total facturado: "+total_facturado.Value.ToString();
                        mostrar_items(prov_id);        
                    break;
            
            }

            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;            
        }

        public void mostrar_items(int prov_id)
        { 
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SELECT cupon_ofer_id, ofer_descripcion, COUNT(cupon_ofer_id) cantidad, ofer_precio_oferta, (ofer_precio_oferta*COUNT(cupon_ofer_id)) precioxcantidad FROM SOCORRO.Cupon cup JOIN SOCORRO.Oferta o ON o.ofer_id = cup.cupon_ofer_id where ofer_prov_id = @prov_id and @fecha_desde < cupon_fecha_compra and cupon_fecha_compra<@fecha_hasta group by cupon_ofer_id, ofer_descripcion,ofer_precio_oferta order by cantidad desc", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@prov_id",prov_id);
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
            dateTimePicker2.Value = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);
            command.Parameters.AddWithValue("@fecha_desde",dateTimePicker1.Value.ToString());
            command.Parameters.AddWithValue("@fecha_hasta",dateTimePicker2.Value.ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DBConnection.fill_grid(dataGridView1, command, da, dt);
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            
            command.ExecuteReader();        
            command.Dispose();
            conexion.Close();
            conexion.Dispose();
            
                
        
        
        }
    }
}
