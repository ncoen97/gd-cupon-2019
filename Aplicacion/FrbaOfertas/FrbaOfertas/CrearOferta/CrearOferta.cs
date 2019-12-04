using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas._Clases;

namespace FrbaOfertas
{
    public partial class CrearOferta : Form
    {
        Usuario usuario;
        Boolean esProveedor;
        public CrearOferta(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void CrearOferta_Load(object sender, EventArgs e)
        {
            esProveedor = ProveedorDAO.esProveedor(usuario);

            dateTimePicker1.MinDate = utils.obtenerFecha();
            if (esProveedor)
            {
                labelProveedor.Hide();
                comboBoxProveedor.Hide();
            }
            else
            {
                List<Proveedor> proveedores = ProveedorDAO.getProveedores();
                foreach (Proveedor p in proveedores)
                {
                    ComboboxItem item = new ComboboxItem(p.razon_social, p);
                    comboBoxProveedor.Items.Add(item);
                }
                comboBoxProveedor.SelectedIndex = 0;
            
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades o = new MenuFuncionalidades(usuario);
            o.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {//publicar oferta
            Boolean resultado;
            if (esProveedor)
            {
                int idProveedor = ProveedorDAO.obtenerIdProveedor(usuario);
                resultado = ProveedorDAO.publicarOferta(idProveedor, Oferta_descripcion.Text, dateTimePicker1.Value, (double)numericUpDownPrecioOferta.Value, (double)numericUpDownPrecioLista.Value, (int)numericUpDownCantidad.Value, (int)numericUpDownMaximo.Value);
            }
            else
            {
                ComboboxItem item = (ComboboxItem)comboBoxProveedor.SelectedItem;
                Proveedor proveedorSeleccionado = (Proveedor)item.value;
                resultado = ProveedorDAO.publicarOferta(proveedorSeleccionado.id, Oferta_descripcion.Text, dateTimePicker1.Value, (double)numericUpDownPrecioOferta.Value, (double)numericUpDownPrecioLista.Value, (int)numericUpDownCantidad.Value, (int)numericUpDownMaximo.Value);
            }
            if (resultado)
            {
                MessageBox.Show("Oferta publicada con exito");
                MenuFuncionalidades o = new MenuFuncionalidades(usuario);
                o.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error publicando la oferta, verifique los datos e intente nuevamente");
            }
        }
    }
}
