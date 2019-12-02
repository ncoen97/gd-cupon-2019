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
    public partial class ComprarOferta : Form
    {
     
        Usuario usuario;
        public ComprarOferta()
        {
            InitializeComponent();
        }

        public ComprarOferta(Usuario _usuario)
        {
            InitializeComponent();
      
            usuario = _usuario;
        }

        private void ComprarOferta_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Oferta", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            label2.Text = "su monto disponible es " + ClienteDAO.montoUsuario(usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }
    }
}
