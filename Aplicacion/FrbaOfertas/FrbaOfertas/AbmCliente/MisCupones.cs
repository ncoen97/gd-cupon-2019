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
    public partial class MisCupones : Form
    {
        Usuario usuActivo;
        DataGridViewRow selectedRow = null;
        SqlDataAdapter adapter1;
        DataTable table1;
        public MisCupones(Usuario usu)
        {
            usuActivo = usu;
            InitializeComponent();
        }

        private void MisCupones_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label3.Visible = false;
            button3.Visible = false;
            foreach (Rol r in usuActivo.roles)
            {
                if (DBConnection.isAdmin(r))
                {
                    comboBox1.Visible = true;
                    List<Cliente> clientes = ClienteDAO.getClientes();
                    foreach (Cliente c in clientes)
                    {
                        comboBox1.Items.Add(c.id);
                    
                    }
                    label3.Visible = true;
                    button3.Visible = true;
                    comboBox1.SelectedIndex = 0;
                    return;
                }
            }
            
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_mostrar_mis_cupones", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_id", usuActivo.id);
            command.ExecuteNonQuery();

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades mf = new MenuFuncionalidades(usuActivo);
            mf.Show(); this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.selectedRow = dataGridView1.Rows[index];
                label2.Text = selectedRow.Cells["ofer_descripcion"].Value.ToString();
            }
          
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.selectedRow = dataGridView1.Rows[index];
                label2.Text = selectedRow.Cells["ofer_descripcion"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComprarOferta mf = new ComprarOferta(usuActivo);
            mf.Show(); this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_mostrar_mis_cupones", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_id", Convert.ToInt16(comboBox1.SelectedItem));
            command.ExecuteNonQuery();
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_mostrar_mis_cupones", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user_id", usuActivo.id);
            command.ExecuteNonQuery();
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
        }
    }
}
