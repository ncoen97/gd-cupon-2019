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

        private void Button1_Click(object sender, EventArgs e)
        {
            //validar todos los campos

            Cliente cli = new Cliente(usuario,Cli_nombre.Text, Cli_apellido.Text, long.Parse(Cli_dni.Text), DateTime.Parse(Cli_fecha.Text), Cli_direccion.Text, Cli_cp.Text, Cli_mail.Text, Cli_telefono.Text,Cli_ciudad.Text, true);
            ClienteDAO.insertarCliente(cli,usuario);
            Login login = new Login();
            login.Show();

            OpcionesCliente reg = new OpcionesCliente(usuario);
            reg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario reg = new RegistroDeUsuario(false, usuario);
            reg.Show();
            this.Hide();
        }

        private void RegistroDeCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
