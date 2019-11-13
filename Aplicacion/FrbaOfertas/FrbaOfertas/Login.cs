using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaOfertas.DAOs;

namespace FrbaOfertas
{
    public partial class Login : Form
    {
        private Usuario usuario;

        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.usuario = new Usuario(textbox_usuario.Text, textbox_contraseña.Text);
            if (string.IsNullOrEmpty(textbox_usuario.Text) || string.IsNullOrEmpty(textbox_contraseña.Text))
            {
                MessageBox.Show("Error: Ambos campos deben estar completos");
                return;
            }
            //se fija en la base si existe el usuario, devuelve el userid
            int respuesta = UsuarioDAO.logUsuario(usuario);
            if (respuesta == -1)
            {
                MessageBox.Show("Error: Usuario o contraseña incorrectos");
            }
            else if(respuesta == -2)
            {
                MessageBox.Show("Error: Usuario bloqueado, contactarse con el administrador");
            }
            else
            {
                usuario.id = respuesta;
                usuario.password = ""; //limpiamos la pass por seguridad
                MessageBox.Show("Bienvenido " + usuario.username + "!", "Login satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textbox_contraseña.Visible = false;
                textbox_usuario.Visible = false;
                buttonIniciarSesion.Visible = false;
                buttonRegistrarse.Visible = false;
                buttonCerrarSesion.Visible = true;
                buttonSeleccionarRol.Visible = true;

                UsuarioDAO.cargarRolesUsuario(usuario);
                //agrego todas las views
                foreach (Rol rol in usuario.roles)
                {
                    cboRoles.Items.Add(rol);
                    cboRoles.DisplayMember = "nombre";
                    cboRoles.ValueMember = "id";

                }
                if (usuario.roles.Count == 0)
                {
                    MessageBox.Show("Al parecer no tiene Roles asignados, porfavor contáctese con el Administrador", "Error Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    Application.Restart();
                    return;
                }
                if (usuario.roles.Count == 1)
                {
                 //   Form form = new MenuPrincipalForm(usuario, usuario.roles.First());
               //     form.Show();
             //       this.Hide();
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario ru = new RegistroDeUsuario();
            ru.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textbox_contraseña.Visible = true;
            textbox_usuario.Visible = true;
            buttonIniciarSesion.Visible = true;
            buttonRegistrarse.Visible = true;
            buttonCerrarSesion.Visible = false;
            buttonSeleccionarRol.Visible = false;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonSeleccionarRol_Click(object sender, EventArgs e)
        {
            
        }
    }
}
