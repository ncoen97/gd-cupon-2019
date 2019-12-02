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
        public MisCupones(Usuario usu)
        {
            usuActivo = usu;
            InitializeComponent();
        }

        private void MisCupones_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("Select cu.cupon_ofer_id,o.ofer_descripcion,o.ofer_fecha_vencimiento from SOCORRO.Cliente cl join SOCORRO.Cupon cu on cl.clie_id = cu.cupon_clie_id_compra join SOCORRO.Oferta o on o.ofer_id = cu.cupon_ofer_id where cl.clie_user_id = @id", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id ", usuActivo.id);
           // command.Parameters.AddWithValue("@id ",114);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
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
    }
}
