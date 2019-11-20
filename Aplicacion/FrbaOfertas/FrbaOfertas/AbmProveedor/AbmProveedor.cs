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
            MenuAdministrador reg = new MenuAdministrador(usuario);
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
                (int)selectedRow.Cells[0].Value, //id
                usuario,
                selectedRow.Cells[2].Value.ToString(), //rs
                selectedRow.Cells[3].Value.ToString(), //mail
                selectedRow.Cells[5].Value.ToString(), //tel
                selectedRow.Cells[6].Value.ToString(), //dir
                selectedRow.Cells[7].Value.ToString(), //cp
                selectedRow.Cells[8].Value.ToString(), //ciudad
                (int)selectedRow.Cells[9].Value, //cuit
                selectedRow.Cells[10].Value.ToString(),//rubt
                selectedRow.Cells[4].Value.ToString(), //contc
                (bool)selectedRow.Cells[11].Value //habilitado
                );
         
            ModificacionDeProveedores rdp = new ModificacionDeProveedores(prov,usuario);
            rdp.Show();
            this.Hide();
        }

        private void AbmProveedor_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.selectedRow = dataGridView1.Rows[index];
            }
        }
    }
}
