using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class ModificacionDeCliente: Form
    {
        Cliente cliente;
        Usuario usuario;
        public ModificacionDeCliente(Cliente _cliente,Usuario _usuario)
        {
            InitializeComponent();
            cliente = _cliente;
            usuario = _usuario;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           Cliente cli = Cliente.ClienteConId(cliente.id,usuario,Cli_nombre.Text, Cli_apellido.Text, long.Parse(Cli_dni.Text), DateTime.Parse(dateTimePicker1.Text), Cli_direccion.Text, Cli_cp.Text, Cli_mail.Text, Cli_telefono.Text, Cli_ciudad.Text, true);
           ClienteDAO.modificarCliente(cli, usuario);
           AbmCliente abmc = new AbmCliente(usuario);
           abmc.Show();
           this.Hide();
        }

        private void RegistroDeCliente_Load(object sender, EventArgs e)
        {
            Cli_nombre.Text = cliente.nombre.ToString();
            Cli_apellido.Text = cliente.apellido.ToString();
            Cli_ciudad.Text = cliente.ciudad.ToString();
            Cli_cp.Text = cliente.cod_postal.ToString();
            Cli_direccion.Text = cliente.direccion.ToString();
            Cli_dni.Text = cliente.dni.ToString();
            Cli_mail.Text = cliente.mail.ToString();
            Cli_telefono.Text = cliente.telefono.ToString();
            dateTimePicker1.Value = cliente.fecha_nacimiento;
            label12.Text = cliente.id.ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmCliente abmc = new AbmCliente(usuario);
            abmc.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
