using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using FrbaOfertas.DAOs;
using FrbaOfertas._Clases;

namespace FrbaOfertas
{
    public partial class CargarCredito : Form
    {
        Usuario usuario;
        public CargarCredito(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label2.Visible = false;
            foreach (Rol r in usuario.roles)
            {
             
                if (DBConnection.isAdmin(r))
                {
                    label1.Text = "Cargar a cliente: ";
                    comboBox1.Visible = true;
                    label2.Visible = true;
                    List<Cliente> clientes = ClienteDAO.getClientes();
                    foreach (Cliente c in clientes)
                    {
                        comboBox1.Items.Add(c.id);

                    }
                  
                    comboBox1.SelectedIndex = 0;
                  
                    
                }
            }  
            List<TipoDePago> tiposDePago = ClienteDAO.getFormasDePago();
            List<Tarjeta> tarjetas = ClienteDAO.getTarjetas(usuario);
           
            foreach (TipoDePago t in tiposDePago)
            {
                combo_formaDePago.Items.Add(t.descripcion);
                combo_formaDePago.SelectedIndex = 0;
            }

            foreach (Tarjeta t in tarjetas)
            {
                comboBoxTarjeta.Items.Add(t.numero);
                comboBoxTarjeta.SelectedIndex = 0;
            }

            if (comboBoxTarjeta.Items.Count == 0)
            {
                comboBoxTarjeta.Enabled = false;    
            
            }
                
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades oc = new MenuFuncionalidades(usuario);
            oc.Show();
            this.Hide();
        }

        private void buttonCargarTarjeta_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible)
            {
                Usuario usuACargar = DBConnection.usuario_from_cliente(Convert.ToInt16(comboBox1.SelectedItem));
                CargaTarjeta ct = new CargaTarjeta(usuario,usuACargar);
                ct.Show();
            }
            else {
                CargaTarjeta ct = new CargaTarjeta(usuario,null);
                ct.Show();
            }
            
            
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cargaRealizada = 0;
            
            if (combo_formaDePago.SelectedItem.ToString() == "Efectivo")
            {
                if (comboBox1.Visible)
                {
                    Usuario usu = DBConnection.usuario_from_cliente(Convert.ToInt16(comboBox1.SelectedValue));
                    if (usu.username == null)
                    {
                        MessageBox.Show("No se encontro usuario");
                        return;
                    }
                    cargaRealizada = ClienteDAO.realizarCarga(usu, double.Parse(numericUpDownMonto.Value.ToString()), null, 1);


                }
                else
                {
                    cargaRealizada = ClienteDAO.realizarCarga(usuario, double.Parse(numericUpDownMonto.Value.ToString()), null, 1);
                }
            }
            else if(!comboBoxTarjeta.Enabled && (combo_formaDePago.SelectedItem.ToString() == "Débito" || combo_formaDePago.SelectedItem.ToString() == "Crédito"))
            {

                MessageBox.Show("No hay tarjetas disponibles, cargar una tarjeta");
                return;
            }
            else if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(combo_formaDePago.SelectedItem.ToString(), "Crédito", CompareOptions.IgnoreCase) >= 0 || CultureInfo.InvariantCulture.CompareInfo.IndexOf(combo_formaDePago.SelectedItem.ToString(), "Débito", CompareOptions.IgnoreCase) >= 0 || CultureInfo.InvariantCulture.CompareInfo.IndexOf(combo_formaDePago.SelectedItem.ToString(), "tarjeta", CompareOptions.IgnoreCase) >= 0)
            {
                if (comboBox1.Visible)
                {
                    Usuario usu = DBConnection.usuario_from_cliente(Convert.ToInt16(comboBox1.SelectedItem));
                    if (usu.username == null)
                    {
                        MessageBox.Show("No se encontro usuario");
                        return;
                    }
                    Tarjeta tarjetaSeleccionada = ClienteDAO.obtenerTarjeta(usu, comboBoxTarjeta.SelectedItem.ToString());
                    cargaRealizada = ClienteDAO.realizarCarga(usu, double.Parse(numericUpDownMonto.Value.ToString()), tarjetaSeleccionada, 2);
                }
                else
                {
                    Tarjeta tarjetaSeleccionada = ClienteDAO.obtenerTarjeta(usuario, comboBoxTarjeta.SelectedItem.ToString());
                    cargaRealizada = ClienteDAO.realizarCarga(usuario, double.Parse(numericUpDownMonto.Value.ToString()), tarjetaSeleccionada, 2);
                }
            }
            else
            {
                MessageBox.Show("Metodo de pago desconocido, intente nuevamente");
            }
            switch (cargaRealizada)
            {
                case 1:
                    MessageBox.Show("No existe el cliente");
                    break;
                case 2:
                    MessageBox.Show("Cliente no habilitado");
                    break;
                case 3:
                    MessageBox.Show("Monto menor a 1");
                    break;
                case 4:
                    MessageBox.Show("No existe la tarjeta");
                    break;
                case 5:
                    MessageBox.Show("Carga exitosa");
                    MenuFuncionalidades menu = new MenuFuncionalidades(usuario);
                    menu.Show();
                    this.Hide();
                    break;
                case 6:
                    MessageBox.Show("Error en forma de pago");
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTarjeta.Items.Clear();
            Usuario u = DBConnection.usuario_from_cliente(Convert.ToInt16(comboBox1.SelectedItem));
            if (u.username != null)
            {
                label2.Visible = true;
                if (u.username == usuario.username)
                {
                    label2.Text = "TU usuario: " + u.username;
                }
                else
                {
                    label2.Text = "usuario: " + u.username;
                }

                List<Tarjeta> tarjetas = ClienteDAO.getTarjetas(u);

                foreach (Tarjeta t in tarjetas)
                {
                    comboBoxTarjeta.Items.Add(t.numero);
                    comboBoxTarjeta.SelectedIndex = 0;
                }

                if (comboBoxTarjeta.Items.Count == 0)
                {
                    comboBoxTarjeta.Enabled = false;

                }
            }
            else {
                label2.Visible = false;
                comboBoxTarjeta.Enabled = false;            
            }
            
            
        }
    }
}
