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
            List<Rol> roles = DBConnection.getRoles();
            comboBox_roles.Items.Clear();
            foreach (Rol ro in roles)
            {
                comboBox_roles.Items.Add(ro.nombre);
            }
            comboBox_roles.SelectedIndex = 0;
            rol_nombre.Text = "";
        }

        private void AbmRol_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rol_id,r.rol_habilitado, r.rol_nombre from SOCORRO.Rol r order by r.rol_id", conexion);
            command.CommandType = CommandType.Text;

            adapter1 = new SqlDataAdapter();
            table1 = new DataTable();

            adapter1.UpdateCommand = new SqlCommand("SOCORRO.sp_modificar_rol", conexion);
            adapter1.UpdateCommand.CommandType = CommandType.StoredProcedure;
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

            comboBox_roles.Items.Clear();
            foreach (Rol r in roles)
            {
                comboBox_roles.Items.Add(r.nombre);
            }
            if(comboBox_roles.Items.Count>0)
            comboBox_roles.SelectedIndex = 0;

            dataGridView1.Columns["rol_id"].ReadOnly = true;
           
       
        }

        private void actualizar()
        {
            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("select r.rol_habilitado, r.rol_id, r.rol_nombre from SOCORRO.Rol r order by rol_id", conexion);
            command.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView1, command,adapter1,table1);
            
            SqlCommand command2 = new SqlCommand("select rol_nombre,r.rol_id,f.func_id, func_descripcion from SOCORRO.Rol r join(SOCORRO.FuncionalidadxRol fxr join SOCORRO.Funcionalidad f on fxr.func_id = f.func_id) on r.rol_id = fxr.rol_id order by r.rol_id", conexion);
            command2.CommandType = CommandType.Text;
            DBConnection.fill_grid(dataGridView2, command2,adapter2,table2);
            
            
            List<Rol> roles = DBConnection.getRoles();
            comboBox_roles.Items.Clear();
            foreach (Rol r in roles)
            {
                comboBox_roles.Items.Add(r.nombre);
            }
            if (comboBox_roles.Items.Count > 0)
                comboBox_roles.SelectedIndex = 0;

            dataGridView1.Columns["rol_id"].ReadOnly = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades oc = new MenuFuncionalidades(usuario);
            oc.Show();
            this.Hide();
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
            timer1.Interval = 1000;
            timer1.Start();
            buttonUpdate.BackColor = Color.LawnGreen;
            actualizar();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsuarioDAO.quitarFuncionalidad(comboBox_funcionalidades.SelectedIndex, comboBox_roles.SelectedIndex);
            actualizar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonUpdate.BackColor = default(Color);
            timer1.Stop();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
