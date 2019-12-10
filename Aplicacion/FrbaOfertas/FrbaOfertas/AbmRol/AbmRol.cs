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
        SqlDataAdapter adapter1;
        DataTable table1;
        SqlDataAdapter adapter2;
        DataTable table2;
        public AbmRol(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!utils.validarNoVacio(rol_nombre))
            {
                MessageBox.Show("Designar nombre para rol nuevo");
                return;
            
            }
            Rol r = new Rol(rol_nombre.Text, null);
            DBConnection.registrar_Rol(r);
            actualizar();
            rol_nombre.Text = "";
        }

        private void AbmRol_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rol_id,r.rol_habilitado, r.rol_id, r.rol_nombre from SOCORRO.Rol r order by r.rol_id", conexion);
            command.CommandType = CommandType.Text;

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();

            adapter1.UpdateCommand = new SqlCommand("UPDATE SOCORRO.Rol SET rol_nombre = @rol_nombre,rol_habilitado = @rol_habilitado WHERE rol_id = @rol_id",conexion);
            adapter1.UpdateCommand.Parameters.Add("@rol_habilitado", SqlDbType.Bit, 1, "rol_habilitado");
            adapter1.UpdateCommand.Parameters.Add("@rol_nombre", SqlDbType.NVarChar, 20, "rol_nombre");
            SqlParameter parameter = adapter1.UpdateCommand.Parameters.Add("@rol_id", SqlDbType.Int);
            parameter.SourceColumn = "rol_id";
            parameter.SourceVersion = DataRowVersion.Original;

            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
            
            SqlCommand command2 = new SqlCommand("select r.rol_id,r.rol_nombre, f.func_id,f.func_descripcion from SOCORRO.Rol r join SOCORRO.FuncionalidadxRol fxr on fxr.rol_id = r.rol_id join SOCORRO.Funcionalidad f  on f.func_id = fxr.func_id order by r.rol_id,f.func_id", conexion);
            command2.CommandType = CommandType.Text;

            adapter2 = new SqlDataAdapter();
            table2 = new DataTable();
            
            DBConnection.fill_grid(dataGridView2, command2,adapter2,table2);

            List<Funcionalidad> funcs = DBConnection.getFuncs();

            foreach (Funcionalidad f in funcs)
            {
                comboBox_funcionalidades.Items.Add(f.nombre);
            }
            comboBox_funcionalidades.SelectedIndex = 0;
            List<Rol> roles = DBConnection.getRoles();

            foreach (Rol r in roles)
            {
                comboBox_roles.Items.Add(r.nombre);
            }
            comboBox_roles.SelectedIndex = 0;
        }

        private void actualizar()
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rol_habilitado, r.rol_id, r.rol_nombre from SOCORRO.Rol r order by rol_id", conexion);
            command.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
            
            SqlCommand command2 = new SqlCommand("select rol_nombre, func_descripcion from SOCORRO.Rol r join(SOCORRO.FuncionalidadxRol fxr join SOCORRO.Funcionalidad f on fxr.func_id = f.func_id) on r.rol_id = fxr.rol_id order by r.rol_id", conexion);
            command2.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView2, command2,adapter2,table2);

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

        private void button2_Click(object sender, EventArgs e)
        {
            UsuarioDAO.agregarFuncionalidad(comboBox_funcionalidades.SelectedIndex, comboBox_roles.SelectedIndex);
            actualizar();
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                adapter1.Update(table1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el update: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
