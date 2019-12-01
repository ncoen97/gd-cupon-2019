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
            Rol rol = usuario.roles.Find(DBConnection.isProveedor);
            DBConnection.asociar_roles_x_funciones(rol);

            foreach (var button in this.Controls.OfType<Button>())
            { //Si hay alguna funcionalidad que coincide con un buton
                button.Visible = false;
                button.Name = button.Text;
                foreach (Funcionalidad f in rol.funcionalidades)
                {
                    if (button.Name == f.nombre)
                    {
                        button.Visible = true;
                    }


                }
            }

            btn_cerrarsesion.Visible = true;
            labelUsuario.Text = usuario.username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsumoOferta co = new ConsumoOferta(usuario);
            co.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearOferta co = new CrearOferta(true,usuario);
            co.Show();
            this.Hide();
        }

        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            usuario = null;
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
