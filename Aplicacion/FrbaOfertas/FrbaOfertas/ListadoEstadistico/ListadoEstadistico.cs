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
    public partial class ListadoEstadistico : Form
    {
        private Usuario usuario;
        SqlDataAdapter adapter1;
        DataTable table1;
        public ListadoEstadistico(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();
            comboBox1.Items.Add("1er semestre");
            comboBox1.Items.Add("2do semestre");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void btn_mayorDescuento_Click(object sender, EventArgs e)
        {
            if (!utils.validarEntradaSoloNumeros(textBox1) || !utils.validarNoVacio(textBox1) || textBox1.Text.Length != 4)
            {
                MessageBox.Show("Hubo un error con la entrada del año ");
                return;
            }
           
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_lista_prov_mayor_descuento", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@semestre", comboBox1.SelectedIndex + 1);
            command.Parameters.AddWithValue("@anio", textBox1.Text);


            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);

            adapter1.Dispose();
            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();
            conexion.Close();
            conexion.Dispose();

        }

        private void btn_mayorFactr_Click(object sender, EventArgs e)
        {
            if (!utils.validarEntradaSoloNumeros(textBox1) || !utils.validarNoVacio(textBox1) || textBox1.Text.Length != 4)
            {
                MessageBox.Show("Hubo un error con la entrada del año ");
                return;
            }

            
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_lista_prov_mayor_facturacion", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@semestre", comboBox1.SelectedIndex+1);
            command.Parameters.AddWithValue("@anio", textBox1.Text);
            
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
            adapter1.Dispose();
            table1 = new DataTable();
            adapter1 = new SqlDataAdapter();
            conexion.Close();
            conexion.Dispose();
        }
    }
}