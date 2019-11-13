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
    public partial class RegistroDeUsuario : Form
    {
        public RegistroDeUsuario()
        {
            InitializeComponent();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //validar datos de registro fnValidarNuevoUsername
            if (!UsuarioDAO.validarNuevoUsername(textboxUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario ya existe");
                return;
            }
            Usuario usu = new Usuario(textboxUsuario.Text, textboxContraseña.Text);
            if ((string)comboBoxTipoDeUsuario.SelectedItem == "Cliente")
            {
                RegistroDeCliente registroCliente = new RegistroDeCliente(usu);
                registroCliente.Show();
                this.Hide();
            }
            else
            {
                RegistroDeProveedores registroProveedor = new RegistroDeProveedores(usu);
                registroProveedor.Show();
                this.Hide();
            }
        }

        private void RegistroDeUsuario_Load(object sender, EventArgs e)
        {
            comboBoxTipoDeUsuario.Items.Add("Cliente");
            comboBoxTipoDeUsuario.Items.Add("Proveedor");
            comboBoxTipoDeUsuario.SelectedItem = "Cliente";
        }

        private void comboBoxTipoDeUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
