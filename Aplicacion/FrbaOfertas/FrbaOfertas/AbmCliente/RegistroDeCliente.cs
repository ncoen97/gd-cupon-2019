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
        Usuario usuario;
        public RegistroDeCliente()
        {
            InitializeComponent();
        }
        public RegistroDeCliente(Usuario usu)
        {
            InitializeComponent();
            usuario = usu;
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
                if (txb.BackColor == Color.Tomato)
                {
                    MessageBox.Show("hay campos con errores en el  tipo de datos");
                    return;
                }
            }


            Cliente cli = new Cliente(usuario,Cli_nombre.Text, Cli_apellido.Text, long.Parse(Cli_dni.Text), DateTime.Parse(Cli_fecha.Text), Cli_direccion.Text, Cli_cp.Text, Cli_mail.Text, Cli_telefono.Text,Cli_ciudad.Text, true);
            ClienteDAO.insertarCliente(cli,usuario);
            Login login = new Login();
            login.Show();
            this.Hide();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario reg = new RegistroDeUsuario();
            reg.Show();
            this.Hide();
        }

        private void RegistroDeCliente_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
