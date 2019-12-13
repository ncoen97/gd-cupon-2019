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
    public partial class EstadoUsuarios : Form
    {

        Usuario usuario;
        SqlDataAdapter adapter1;
        DataTable table1;


        public EstadoUsuarios(Usuario usu)
        {
            InitializeComponent();
            usuario = usu;
        }

        private void EstadoUsuarios_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Usuario", conexion);
            command.CommandType = CommandType.Text;

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();

            adapter1.UpdateCommand = new SqlCommand("SOCORRO.sp_estado_usuario", conexion);
            adapter1.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter1.UpdateCommand.Parameters.Add("@user_habilitado", SqlDbType.Bit, 1, "user_habilitado");
            SqlParameter parameter = adapter1.UpdateCommand.Parameters.Add("@user_id", SqlDbType.Int);
            parameter.SourceColumn = "user_id";
            parameter.SourceVersion = DataRowVersion.Original;

            DBConnection.fill_grid(dataGridView1, command, adapter1, table1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void actualizar()
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Usuario", conexion);
            command.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView1, command, adapter1, table1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                adapter1.Update(table1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el update: " + ex.Message);
            }
            timer1.Interval = 1000;
            timer1.Start();
            button1.BackColor = Color.LawnGreen;
            actualizar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.BackColor = default(Color);
            timer1.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Usuario where user_username LIKE '%'+@nombre+'%'", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@nombre", textBox1.Text);
            DBConnection.fill_grid(dataGridView1, command, adapter1, table1);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ingrese aqui para buscar un usuario")
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades mf = new MenuFuncionalidades(usuario);
            mf.Show();
            this.Hide();
        }
    }
}
