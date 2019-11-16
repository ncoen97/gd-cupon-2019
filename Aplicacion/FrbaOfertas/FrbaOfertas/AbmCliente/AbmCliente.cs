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
    public partial class AbmCliente : Form
    {
        Usuario usuario;
        public AbmCliente(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroDeCliente reg = new RegistroDeCliente();
            reg.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuAdministrador reg = new MenuAdministrador(usuario);
            reg.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModificacionDeCliente mod = new ModificacionDeCliente(usuario);
            mod.Show();
            this.Hide();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Cliente", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if cualquiera de los campos no está vacio, se aplica esa busqueda
            string nom = "", ap = "", email = "";
            int dni = 0;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                nom = textBox1.Text;
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ap = textBox2.Text;
            }
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                 Int32.TryParse(textBox3.Text, out dni);
            }
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                email = textBox4.Text;
            }

            ClienteDAO.filtros_clientes(dataGridView1, nom, ap, dni, email);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Cliente", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }
    }
}
