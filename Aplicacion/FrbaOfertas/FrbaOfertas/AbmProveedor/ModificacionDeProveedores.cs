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
        public ModificacionDeProveedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmProveedor abmp = new AbmProveedor();
            abmp.Show();
            this.Hide();
        }

        private void ModificacionDeProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
