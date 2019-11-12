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
                MessageBox.Show("Error: usuario o contraseña incorrectos");
            }
            else
            {
                usuario.id = respuesta;
                usuario.password = ""; //limpio contraseña por seguridad
                MessageBox.Show("Bienvenido " + usuario.username + "!", "Login satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool esCliente = false;
                if (esCliente)
                {
                    OpcionesCliente oc = new OpcionesCliente();
                    oc.Show();
                    this.Hide();
                }
                else
                {

                    OpcionesProveedor op = new OpcionesProveedor();
                    op.Show();
                    this.Hide();
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

        }
    }
}
