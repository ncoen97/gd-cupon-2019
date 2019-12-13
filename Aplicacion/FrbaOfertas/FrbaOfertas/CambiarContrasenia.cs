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
using FrbaOfertas._Clases;


namespace FrbaOfertas
{
    public partial class CambiarContrasenia : Form
    {
        Usuario usuActivo;
         public CambiarContrasenia(Usuario _usu)
        {
            InitializeComponent();
            usuActivo = _usu;
        }

        public bool verificarTodosLosCamposNoVacios()
        {
            foreach (TextBox txb in this.Controls.OfType<TextBox>())
            {
                if (txb.Text == "" && txb.Visible)
                    return false;
            }
            return true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!verificarTodosLosCamposNoVacios())
            {
                MessageBox.Show("Parece que hay campos que no estan completos");
                foreach (TextBox txb in this.Controls.OfType<TextBox>())
                {
                    txb.Text = "";
                 
                }
                return;
            }

            if (passNueva.Text != passNueva2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                foreach (TextBox txb in this.Controls.OfType<TextBox>())
                {
                    txb.Text = "";
                  
                }
                return;
            }

            if (passNueva.Text == passActual.Text)
            {
                MessageBox.Show("Las contraseñas nueva y actual no deben coincidir");
                foreach (TextBox txb in this.Controls.OfType<TextBox>())
                {
                    txb.Text = "";

                }
                return;
            }

            SqlConnection conexion = DBConnection.getConnection();
            SqlCommand command = new SqlCommand("SOCORRO.sp_modificar_usuario", conexion);
            command.CommandType = CommandType.StoredProcedure;
            string usuName;
            if (username.Visible)
            {
                usuName = username.Text;
            }
            else
            {
                usuName = usuActivo.username;
            }
            
            command.Parameters.AddWithValue("@user_username", usuName);
            command.Parameters.AddWithValue("@user_pass_nueva", passNueva.Text);
            command.Parameters.AddWithValue("@user_pass_actual",passActual.Text);
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(ret);
            command.ExecuteReader();
            command.Dispose();
            conexion.Close();
            conexion.Dispose();

            switch((int)ret.Value){
                case -1:
                    MessageBox.Show("No se encontro usuario");
                    break;
                case -2:
                    MessageBox.Show("La contraseña actual no es correcta");
                    break;
                case 0:
                    MessageBox.Show("Contraseña cambiada");
                    //volver de donde vino
                    MenuFuncionalidades mf = new MenuFuncionalidades(usuActivo);
                    mf.Show();
                    this.Hide();
                    break;
                }

        
        }

        private void CambiarContrasenia_Load(object sender, EventArgs e)
        {
           
            if (usuActivo.roles.Exists(rol => rol.nombre == "Administrador"))
            {
                username.Visible = true;

            }
            else
            {
                label1.Text = usuActivo.username;
                username.Visible = false;
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades mf = new MenuFuncionalidades(usuActivo);
            mf.Show();
            this.Hide();
        }
    }
}
