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
    public partial class RegistroDeCliente : Form
    {
        int deDondeViene;
        Usuario usuarioNuevo;
        Usuario usuarioActivo;
        public RegistroDeCliente()
        {
            InitializeComponent();
        }
        public RegistroDeCliente(Usuario usuNuevo, Usuario usuActivo,int _deDondeViene)
        {
            InitializeComponent();
            usuarioNuevo = usuNuevo;
            usuarioActivo = usuActivo;
            deDondeViene = _deDondeViene;
           
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

        private void Button1_Click(object sender, EventArgs e)
        {
            //validar todos los campos
            
            if (!verificarTodosLosCamposNoVacios())
            {
                MessageBox.Show("Parece que hay campos que no estan completos");
                return;
            }
                        
            utils.validarEntradaSoloNumeros(Cli_dni);
            utils.validarEntradaSoloNumeros(Cli_cp);
            utils.validarEntradaSoloNumeros(Cli_telefono);
            utils.validarEntradaSoloTexto(Cli_apellido);
            utils.validarEntradaSoloTexto(Cli_nombre);
            utils.validarEntradaSoloTexto(Cli_ciudad);
            utils.validarEntradaSoloTexto(Cli_direccion);
            utils.validarEntradaMail(Cli_mail);
            
            foreach(TextBox txb in this.Controls.OfType<TextBox>())
            {
                if (txb.BackColor == Color.WhiteSmoke)
                {
                    MessageBox.Show("hay campos con errores en el  tipo de datos");
                    return;
                }
            }
            try
            {
                Cliente cli = new Cliente(usuarioNuevo, Cli_nombre.Text, Cli_apellido.Text, long.Parse(Cli_dni.Text), DateTime.Parse(Cli_fecha.Text), Cli_direccion.Text, Cli_cp.Text, Cli_mail.Text, Cli_telefono.Text, Cli_ciudad.Text, true);

                if (usuarioActivo == usuarioNuevo)
                {
                    //forma de registro + agregar rol
                    ClienteDAO.insertarCliente(cli, usuarioNuevo, 1);
                }
                else
                {
                    //forma de registro comun
                    ClienteDAO.insertarCliente(cli, usuarioNuevo, 0);
                }
            }
            catch
            {
                MessageBox.Show("hay campos con errores en el  tipo de datos");
            }
            switch (deDondeViene)
            {
                case 1:
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                    break;

                case 2:
                    //ABMcliente
                    AbmCliente abmcli = new AbmCliente(usuarioActivo);
                    abmcli.Show();
                    this.Hide();
                    break;
                case 3:
                    //ABMProveedor
                    AbmProveedor abmProv = new AbmProveedor(usuarioActivo);
                    abmProv.Show();
                    this.Hide();
                    break;
                case 4:
                    //AgregarROl
                    MenuFuncionalidades mf = new MenuFuncionalidades(usuarioActivo);
                    mf.Show();
                    this.Hide();
                    break;
                
            }
         
        }

        private void RegistroDeCliente_Load(object sender, EventArgs e)
        {
            label_usu.Text = "Estas por registrarte con el usuario: " + usuarioNuevo.username;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario reg = new RegistroDeUsuario(deDondeViene, usuarioActivo);
            reg.Show();
            this.Hide();
        }

     
    }
}
