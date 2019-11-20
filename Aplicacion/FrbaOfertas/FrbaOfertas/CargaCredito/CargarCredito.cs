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
            //hay que cargar los metodos de pago habilitados y las tarjetas del cliente
            List<TipoDePago> tiposDePago = ClienteDAO.getFormasDePago();
            List<Tarjeta> tarjetas = ClienteDAO.getTarjetas(usuario);
            //falta mostrarlas
            //las tarjetas tienen que estar como Items para poder hacer comboboxTarjeta.SelectedItem
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpcionesCliente oc = new OpcionesCliente(usuario);
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
            Tarjeta tarjetaSeleccionada = (Tarjeta)comboBoxTarjeta.SelectedItem;
            //pa probar xd Tarjeta tarjetaSeleccionada = new Tarjeta(1, "123456789");
            int cargaRealizada = ClienteDAO.realizarCarga(usuario, double.Parse(numericUpDownMonto.Value.ToString()), tarjetaSeleccionada);
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
                    break;
            }
        }
    }
}
