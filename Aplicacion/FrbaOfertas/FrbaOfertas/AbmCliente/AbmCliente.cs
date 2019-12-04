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
        DataGridViewRow selectedRow = null;
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
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;

            Cliente cliente = Cliente.ClienteConId (
                (int)selectedRow.Cells["clie_id"].Value, //id
                usuario,
                selectedRow.Cells["clie_nombre"].Value.ToString(), //nombre
                selectedRow.Cells["clie_apellido"].Value.ToString(), //apellido
                long.Parse(selectedRow.Cells["clie_dni"].Value.ToString()), //dni
                DateTime.Parse(selectedRow.Cells["clie_fecha_nacimiento"].Value.ToString()), //fecha nac
                selectedRow.Cells["clie_direccion"].Value.ToString(), //direccion
                selectedRow.Cells["clie_codigo_postal"].Value.ToString(), //cod_p
                selectedRow.Cells["clie_email"].Value.ToString(), //mail
                selectedRow.Cells["clie_telefono"].Value.ToString(),//telefono
                selectedRow.Cells["clie_ciudad"].Value.ToString(), //ciudad
                (bool)selectedRow.Cells["clie_habilitado"].Value //habilitado
                );
           ModificacionDeCliente mod = new ModificacionDeCliente(cliente,usuario);
           mod.Show();
           this.Hide();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {

            actualizar();

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


        private void button2_Click(object sender, EventArgs e)
        {
            actualizar();

            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }

        private void actualizar()
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Cliente", conexion);
            command.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView1, command);        
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
            const string message =
            "Esta por dar de baja este cliente. Es lo que quiere hacer?";
            const string caption = "Inhabilitar cliente";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                Cliente cliente = Cliente.ClienteConId(
                (int)selectedRow.Cells["clie_id"].Value, //id
                usuario,
                selectedRow.Cells["clie_nombre"].Value.ToString(), //nombre
                selectedRow.Cells["clie_apellido"].Value.ToString(), //apellido
                long.Parse(selectedRow.Cells["clie_dni"].Value.ToString()), //dni
                DateTime.Parse(selectedRow.Cells["clie_fecha_nacimiento"].Value.ToString()), //fecha nac
                selectedRow.Cells["clie_direccion"].Value.ToString(), //direccion
                selectedRow.Cells["clie_codigo_postal"].Value.ToString(), //cod_p
                selectedRow.Cells["clie_email"].Value.ToString(), //mail
                selectedRow.Cells["clie_telefono"].Value.ToString(),//telefono
                selectedRow.Cells["clie_ciudad"].Value.ToString(), //ciudad
                (bool)selectedRow.Cells["clie_habilitado"].Value //habilitado
                );
                ClienteDAO.darDeBajaCliente(cliente);
                actualizar();
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;
            const string message =
            "Esta por dar de alta este cliente. Es lo que quiere hacer?";
            const string caption = "Habilitar cliente";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Cliente cliente = Cliente.ClienteConId (
                (int)selectedRow.Cells["clie_id"].Value, //id
                usuario,
                selectedRow.Cells["clie_nombre"].Value.ToString(), //nombre
                selectedRow.Cells["clie_apellido"].Value.ToString(), //apellido
                long.Parse(selectedRow.Cells["clie_dni"].Value.ToString()), //dni
                DateTime.Parse(selectedRow.Cells["clie_fecha_nacimiento"].Value.ToString()), //fecha nac
                selectedRow.Cells["clie_direccion"].Value.ToString(), //direccion
                selectedRow.Cells["clie_codigo_postal"].Value.ToString(), //cod_p
                selectedRow.Cells["clie_email"].Value.ToString(), //mail
                selectedRow.Cells["clie_telefono"].Value.ToString(),//telefono
                selectedRow.Cells["clie_ciudad"].Value.ToString(), //ciudad
                (bool)selectedRow.Cells["clie_habilitado"].Value //habilitado
                );

                ClienteDAO.darDeAltaCliente(cliente);
                actualizar();
            }
        }
    }
}