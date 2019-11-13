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
    public partial class OpcionesCliente : Form
    {
        public OpcionesCliente()
        {
            InitializeComponent();
        }

        private void OpcionesCliente_Load(object sender, EventArgs e)
        {
            //deberia recibir el cliente que entra aqui
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CargarCredito cc = new CargarCredito();
            cc.Show();
            this.Hide();
        }
    }
}
