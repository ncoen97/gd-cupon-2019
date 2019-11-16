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
    public partial class MenuAdministrador : Form
    {
        private Usuario usuario;
        public MenuAdministrador(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmCliente abmc = new AbmCliente(usuario);
            abmc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmProveedor abmp = new AbmProveedor(usuario);
            abmp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbmRol abmr = new AbmRol(usuario);
            abmr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario ru = new RegistroDeUsuario();
            ru.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrearOferta co = new CrearOferta();
            co.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Facturar f = new Facturar(usuario);
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ListadoEstadistico le = new ListadoEstadistico(usuario);
            le.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void MenuAdministrador_Load(object sender, EventArgs e)
        {

        }
    }
}