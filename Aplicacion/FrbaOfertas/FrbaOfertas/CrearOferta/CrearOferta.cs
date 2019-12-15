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
            esProveedor = ProveedorDAO.esProveedorHabilitado(usuario);

            dateTimePicker2.MinDate = utils.obtenerFecha();
            dateTimePicker2.Value = utils.obtenerFecha();
            dateTimePicker1.MinDate = utils.obtenerFecha();
            dateTimePicker1.Value = utils.obtenerFecha().AddDays(1);
            if(usuario.roles.Any(rol => DBConnection.isAdmin(rol)))
            {   
                List<Proveedor> proveedores = ProveedorDAO.getProveedores();
                foreach (Proveedor p in proveedores)
                {
                    if (p.habilitada)
                    {
                        ComboboxItem item = new ComboboxItem(p.razon_social, p);
                        comboBoxProveedor.Items.Add(item);
                    }
                }
                if (comboBoxProveedor.Items.Count > 0)
                {
                    comboBoxProveedor.SelectedIndex = 0;
                }
                else {

                    MessageBox.Show("Parece que no hay proveedores disponibles");                 
                
                }
            
            }
            else if (esProveedor)
            {
                labelProveedor.Hide();
                comboBoxProveedor.Hide();
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
            if (!utils.validarNoVacio(Oferta_descripcion))
            {
                MessageBox.Show("Falta descripcion");
                return;
            }
           
            
            if (numericUpDownCantidad.Value<=0 || numericUpDownMaximo.Value<=0
                    || numericUpDownPrecioLista.Value <= 0 || numericUpDownPrecioOferta.Value <= 0
                    || numericUpDownPrecioOferta.Value > numericUpDownPrecioLista.Value)
            {
                MessageBox.Show("todos los valores deben ser mayores a 0; el precio de oferta debe ser menor o igual al de lista");
                return;
            }

            if (dateTimePicker1.Value == dateTimePicker2.Value)
            {
                MessageBox.Show("La fecha de publicacion y vencimiento no deberian coincidir");
                return;            
            }


            Boolean resultado;
            if (esProveedor)
            {
                int idProveedor = ProveedorDAO.obtenerIdProveedor(usuario);
                resultado = ProveedorDAO.publicarOferta(idProveedor, Oferta_descripcion.Text, dateTimePicker1.Value, dateTimePicker2.Value, (double)numericUpDownPrecioOferta.Value, (double)numericUpDownPrecioLista.Value, (int)numericUpDownCantidad.Value, (int)numericUpDownMaximo.Value);
            }
            else
            {
                if (comboBoxProveedor.Items.Count==0)
                {
                    MessageBox.Show("No hay proveedor seleccionado");
                    return;

                }
                ComboboxItem item = (ComboboxItem)comboBoxProveedor.SelectedItem;
                Proveedor proveedorSeleccionado = (Proveedor)item.value;
                resultado = ProveedorDAO.publicarOferta(proveedorSeleccionado.id, Oferta_descripcion.Text, dateTimePicker1.Value, dateTimePicker2.Value, (double)numericUpDownPrecioOferta.Value, (double)numericUpDownPrecioLista.Value, (int)numericUpDownCantidad.Value, (int)numericUpDownMaximo.Value);
            }
            if (resultado)
            {
                MessageBox.Show("Oferta publicada con exito");
                
            }
            else
            {
                MessageBox.Show("Error publicando la oferta, verifique los datos e intente nuevamente");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
