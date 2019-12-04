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
           
            List<TipoDePago> tiposDePago = ClienteDAO.getFormasDePago();
            List<Tarjeta> tarjetas = ClienteDAO.getTarjetas(usuario);
           
            foreach (TipoDePago t in tiposDePago)
            {
                combo_formaDePago.Items.Add(t.descripcion);
            }

            foreach (Tarjeta t in tarjetas)
            {
                comboBoxTarjeta.Items.Add(t.numero);
            }
            combo_formaDePago.SelectedIndex = 0;
            comboBoxTarjeta.SelectedIndex = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades oc = new MenuFuncionalidades(usuario);
            oc.Show();
            this.Hide();
        }

        private void buttonCargarTarjeta_Click(object sender, EventArgs e)
        {
            CargaTarjeta ct = new CargaTarjeta(usuario);
            ct.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cargaRealizada = 0;
            if (combo_formaDePago.SelectedItem.ToString() == "Efectivo")
            {
                cargaRealizada = ClienteDAO.realizarCarga(usuario, double.Parse(numericUpDownMonto.Value.ToString()), null,1);
            }
            else if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(combo_formaDePago.SelectedItem.ToString(), "Crédito", CompareOptions.IgnoreCase) >= 0 || CultureInfo.InvariantCulture.CompareInfo.IndexOf(combo_formaDePago.SelectedItem.ToString(), "Débito", CompareOptions.IgnoreCase) >= 0 || CultureInfo.InvariantCulture.CompareInfo.IndexOf(combo_formaDePago.SelectedItem.ToString(), "tarjeta", CompareOptions.IgnoreCase) >= 0)
            {
                Tarjeta tarjetaSeleccionada = ClienteDAO.obtenerTarjeta(usuario, comboBoxTarjeta.SelectedItem.ToString());
                cargaRealizada = ClienteDAO.realizarCarga(usuario, double.Parse(numericUpDownMonto.Value.ToString()), tarjetaSeleccionada, 2);
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
    }
}
