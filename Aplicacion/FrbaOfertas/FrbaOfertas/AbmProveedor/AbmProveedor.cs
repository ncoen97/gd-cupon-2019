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
        DataGridViewRow selectedRow = null;
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
            if (selectedRow == null)
                return;

            Proveedor prov = Proveedor.ProveedorConId(
                 (int)selectedRow.Cells[0].Value, //id 0
                 usuario,
                 selectedRow.Cells[2].Value.ToString(), //rs 2
                 selectedRow.Cells[9].Value.ToString(), //mail 9
                 selectedRow.Cells[7].Value.ToString(), //dir 7
                 selectedRow.Cells[6].Value.ToString(), //cp 6 
                 selectedRow.Cells[5].Value.ToString(), //ciudad 5
                 selectedRow.Cells[1].Value.ToString(), //cuit 1
                 (int)selectedRow.Cells[11].Value, //id rubro 11
                 selectedRow.Cells[3].Value.ToString(),//contacto 3
                 selectedRow.Cells[8].Value.ToString(), //telefono 8
                 (bool)selectedRow.Cells[10].Value //habilitado 10
                 );
         
            ModificacionDeProveedores rdp = new ModificacionDeProveedores(prov,usuario);
            rdp.Show();
            this.Hide();
        }

        private void AbmProveedor_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select p.prov_id, p.prov_cuit,p.prov_razon_social,p.prov_nombre_contacto,r.rubro_descripcion,p.prov_ciudad,p.prov_codigo_postal,p.prov_direccion,p.prov_telefono,p.prov_email, p.prov_habilitado, p.prov_rubro_id from SOCORRO.Proveedor p join SOCORRO.Rubro r on p.prov_rubro_id = r.rubro_id", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

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

            ProveedorDAO.filtros_proveedores(dataGridView1, razonsocial, cuit, email);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Proveedor", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void actualizar()
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select p.prov_id, p.prov_cuit,p.prov_razon_social,p.prov_nombre_contacto,r.rubro_descripcion, p.prov_ciudad,p.prov_codigo_postal,p.prov_direccion,p.prov_telefono,p.prov_email, p.prov_habilitado from SOCORRO.Proveedor p join SOCORRO.Rubro r on p.prov_rubro_id = r.rubro_id", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.selectedRow = dataGridView1.Rows[index];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (selectedRow == null)
                return;
            if ((bool)selectedRow.Cells[11].Value)
                return;
            const string message =
            "Esta por dar de baja este proveedor. Es lo que quiere hacer?";
            const string caption = "Inhabilitar proveedor";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Proveedor prov = Proveedor.ProveedorConId(
                (int)selectedRow.Cells[0].Value, //id 0
                usuario,
                selectedRow.Cells[2].Value.ToString(), //rs 2
                selectedRow.Cells[9].Value.ToString(), //mail 9
                selectedRow.Cells[7].Value.ToString(), //dir 7
                selectedRow.Cells[6].Value.ToString(), //cp 6 
                selectedRow.Cells[5].Value.ToString(), //ciudad 5
                selectedRow.Cells[1].Value.ToString(), //cuit 1
                (int)selectedRow.Cells[11].Value, //id rubro 11
                selectedRow.Cells[3].Value.ToString(),//contacto 3
                selectedRow.Cells[8].Value.ToString(), //telefono 8
                (bool)selectedRow.Cells[10].Value //habilitado 10
                );


                ProveedorDAO.darDeBajaProveedor(prov);
                actualizar();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;

            if ((bool)selectedRow.Cells[11].Value)
                return;
                
            const string message =
            "Esta por dar de alta este proveedor. Es lo que quiere hacer?";
            const string caption = "Habilitar proveedor";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Proveedor prov = Proveedor.ProveedorConId(
                (int)selectedRow.Cells[0].Value, //id
                usuario,
                selectedRow.Cells[2].Value.ToString(), //rs
                selectedRow.Cells[9].Value.ToString(), //mail
                selectedRow.Cells[7].Value.ToString(), //dir
                selectedRow.Cells[6].Value.ToString(), //cp
                selectedRow.Cells[5].Value.ToString(), //ciudad
                selectedRow.Cells[1].Value.ToString(), //cuit
                (int)selectedRow.Cells[12].Value,//rubt
                selectedRow.Cells[3].Value.ToString(), //contc
                selectedRow.Cells[8].Value.ToString(), //tel  
                (bool)selectedRow.Cells[11].Value //habilitado
                );


                ProveedorDAO.darDeAltaProveedor(prov);
                actualizar();
            }
        }
    }
}
