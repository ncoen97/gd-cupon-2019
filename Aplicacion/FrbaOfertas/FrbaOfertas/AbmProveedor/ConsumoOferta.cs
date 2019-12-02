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
    public partial class ConsumoOferta : Form
    {
        Usuario usuario;
        public ConsumoOferta(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades o = new MenuFuncionalidades(usuario);
            o.Show();
            this.Hide();
        }
    }
}
