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
    public partial class AbmProveedor : Form
    {
        Usuario usuario;
        
        SqlDataAdapter adapter1;
        DataTable table1;
        public AbmProveedor(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroDeProveedores rdp = new RegistroDeProveedores();
            rdp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                adapter1.Update(table1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el update: "+ex.Message);
            }
            timer1.Interval = 1000;
            timer1.Start();
            button6.BackColor = Color.LawnGreen;
        }

        private void AbmProveedor_Load(object sender, EventArgs e)
        {

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();
            SqlCommand command_update = new SqlCommand("SOCORRO.sp_modificar_proveedor",DBConnection.getConnection());
            command_update.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro1 = new SqlParameter();
            parametro1.ParameterName = "@prov_id";
            parametro1.SqlDbType = SqlDbType.Int;
            parametro1.SourceVersion = DataRowVersion.Original;
            parametro1.SourceColumn = "prov_id";
            command_update.Parameters.Add(parametro1);
            SqlParameter parametro2 = new SqlParameter();
            parametro2.ParameterName = "@nuevo_rs";
            parametro2.SourceColumn = "prov_razon_social";
            command_update.Parameters.Add(parametro2);
            SqlParameter parametro3 = new SqlParameter();
            parametro3.ParameterName = "@nuevo_email";
            parametro3.SourceColumn = "prov_email";
            command_update.Parameters.Add(parametro3);
            SqlParameter parametro4 = new SqlParameter();
            parametro4.ParameterName = "@nuevo_dom";
            parametro4.SourceColumn = "prov_direccion";
            command_update.Parameters.Add(parametro4);
            SqlParameter parametro5 = new SqlParameter();
            parametro5.ParameterName = "@nuevo_cp";
            parametro5.SourceColumn = "prov_codigo_postal";
            command_update.Parameters.Add(parametro5);
            SqlParameter parametro6 = new SqlParameter();
            parametro6.ParameterName = "@nuevo_ciudad";
            parametro6.SourceColumn = "prov_ciudad";
            command_update.Parameters.Add(parametro6);
            SqlParameter parametro7 = new SqlParameter();
            parametro7.ParameterName = "@nuevo_telefono";
            parametro7.SourceColumn = "prov_telefono";
            command_update.Parameters.Add(parametro7);
            SqlParameter parametro8 = new SqlParameter();
            parametro8.ParameterName = "@nuevo_cuit";
            parametro8.SourceColumn = "prov_cuit";
            command_update.Parameters.Add(parametro8);
            SqlParameter parametro9 = new SqlParameter();
            parametro9.ParameterName = "@nuevo_rubro_id";
            parametro9.SourceColumn = "prov_rubro_id";
            command_update.Parameters.Add(parametro9);
            SqlParameter parametro10 = new SqlParameter();
            parametro10.ParameterName = "@nuevo_nombre_contacto";
            parametro10.SourceColumn = "prov_nombre_contacto";
            command_update.Parameters.Add(parametro10);
            SqlParameter parametro11 = new SqlParameter();
            parametro11.ParameterName = "@nuevo_habilitado";
            parametro11.SourceColumn = "prov_habilitado";
            command_update.Parameters.Add(parametro11);
            adapter1.UpdateCommand = command_update;

            actualizar();

            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if cualquiera de los campos no está vacio, se aplica esa busqueda
            string razonsocial = "", cuit = "", email = "";
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                razonsocial = textBox1.Text;
            }

            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                email = textBox2.Text;
            }

            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                cuit = textBox3.Text;
            }

            ProveedorDAO.filtros_proveedores(dataGridView1, razonsocial, cuit, email,adapter1,table1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar();
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void actualizar()
        {
            
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select p.prov_id,p.prov_user_id, p.prov_cuit,p.prov_razon_social,p.prov_nombre_contacto,r.rubro_descripcion, p.prov_ciudad,p.prov_codigo_postal,p.prov_direccion,p.prov_telefono,p.prov_email, p.prov_habilitado, p.prov_rubro_id from (SOCORRO.Proveedor p join SOCORRO.Rubro r on p.prov_rubro_id = r.rubro_id) join SOCORRO.RolxUsuario ro on p.prov_user_id = ro.user_id where ro.rol_id = 2", conexion);
            command.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
            dataGridView1.Columns["prov_rubro_id"].Visible = false;
        }

        private void buttonRegistrarProveedor_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario regUsu = new RegistroDeUsuario(3, usuario);
            this.Hide();
            regUsu.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            button6.BackColor = default(Color);
            timer1.Stop();
        }
    }
}