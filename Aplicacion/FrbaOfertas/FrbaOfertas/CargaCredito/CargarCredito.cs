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
            //se carga el credito
        }
    }
}
