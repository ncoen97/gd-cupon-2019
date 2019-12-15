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

            comboBoxTipoDeUsuario.SelectedIndex = 0;
            comboBox1.Visible = false;
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
                case 4:
                    //Usuarios + roles
                    label10.Text = "Agregar nuevo rol a un usuario seleccionado";
                    label1.Visible = false;
                    comboBox1.Visible = true;
                    foreach (Usuario u in UsuarioDAO.getUsuarios())
                    {
                        comboBox1.Items.Add(u.username);
                        
                    };
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    textboxContraseña.Visible = false;
                    textboxUsuario.Visible = false;
                    label2.Visible = false;
                    label4.Text = "Seleccionar rol nuevo:";
                    this.Text = "Agregar roles";
                    //label 1 y combobox1
                    break;

            }

            
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
            if (textboxContraseña.Visible && textboxUsuario.Visible && !verificarTodosLosCamposNoVacios())
            {
                MessageBox.Show("Parece que hay campos que no estan completos");
                return;
            }

            if (textboxContraseña.Visible && textboxUsuario.Visible && !UsuarioDAO.validarNuevoUsername(textboxUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario ya existe");
                return;
            }
       
            if (!DBConnection.esRolHabilitado((string)comboBoxTipoDeUsuario.SelectedItem))
            {
                MessageBox.Show("Rol deshabilitado. Ponerse en contacto con administrador");
                return;
            }

            Usuario nuevo_usuario;

            if (deDondeViene != 4)
            {

                nuevo_usuario = new Usuario(textboxUsuario.Text, textboxContraseña.Text);

            }
            else
            {
                nuevo_usuario = new Usuario(comboBox1.SelectedItem.ToString());
                UsuarioDAO.cargarRolesUsuario(nuevo_usuario);
                
            }

            
            if ((string)comboBoxTipoDeUsuario.SelectedItem == "Cliente")
            {
                if (nuevo_usuario.roles.Any(rol => DBConnection.isCliente(rol)))
                {
                    MessageBox.Show("Ya tienes asociado este rol");
                    return;
                };
                if (deDondeViene == 4 && ClienteDAO.asignarCliente(nuevo_usuario) == 0)
                {
                    MessageBox.Show("rol cliente asignado a usuario correctamente");
                    UsuarioDAO.cargarRolesUsuario(usuarioActivo);
                    return;
                }
                RegistroDeCliente registroCliente = new RegistroDeCliente(nuevo_usuario, usuarioActivo, deDondeViene);
                registroCliente.Show();
                this.Hide();
            }else if ((string)comboBoxTipoDeUsuario.SelectedItem == "Proveedor")
            {
                if (nuevo_usuario.roles.Any(rol => DBConnection.isProveedor(rol)))
                {
                    MessageBox.Show("Ya tienes asociado este rol");
                    return;
                }
                if (deDondeViene == 4 && ProveedorDAO.asignarProveedor(nuevo_usuario) == 0)
                {
                    MessageBox.Show("rol proveedor asignado a usuario correctamente");
                    UsuarioDAO.cargarRolesUsuario(usuarioActivo);
                    return;
                }
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
