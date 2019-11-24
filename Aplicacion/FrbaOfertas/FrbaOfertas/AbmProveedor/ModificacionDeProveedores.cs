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
        Proveedor prov;
        public ModificacionDeProveedores(Proveedor _prov, Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
            prov = _prov;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor prv = Proveedor.ProveedorConId(prov.id, usuario, Provee_rs.Text, Provee_mail.Text, Provee_direccion.Text, Provee_cp.Text, Provee_ciudad.Text, Provee_cuit.Text, comboBox_rubro.SelectedIndex+1,Provee_nombrecontacto.Text, Provee_telefono.Text, true);
            ProveedorDAO.modificarProveedor(prv, usuario);
            AbmProveedor abmp = new AbmProveedor(usuario);
            abmp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmProveedor abmp = new AbmProveedor(usuario);
            abmp.Show();
            this.Hide();
        }

        private void ModificacionDeProveedores_Load(object sender, EventArgs e)
        {
            List<Rubro> rubros = ProveedorDAO.getRubros();
            foreach (Rubro r in rubros)
            {
                comboBox_rubro.Items.Add(r.descripcion);
            }

            Provee_rs.Text = prov.razon_social;
            Provee_ciudad.Text = prov.ciudad;
            Provee_cp.Text = prov.codigo_postal;
            Provee_cuit.Text = prov.cuit;
            Provee_direccion.Text = prov.direccion;
            Provee_mail.Text = prov.mail;
            Provee_nombrecontacto.Text = prov.nombre_de_contacto;
            comboBox_rubro.Text = ProveedorDAO.getRubro(prov.rubro_id);
            Provee_telefono.Text = prov.telefono;
            label12.Text = prov.id.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
