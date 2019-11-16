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
        Usuario usuario;
        public ModificacionDeCliente(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //validar todos los campos
        }

        private void RegistroDeCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmCliente abmc = new AbmCliente(usuario);
            abmc.Show();
            this.Hide();
        }
    }
}
