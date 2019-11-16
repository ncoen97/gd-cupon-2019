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
    public partial class ModificacionDeProveedores : Form
    {
        Usuario usuario;
        public ModificacionDeProveedores(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmProveedor abmp = new AbmProveedor(usuario);
            abmp.Show();
            this.Hide();
        }

        private void ModificacionDeProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
