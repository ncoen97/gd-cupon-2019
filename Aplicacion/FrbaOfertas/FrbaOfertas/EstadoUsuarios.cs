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

            adapter1.UpdateCommand = new SqlCommand("SOCORRO.sp_modificar_usuario", conexion);
            adapter1.UpdateCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro1 = new SqlParameter();
            parametro1.ParameterName = "@user_id";
            parametro1.SqlDbType = SqlDbType.Int;
            parametro1.SourceVersion = DataRowVersion.Original;
            parametro1.SourceColumn = "user_id";
            adapter1.UpdateCommand.Parameters.Add(parametro1);
            SqlParameter parametro2 = new SqlParameter();
            parametro2.ParameterName = "@user_username";
            parametro2.SourceColumn = "user_username";
            adapter1.UpdateCommand.Parameters.Add(parametro2);
            SqlParameter parametro3 = new SqlParameter();
            parametro3.ParameterName = "@user_pass";
            parametro3.SourceColumn = "user_pass";
            adapter1.UpdateCommand.Parameters.Add(parametro3);
            SqlParameter parametro4 = new SqlParameter();
            parametro4.ParameterName = "@user_intentos";
            parametro4.SourceColumn = "user_intentos";
            adapter1.UpdateCommand.Parameters.Add(parametro4);
            SqlParameter parametro5 = new SqlParameter();
            parametro5.ParameterName = "@user_habilitado";
            parametro5.SourceColumn = "user_habilitado";
            adapter1.UpdateCommand.Parameters.Add(parametro5);

            DBConnection.fill_grid(dataGridView1, command, adapter1, table1);
            dataGridView1.Columns["user_id"].ReadOnly = true;
            dataGridView1.Columns["user_pass"].ReadOnly = true;
            dataGridView1.Columns["user_username"].ReadOnly = true;

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
            dataGridView1.Columns["user_id"].ReadOnly = true;
            dataGridView1.Columns["user_pass"].ReadOnly = true;
            dataGridView1.Columns["user_username"].ReadOnly = true;
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
            textBox1.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.BackColor = default(Color);
            timer1.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        //    if (textBox1.Text == "")
          //      return;
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Usuario where user_username LIKE '%'+@nombre+'%'", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@nombre", textBox1.Text);
            DBConnection.fill_grid(dataGridView1, command, adapter1, table1);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Puede filtrar por username")
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
