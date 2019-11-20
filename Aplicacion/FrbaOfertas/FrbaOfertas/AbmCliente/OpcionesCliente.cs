using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaOfertas.DAOs;

namespace FrbaOfertas
{
    public partial class OpcionesCliente : Form
    {
        private Usuario usuario;
        public OpcionesCliente(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void OpcionesCliente_Load(object sender, EventArgs e)
        {
            Rol rol = usuario.roles.Find(DBConnection.isCliente);
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
                if (button.Name == "Mis cupones")
                {
                    button.Visible = true;
                }
            }
            
            labelUsuario.Text = usuario.username;
            double monto = ClienteDAO.montoUsuario(usuario);
            labelCredito.Text = monto.ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CargarCredito cc = new CargarCredito(usuario);
            cc.Show();
            this.Hide();
        }
    }
}
