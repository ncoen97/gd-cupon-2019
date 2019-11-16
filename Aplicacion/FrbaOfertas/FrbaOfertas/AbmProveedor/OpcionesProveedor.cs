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
    public partial class OpcionesProveedor : Form
    {
        private Usuario usuario;
        public OpcionesProveedor(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void OpcionesProveedor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsumoOferta co = new ConsumoOferta();
            co.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearOferta co = new CrearOferta();
            co.Show();
            this.Hide();
        }
    }
}
