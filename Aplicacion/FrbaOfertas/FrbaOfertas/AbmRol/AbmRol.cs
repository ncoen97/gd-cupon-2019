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
    public partial class AbmRol : Form
    {
        Usuario usuario;
        DataGridViewRow selectedRow = null;
        public AbmRol(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Rol r = new Rol(rol_nombre.Text, null);
            DBConnection.registrar_Rol(r);
        }

        private void AbmRol_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rol_habilitado, r.rol_id, r.rol_nombre from SOCORRO.Rol r order by rol_id", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            DataTable dt2 = new DataTable();
            SqlCommand command2 = new SqlCommand("select rol_nombre, func_descripcion from SOCORRO.Rol r join(SOCORRO.FuncionalidadxRol fxr join SOCORRO.Funcionalidad f on fxr.func_id = f.func_id) on r.rol_id = fxr.rol_id order by r.rol_id", conexion);
            command2.CommandType = CommandType.Text;

            SqlDataAdapter da2 = new SqlDataAdapter(command2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
           
        }

        private void actualizar()
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rol_habilitado, r.rol_id, r.rol_nombre from SOCORRO.Rol r order by rol_id", conexion);
            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            DataTable dt2 = new DataTable();
            SqlCommand command2 = new SqlCommand("select rol_nombre, func_descripcion from SOCORRO.Rol r join(SOCORRO.FuncionalidadxRol fxr join SOCORRO.Funcionalidad f on fxr.func_id = f.func_id) on r.rol_id = fxr.rol_id order by r.rol_id", conexion);
            command2.CommandType = CommandType.Text;

            SqlDataAdapter da2 = new SqlDataAdapter(command2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades oc = new MenuFuncionalidades(usuario);
            oc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;

            const string message =
            "Esta por habilitar este rol. Es lo que quiere hacer?";
            const string caption = "Habilitar rol";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Rol rol = new Rol(
                (int)selectedRow.Cells[1].Value,
                selectedRow.Cells[2].Value.ToString(),
                (bool)selectedRow.Cells[0].Value
                );

                DBConnection.rehabilitar_rol(rol);
                actualizar();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;

            const string message =
            "Esta por deshabilitar este rol. Es lo que quiere hacer?";
            const string caption = "Deshabilitar rol";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
             
                Rol rol = new Rol(
                (int)selectedRow.Cells[1].Value,
                selectedRow.Cells[2].Value.ToString(),
                (bool)selectedRow.Cells[0].Value
                );

                DBConnection.deshabilitar_rol(rol);
                actualizar();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.selectedRow = dataGridView1.Rows[index];
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = null;
        }
    }
}
