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
        int deDondeViene;
        Usuario usuarioActivo;
        public RegistroDeUsuario(int _deDondeViene,Usuario _usuario)
        {
            InitializeComponent();
            deDondeViene = _deDondeViene;
            comboBoxTipoDeUsuario.Items.Add("Cliente");
            comboBoxTipoDeUsuario.Items.Add("Proveedor");
          
            
            switch (_deDondeViene)
            { 
                
                case 2:
                    //ABMcliente
                    comboBoxTipoDeUsuario.SelectedItem = "Cliente";
                    comboBoxTipoDeUsuario.Enabled = false;
                    break;
                case 3:
                    //ABMProveedor
                    comboBoxTipoDeUsuario.SelectedItem = "Proveedor";
                    comboBoxTipoDeUsuario.Enabled = false;
                    break;
            }

            comboBoxTipoDeUsuario.SelectedIndex = 0;
            usuarioActivo = _usuario;
        }
        private void Atras_Click(object sender, EventArgs e)
        {
           switch(deDondeViene)
           {
               case 1:
                   Login log = new Login();
                   log.Show();
                   break;
               case 2:
                   AbmCliente cli = new AbmCliente(usuarioActivo);
                   cli.Show();
                   break;
               case 3:
                   AbmProveedor prov = new AbmProveedor(usuarioActivo);
                   prov.Show();
                   break;
               default:
                    MenuFuncionalidades menu = new MenuFuncionalidades(usuarioActivo);
                    menu.Show();
                   break;
           }
         
            this.Hide();
            
        }

        public bool verificarTodosLosCamposNoVacios()
        {
            foreach (TextBox txb in this.Controls.OfType<TextBox>())
            {
                if (txb.Text == "")
                    return false;
            }
            return true;

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            //validar datos de registro fnValidarNuevoUsername
            if (!verificarTodosLosCamposNoVacios())
            {
                MessageBox.Show("Parece que hay campos que no estan completos");
                return;
            }

            if (!UsuarioDAO.validarNuevoUsername(textboxUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario ya existe");
                return;
            }
       
            if (!DBConnection.esRolHabilitado((string)comboBoxTipoDeUsuario.SelectedItem))
            {
                MessageBox.Show("Rol deshabilitado. Ponerse en contacto con administrador");
                return;
            }
            Usuario nuevo_usuario = new Usuario(textboxUsuario.Text, textboxContraseña.Text);
            if ((string)comboBoxTipoDeUsuario.SelectedItem == "Cliente")
            {
                RegistroDeCliente registroCliente = new RegistroDeCliente(nuevo_usuario, usuarioActivo, deDondeViene);
                registroCliente.Show();
                this.Hide();
            }else if ((string)comboBoxTipoDeUsuario.SelectedItem == "Proveedor")
            {
                RegistroDeProveedores registroProveedor = new RegistroDeProveedores(usuarioActivo, nuevo_usuario, deDondeViene);
                registroProveedor.Show();
                this.Hide();
            }
        }

        private void RegistroDeUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBoxTipoDeUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
