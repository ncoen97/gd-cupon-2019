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
        SqlDataAdapter adapter1;
        DataTable table1;
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
            try
            {
                adapter1.Update(table1);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el update");
            }
            timer1.Interval = 1000;
            timer1.Start();
            button6.BackColor = Color.LawnGreen;
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();

            SqlCommand command_update = new SqlCommand("SOCORRO.sp_modificar_cliente", DBConnection.getConnection());
            command_update.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro1 = new SqlParameter();
            parametro1.ParameterName = "@clie_id";
            parametro1.SqlDbType = SqlDbType.Int;
            parametro1.SourceVersion = DataRowVersion.Original;
            parametro1.SourceColumn = "clie_id";
            command_update.Parameters.Add(parametro1);
            SqlParameter parametro2 = new SqlParameter();
            parametro2.ParameterName = "@nuevo_nombre";
            parametro2.SourceColumn = "clie_nombre";
            command_update.Parameters.Add(parametro2);
            SqlParameter parametro3 = new SqlParameter();
            parametro3.ParameterName = "@nuevo_apellido";
            parametro3.SourceColumn = "clie_apellido";
            command_update.Parameters.Add(parametro3);
            SqlParameter parametro4 = new SqlParameter();
            parametro4.ParameterName = "@nuevo_dni";
            parametro4.SourceColumn = "clie_dni";
            command_update.Parameters.Add(parametro4);
            SqlParameter parametro5 = new SqlParameter();
            parametro5.ParameterName = "@nuevo_email";
            parametro5.SourceColumn = "clie_email";
            command_update.Parameters.Add(parametro5);
            SqlParameter parametro6 = new SqlParameter();
            parametro6.ParameterName = "@nuevo_telefono";
            parametro6.SourceColumn = "clie_telefono";
            command_update.Parameters.Add(parametro6);
            SqlParameter parametro7 = new SqlParameter();
            parametro7.ParameterName = "@nuevo_direccion";
            parametro7.SourceColumn = "clie_direccion";
            command_update.Parameters.Add(parametro7);
            SqlParameter parametro8 = new SqlParameter();
            parametro8.ParameterName = "@nuevo_codigo_postal";
            parametro8.SourceColumn = "clie_codigo_postal";
            command_update.Parameters.Add(parametro8);
            SqlParameter parametro9 = new SqlParameter();
            parametro9.ParameterName = "@nuevo_fecha_nacimiento";
            parametro9.SourceColumn = "clie_fecha_nacimiento";
            command_update.Parameters.Add(parametro9);
            SqlParameter parametro10 = new SqlParameter();
            parametro10.ParameterName = "@nuevo_ciudad";
            parametro10.SourceColumn = "clie_ciudad";
            command_update.Parameters.Add(parametro10);
            SqlParameter parametro11 = new SqlParameter();
            parametro11.ParameterName = "@nuevo_habilitado";
            parametro11.SourceColumn = "clie_habilitado";
            command_update.Parameters.Add(parametro11);
            adapter1.UpdateCommand = command_update;

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

            ClienteDAO.filtros_clientes(dataGridView1, nom, ap, dni, email,adapter1,table1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            actualizar();

            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }

        private void actualizar()
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select * from SOCORRO.Cliente c join SOCORRO.RolxUsuario r on c.clie_user_id = r.user_id where rol_id = 1", conexion);
            command.CommandType = CommandType.Text;

            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);        
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
            RegistroDeUsuario ru = new RegistroDeUsuario(2,usuario);
            ru.Show();
            this.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button6.BackColor =default(Color);
            timer1.Stop();
        }
        
   
    }
}