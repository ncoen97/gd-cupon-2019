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
        bool vieneDeLogin;
        Usuario usuarioNuevo;
        Usuario usuarioActivo;
        public RegistroDeProveedores()
        {
            InitializeComponent();
        }
        public RegistroDeProveedores(Usuario _usuActivo, Usuario _usuNuevo, bool _vieneDeLogin)
        {
            InitializeComponent();
            usuarioNuevo = _usuNuevo;
            usuarioActivo = _usuActivo;
            vieneDeLogin = _vieneDeLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //registrar proveedor

            if (!verificarTodosLosCamposNoVacios())
            {
                MessageBox.Show("Parece que hay campos que no estan completos");
                return;
            }

            utils.validarEntradaSoloNumeros(Provee_cp);
            utils.validarEntradaSoloNumeros(Provee_cuit);
            utils.validarEntradaSoloNumeros(Provee_telefono);
            utils.validarEntradaSoloTexto(Provee_rs);
            utils.validarEntradaSoloTexto(Provee_nombrecontacto);
            utils.validarEntradaSoloTexto(Provee_ciudad);
            utils.validarEntradaMail(Provee_mail);
           // utils.validarEntradaComboBoxNoNull(Provee_rubro);

            foreach (ComboBox cbx in this.Controls.OfType<ComboBox>())
            {
                if (cbx.BackColor == Color.Tomato)
                {
                    MessageBox.Show("Combobox vacio");
                    return;
                }
            }
            foreach (TextBox txb in this.Controls.OfType<TextBox>())
            {
                if (txb.BackColor == Color.Tomato)
                {
                    MessageBox.Show("hay campos con errores en el  tipo de datos");
                    return;
                }
            }

            


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
            Proveedor prov = new Proveedor(usuarioNuevo, Provee_rs.Text, Provee_mail.Text, Provee_direccion.Text, Provee_cp.Text, Provee_ciudad.Text, Provee_cuit.Text, prov_id, Provee_nombrecontacto.Text, Provee_telefono.Text, true);
            ProveedorDAO.insertarProveedor(prov, usuarioNuevo);

            if (vieneDeLogin)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else {
                RegistroDeUsuario r = new RegistroDeUsuario(vieneDeLogin, usuarioActivo);
                r.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//atras

            RegistroDeUsuario reg = new RegistroDeUsuario(vieneDeLogin, usuarioActivo);
            reg.Show();
            this.Hide();
        }

        public bool verificarTodosLosCamposNoVacios()
        {
            foreach (TextBox txb in this.Controls.OfType<TextBox>())
            {
                if (txb.Text == "")
                    return false;
            }
            return true;

        }

        private void RegistroDeProveedores_Load(object sender, EventArgs e)
        {
            List<Rubro> rubros = ProveedorDAO.getRubros();
            foreach (Rubro r in rubros)
            {
                Provee_rubro.Items.Add(r.descripcion);
                Provee_rubro.Text = r.descripcion;
            }
            label_usu.Text = "Estas por registrarte con el usuario: " + usuarioNuevo.username;
            
        }

        private void Provee_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
