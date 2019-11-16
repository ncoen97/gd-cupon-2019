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
    public partial class RegistroDeProveedores : Form
    {
        Usuario usuario;
        public RegistroDeProveedores()
        {
            InitializeComponent();
        }
        public RegistroDeProveedores(Usuario usu)
        {
            InitializeComponent();
            usuario = usu;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //registrar proveedor
            int prov_id;
            if(Provee_rubro.Text.Equals("Comestibles", StringComparison.InvariantCultureIgnoreCase))
            {
                prov_id = 1;
            }
            else if (Provee_rubro.Text.Equals("Electronica", StringComparison.InvariantCultureIgnoreCase))
            {
                prov_id = 2;
            }
            else if (Provee_rubro.Text.Equals("Hoteleria", StringComparison.InvariantCultureIgnoreCase))
            {
                prov_id = 3;
            }
            else
            {
                MessageBox.Show("Rubro no existente, las opciones son: Comestibles, Electronica o Hoteleria");
                return;
            }
            Proveedor prov = new Proveedor(Provee_rs.Text, Provee_mail.Text, Provee_direccion.Text, Provee_cp.Text, Provee_ciudad.Text, Provee_cuit.Text, prov_id, Provee_nombrecontacto.Text, Provee_telefono.Text);
            ProveedorDAO.insertarProveedor(prov, usuario);
            Login login = new Login();
            login.Show();

            OpcionesProveedor reg = new OpcionesProveedor(usuario);
            reg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {//atras
            RegistroDeUsuario reg = new RegistroDeUsuario();
            reg.Show();
            this.Hide();
        }

        private void RegistroDeProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
