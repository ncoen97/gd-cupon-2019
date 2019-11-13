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
    public partial class AbmCliente : Form
    {
        public AbmCliente()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            RegistroDeCliente reg = new RegistroDeCliente();
            reg.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           //menu?
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModificacionDeCliente mod = new ModificacionDeCliente();
            mod.Show();
            this.Hide();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
