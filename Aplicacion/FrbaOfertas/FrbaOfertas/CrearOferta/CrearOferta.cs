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
    public partial class CrearOferta : Form
    {
        Usuario usuario;
        public CrearOferta(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades o = new MenuFuncionalidades(usuario);
            o.Show();
            this.Hide();
        }
    }
}
