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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //validar datos del usuario
            //contar 
            // no solo a la vista de clientes s
            bool esCliente = false;
            if (esCliente)
            {
                OpcionesCliente oc = new OpcionesCliente();
                oc.Show();
                this.Hide();
            } else {

                OpcionesProveedor op = new OpcionesProveedor();
                op.Show();
                this.Hide();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario ru = new RegistroDeUsuario();
            ru.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
